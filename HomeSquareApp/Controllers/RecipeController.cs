using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly IHostingEnvironment _HostingEnvironment;

        private const int ITEMS_PER_PAGE = 6;
        private static int _currentRange = 0;
        private static List<Recipe> _recipesContext;

        public RecipeController(AppDbContext _context, 
            SignInManager<ApplicationUser> signInManager, 
            UserManager<ApplicationUser> userManager,
            IHostingEnvironment hostingEnvironment)
        {
            this._context = _context;
            this._SignInManager = signInManager;
            this._UserManager = userManager;
            this._HostingEnvironment = hostingEnvironment;
        }

        private string ProcessUploadedFile(IFormFile Image)
        {
            string uniqueFileName = "";

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "recipes");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            _recipesContext = await _context.Recipe.Include(r => r.User)
                            .Where(r => r.RecipeApprovalStatus == RecipeApprovalStatus.Approved)
                            .OrderByDescending(r => r.ApprovedDate)
                            .ToListAsync();
            ViewData["IsFiltered"] = false;
            if (!string.IsNullOrEmpty(searchString))
            {
                _recipesContext = _recipesContext
                                    .Where(r => r.User.FirstName.ToLower().Contains(searchString.ToLower())
                                            || r.User.LastName.ToLower().Contains(searchString.ToLower())
                                            || r.RecipeName.ToLower().Contains(searchString.ToLower()))
                                    .OrderByDescending(r => r.ApprovedDate)
                                    .ToList();

                ViewData["IsFiltered"] = true;
            }

            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;
            return View(_recipesContext.OrderByDescending(r => r.ApprovedDate).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public async Task<IActionResult> Details(int? id)
        {
            Recipe recipe = _context.Recipe.Include(r=>r.User)
                            .Where(r => r.RecipeID == id ).FirstOrDefault();
            if (id==null || recipe == null)
            {
                return RedirectToAction(nameof(Index));
            }

            recipe.Ingredients = _context.Ingredient.Include(i=>i.Product).ThenInclude(p=>p.ServingType)
                                .Include(i=>i.Product).ThenInclude(p=>p.ProductStatus)
                                .Where(i => i.RecipeID == recipe.RecipeID).ToList();
            recipe.RecipeSteps = _context.RecipeSteps.Where(rs => rs.RecipeID == recipe.RecipeID).ToList();

            ViewData["IsLiked"] = false;

            if (_SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);
                RecipeUserLike recipeUserLike =_context.RecipeUserLike.Where(rul => rul.UserID == user.Id && rul.RecipeID == recipe.RecipeID).FirstOrDefault();
                ViewData["IsLiked"] = recipeUserLike != null ? true : false;
            }

            return View(recipe);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            RecipeCreateViewModel model = new RecipeCreateViewModel();
            ApplicationUser user = await _SignInManager.UserManager.GetUserAsync(User);

            model.UserID = user.Id;
            model.FirstName = user.FirstName;
            model.Ingredients.Add(new IngredientViewModel());
            model.RecipeSteps.Add(new RecipeSteps());
            ViewData["IngredientServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("RecipeName", "RecipeDescription", "Servings", "PrepareTime",
            "UserID", "Image", "Ingredients", "RecipeSteps")] RecipeCreateViewModel model)
        {

            Recipe recipe = new Recipe();
            int counter = 0;

            foreach (IngredientViewModel ingredient in model.Ingredients)
            {
                if (string.IsNullOrEmpty(ingredient.IngredientName) || string.IsNullOrEmpty(ingredient.ServingContent))
                {
                    counter++;
                    continue;
                }
                Category category = _context.Category.Where(c => c.CategoryName.ToLower().Contains(ingredient.IngredientName.ToLower())).FirstOrDefault();

                Product product = null;

                if (category != null)
                {
                    product = await _context.Product.Include(p => p.ServingType).Include(p => p.Category)
                        .Where(p => p.Category.CategoryName == category.CategoryName).OrderByDescending(p=>p.ProductStock).FirstOrDefaultAsync();
                }
                else
                {
                    product = await _context.Product.Include(p=>p.ServingType).Where(p => p.ProductName.ToLower().Contains(ingredient.IngredientName.ToLower()))
                                        .OrderByDescending(p=>p.ProductStock)
                                        .FirstOrDefaultAsync();
                }

                if (product == null)
                {
                    ModelState.AddModelError("", "Unable to find matched product for " + ingredient.IngredientName);
                } else
                {
                    //MIGHT NEED CHANGE COMPARE SERVING CONTENT
                    Ingredient ingredientModel = new Ingredient()
                    {
                        ProductID = product.ProductID,
                        ServingContent = ingredient.ServingContent,
                        IngredientName = ingredient.IngredientName,
                        Quantity = 1
                    };

                    recipe.Ingredients.Add(ingredientModel);
                }

                
            }

            if(counter == model.Ingredients.Count)
            {
                ModelState.AddModelError("", "Recipe is Required to Have Minimum of 1 Ingredient");
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model.Image);
                ApplicationUser user = await _UserManager.FindByIdAsync(model.UserID);
                bool isAdmin = await _UserManager.IsInRoleAsync(user,"ADMIN");

                recipe.RecipeApprovalStatus = isAdmin? RecipeApprovalStatus.Approved : RecipeApprovalStatus.Pending;
                recipe.AddedDate = DateTime.Now;
                if (isAdmin)
                {
                    recipe.ApprovedDate = DateTime.Now;
                }
                recipe.RecipeName = model.RecipeName;
                recipe.UserID = model.UserID;
                recipe.PrepareTime = model.PrepareTime;
                recipe.Servings = model.Servings;
                recipe.RecipeDescription = model.RecipeDescription;
                recipe.RecipeSteps = model.RecipeSteps;
                recipe.ImageUrl = uniqueFileName;

                if (model.PrepareTime.Any(char.IsDigit))
                {
                    Regex regex = new Regex(@"^(?<NUMVALUE>\d+.?\d*)\s*(?<STRVALUE>[A-Za-z]*)$", RegexOptions.Singleline);
                    Match match = regex.Match(recipe.PrepareTime);

                    recipe.PrepareTimeDuration = match.Groups["NUMVALUE"].Value;
                    recipe.PrepareTimeMeasurement = match.Groups["STRVALUE"].Value;
                }
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                //Change the return URL LATER

                if (isAdmin)
                {
                    return RedirectToAction("Index","AdminRecipes");
                } else { 
                    return RedirectToAction("Index","Manage",new { pageName = "MyRecipes" });
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> HandleLike(int recipeID)
        {
            Recipe recipe = _context.Recipe.Where(r => r.RecipeID == recipeID).FirstOrDefault();

            if (recipe != null && _SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);

                RecipeUserLike recipeUserLike = _context.RecipeUserLike.Where(rul => rul.RecipeID == recipe.RecipeID && rul.UserID == user.Id).FirstOrDefault();
                if (recipeUserLike == null)
                {
                    recipeUserLike = new RecipeUserLike()
                    {
                        RecipeID = recipe.RecipeID,
                        UserID = user.Id
                    };
                    _context.Add(recipeUserLike);
                    recipe.Likes++;
                    ViewData["IsLiked"] = true;
                }
                else
                {
                    _context.Remove(recipeUserLike);
                    recipe.Likes--;
                    ViewData["IsLiked"] = false;
                }
                _context.Recipe.Update(recipe);
                _context.SaveChanges();
            }

            return PartialView("_RecipeLikePartial", recipe);
        }

        [HttpPost]
        public async Task<IActionResult> GetRecipesByName(string recipeName)
        {
            if (string.IsNullOrEmpty(recipeName))
            {
                _recipesContext = await _context.Recipe.Include(r => r.User)
                                .Where(r => r.RecipeApprovalStatus == RecipeApprovalStatus.Approved)
                                .OrderByDescending(r=>r.ApprovedDate)
                                .ToListAsync();
            }
            else { 
                _recipesContext = await _context.Recipe.Include(r => r.User)
                                    .Where(r => r.RecipeApprovalStatus == RecipeApprovalStatus.Approved &&
                                            r.RecipeName.ToLower().Contains(recipeName))
                                    .OrderByDescending(r => r.ApprovedDate)
                                    .ToListAsync();
            }
            _currentRange = 0;
            
            return PartialView("_RecipeShowCasePartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> GetAllRecipes()
        {
            _recipesContext = await _context.Recipe.Include(r => r.User)
                                .Where(r => r.RecipeApprovalStatus == RecipeApprovalStatus.Approved)
                                .OrderByDescending(r => r.ApprovedDate)
                                .ToListAsync();

            _currentRange = 0;
            
            return PartialView("_RecipeShowCasePartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public IActionResult LoadNextRecipes()
        {
            _currentRange++;
            if (_recipesContext.Count() > ITEMS_PER_PAGE + (_currentRange * ITEMS_PER_PAGE))
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            return PartialView("_RecipeShowCasePartial", _recipesContext.Skip(_currentRange * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public IActionResult HasRecipeData()
        {
            bool hasRecipeData = _recipesContext.Count() > ITEMS_PER_PAGE + (_currentRange * ITEMS_PER_PAGE);

            return Json(hasRecipeData);
        }
    }
}
