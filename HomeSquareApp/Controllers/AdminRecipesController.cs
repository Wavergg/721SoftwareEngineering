using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Authorization;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Text.RegularExpressions;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminRecipesController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly IHostingEnvironment _HostingEnvironment;
        private static List<Recipe> _recipesContext;

        private const int ITEMS_PER_PAGE = 11;
        private static int _currentRange = 0;
        private int counter = 0;
        private List<string> invalidProducts = new List<string>();

        public AdminRecipesController(AppDbContext context, SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            this._SignInManager = signInManager;
            this._UserManager = userManager;
            this._HostingEnvironment = hostingEnvironment;
        }

        private async Task<List<Ingredient>> MatchRecipeProduct(List<IngredientViewModel> ingredients)
        {
            List<Ingredient> ingredientList = new List<Ingredient>();
            counter = 0;
            invalidProducts = new List<string>();
            foreach (IngredientViewModel ingredient in ingredients)
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
                    product = await _context.Product.Include(p => p.ServingType).Include(p => p.Category).Include(p => p.ProductStatus)
                        .Where(p => p.Category.CategoryName == category.CategoryName && p.ProductStatus.ProductStatusName != "Hold").OrderByDescending(p => p.ProductStock).FirstOrDefaultAsync();
                }
                else
                {
                    product = await _context.Product.Include(p => p.ServingType).Include(p => p.ProductStatus)
                                .Where(p => p.ProductName.ToLower().Contains(ingredient.IngredientName.ToLower()) && p.ProductStatus.ProductStatusName != "Hold")
                                .OrderByDescending(p => p.ProductStock)
                                .FirstOrDefaultAsync();
                }

                if (product == null)
                {
                    invalidProducts.Add(ingredient.IngredientName);
                }
                else
                {
                    
                    //MIGHT NEED CHANGE COMPARE SERVING CONTENT
                    Ingredient ingredientModel = new Ingredient()
                    {
                        ProductID = product.ProductID,
                        ServingContent = ingredient.ServingContent,
                        IngredientName = ingredient.IngredientName,
                        Quantity = 1
                    };

                    ingredientList.Add(ingredientModel);
                }
            }

            return ingredientList;
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

        //UNUSED
        private void HardDeleteRecipe(Recipe recipe)
        {
            List<RecipeUserLike> recipesLike = _context.RecipeUserLike.Where(rul => rul.RecipeID == recipe.RecipeID).ToList();
            foreach (RecipeUserLike recipeLike in recipesLike)
            {
                _context.RecipeUserLike.Remove(recipeLike);
            }
            foreach (RecipeSteps steps in recipe.RecipeSteps)
            {
                _context.RecipeSteps.Remove(steps);
            }
            foreach (Ingredient ingredient in recipe.Ingredients)
            {
                _context.Ingredient.Remove(ingredient);
            }

            string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "recipes", recipe.ImageUrl);
            System.IO.File.Delete(filePath);



            _context.Recipe.Remove(recipe);
            _context.SaveChanges();
        }

        public void PerformRecipeFilter(string filters, string category)
        {
            switch (category)
            {
                case "RecipeName":
                    _recipesContext = _recipesContext.Where(r => r.RecipeName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Status":
                    _recipesContext = _recipesContext.Where(r => r.RecipeApprovalStatus.ToString().ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Author":
                    _recipesContext = _recipesContext.Where(r => r.User.FirstName.ToLower().Contains(filters.ToLower()) || r.User.LastName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                default:
                    break;
            }
        }

        public IActionResult UpdatePagination()
        {
            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }

        [HttpPost]
        public IActionResult RefreshRecipeTableIndex()
        {
            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RecipeSortTableData(string sortOrder)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User)
                                .Where(r => r.RecipeApprovalStatus != RecipeApprovalStatus.Delete).ToListAsync();
            }

            switch (sortOrder)
            {
                case "recipeName_desc":
                    _recipesContext = _recipesContext.OrderByDescending(r => r.RecipeName).ToList();
                    break;
                case "recipeName_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.RecipeName).ToList();
                    break;
                case "status_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.RecipeApprovalStatus.ToString()).ToList();
                    break;
                case "status_desc":
                    _recipesContext = _recipesContext.OrderByDescending(r => r.RecipeApprovalStatus.ToString()).ToList();
                    break;
                case "addedDate_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.AddedDate).ToList();
                    break;
                default:
                    _recipesContext = _recipesContext.OrderByDescending(r => r.AddedDate).ToList();
                    break;
            }

            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RecipeNextTableData(int pageNumber)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User)
                                .Where(r => r.RecipeApprovalStatus != RecipeApprovalStatus.Delete).ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;

            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        #region search bar Overloading
        //Method used when the filter is added
        [HttpPost]
        public async Task<IActionResult> RecipeFilterTableData(string filters, string category)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User)
                                    .Where(r => r.RecipeApprovalStatus != RecipeApprovalStatus.Delete).ToListAsync();
            }

            PerformRecipeFilter(filters, category);

            _currentRange = 0;
            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        //Method used when the filter is removed by click
        [HttpPost]
        public async Task<IActionResult> RecipeRemoveFilterTableData([FromBody] List<AdminFilterModel> filters)
        {
            _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            foreach (AdminFilterModel filterItem in filters)
            {
                PerformRecipeFilter(filterItem.value, filterItem.category);
            }
            _currentRange = 0;

            return Json("success");
        }
        #endregion


        // GET: AdminRecipes
        public async Task<IActionResult> Index()
        {
            _recipesContext = await _context.Recipe.Include(r => r.User)
                            .Where(r => r.RecipeApprovalStatus != RecipeApprovalStatus.Delete).ToListAsync();
            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;
            return View(_recipesContext.OrderByDescending(r => r.AddedDate).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        // GET: AdminRecipes/Create
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            RecipeCreateViewModel model = new RecipeCreateViewModel();
            ApplicationUser user = await _SignInManager.UserManager.GetUserAsync(User);

            model.UserID = user.Id;
            model.FirstName = user.FirstName;
            model.Ingredients.Add(new IngredientViewModel());
            model.RecipeSteps.Add(new RecipeSteps());
            //ViewData["IngredientServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("RecipeName", "RecipeDescription", "Servings", "PrepareTime",
            "UserID", "Image", "Ingredients", "RecipeSteps")] RecipeCreateViewModel model)
        {
            Recipe recipe = new Recipe();
            recipe.Ingredients = await MatchRecipeProduct(model.Ingredients);

            if (counter >= recipe.Ingredients.Count)
            {
                ModelState.AddModelError("", "Recipe is Required to Have Minimum of 1 Ingredient");
            } 
            else if(invalidProducts.Count > 0)
            {
                foreach(string invalidProduct in invalidProducts) { 
                    ModelState.AddModelError("", "Unable to find matched product for " + invalidProduct);
                }
            }

            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model.Image);
                ApplicationUser user = await _UserManager.FindByIdAsync(model.UserID);

                recipe.RecipeApprovalStatus = RecipeApprovalStatus.Approved;
                recipe.AddedDate = DateTime.Now;
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
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: AdminRecipes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = _context.Recipe.Where(r => r.RecipeID == id).FirstOrDefault();

            if (recipe == null)
            {
                return NotFound();
            }

            AdminRecipeEditViewModel model = new AdminRecipeEditViewModel();
            model.RecipeID = recipe.RecipeID;
            model.ExistingImageUrl = recipe.ImageUrl;
            model.ExistingImagePath = Path.Combine("\\", "lib", "images", "recipes", recipe.ImageUrl).Replace('\\', '/');
            model.UserID = recipe.UserID;
            model.RecipeName = recipe.RecipeName;
            model.RecipeSteps = _context.RecipeSteps.Where(rs => rs.RecipeID == recipe.RecipeID).ToList();
            model.Servings = recipe.Servings;
            model.RecipeDescription = recipe.RecipeDescription;
            model.PrepareTime = recipe.PrepareTime;
            model.RecipeStatus = recipe.RecipeApprovalStatus;



            List<Ingredient> ingredients = _context.Ingredient.Where(i => i.RecipeID == recipe.RecipeID).ToList();

            foreach (Ingredient ingredient in ingredients)
            {
                model.Ingredients.Add(new IngredientViewModel() { IngredientName = ingredient.IngredientName, ServingContent = ingredient.ServingContent });
            }

            var statuses = from RecipeApprovalStatus s in Enum.GetValues(typeof(RecipeApprovalStatus))
                           select new { ID = s, Name = s.ToString() };
            SelectList myList = new SelectList(statuses, "ID", "Name");

            ViewBag.RecipeStatus = myList;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(
            [Bind("RecipeID","ExistingImageUrl","RecipeStatus","RecipeName", "RecipeDescription", "Servings", "PrepareTime",
            "UserID", "Image", "Ingredients", "RecipeSteps")] AdminRecipeEditViewModel model)
        {
            Recipe recipe = _context.Recipe.Where(r => r.RecipeID == model.RecipeID).Include(r => r.RecipeSteps).Include(r => r.Ingredients).FirstOrDefault();

            if (recipe == null)
            {
                return RedirectToAction(nameof(Index));
            }

            
            List<Ingredient> TempIngredient = await MatchRecipeProduct(model.Ingredients);

            if (counter >= TempIngredient.Count)
            {
                ModelState.AddModelError("", "Recipe is Required to Have Minimum of 1 Ingredient");
            }
            else if (invalidProducts.Count > 0)
            {
                foreach (string invalidProduct in invalidProducts)
                {
                    ModelState.AddModelError("", "Unable to find matched product for " + invalidProduct);
                }
            }


            if (ModelState.IsValid)
            {
                foreach (RecipeSteps steps in recipe.RecipeSteps)
                {
                    _context.RecipeSteps.Remove(steps);
                }
                foreach (Ingredient ingredient in recipe.Ingredients)
                {
                    _context.Ingredient.Remove(ingredient);
                }

                ApplicationUser user = await _UserManager.FindByIdAsync(model.UserID);

                recipe.RecipeID = model.RecipeID;
                recipe.RecipeApprovalStatus = model.RecipeStatus;
                if(model.RecipeStatus == RecipeApprovalStatus.Approved)
                {
                    recipe.ApprovedDate = DateTime.Now;
                }
                recipe.AddedDate = DateTime.Now;
                recipe.RecipeName = model.RecipeName;
                recipe.UserID = model.UserID;
                recipe.PrepareTime = model.PrepareTime;
                recipe.Servings = model.Servings;
                recipe.RecipeDescription = model.RecipeDescription;
                recipe.RecipeSteps = model.RecipeSteps;
                recipe.Ingredients = TempIngredient;

                if (model.PrepareTime.Any(char.IsDigit))
                {
                    
                    Regex regex = new Regex(@"^(?<NUMVALUE>\d+.?\d*)\s*(?<STRVALUE>[A-Za-z]*)$", RegexOptions.Singleline);
                    Match match = regex.Match(recipe.PrepareTime);

                    recipe.PrepareTimeDuration = match.Groups["NUMVALUE"].Value;
                    recipe.PrepareTimeMeasurement = match.Groups["STRVALUE"].Value;
                }

                if (model.Image != null)
                {
                    string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "recipes", recipe.ImageUrl);
                    System.IO.File.Delete(filePath);
                    recipe.ImageUrl = ProcessUploadedFile(model.Image);
                }
                else
                {
                    recipe.ImageUrl = model.ExistingImageUrl;
                }

                _context.Update(recipe);
                await _context.SaveChangesAsync();
                //Change the return URL LATER
                return RedirectToAction(nameof(Index));
            }

            var statuses = from RecipeApprovalStatus s in Enum.GetValues(typeof(RecipeApprovalStatus))
                           select new { ID = s, Name = s.ToString() };
            SelectList myList = new SelectList(statuses, "ID", "Name");
            model.ExistingImagePath = Path.Combine("\\", "lib", "images", "recipes", model.ExistingImageUrl).Replace('\\', '/');
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int recipeID)
        {
            Recipe recipe = await _context.Recipe.Where(r => r.RecipeID == recipeID).Include(r => r.RecipeSteps).Include(r => r.Ingredients).FirstOrDefaultAsync();

            //METHOD 1 SET STATUS INSTEAD OF DELETING:
            //only set the status to be delete swap it between both method
            recipe.RecipeApprovalStatus = RecipeApprovalStatus.Delete;
            _context.Recipe.Update(recipe);
            await _context.SaveChangesAsync();

            //METHOD 2 DELETE CASCADE ON DATABASE
            //Reenable this if recipe is required to be hard deleted
            //await HardDeleteRecipe(recipe);

            if (_recipesContext.Where(r => r.RecipeID == recipe.RecipeID) != null)
            {
                _recipesContext.RemoveAll(r => r.RecipeID == recipe.RecipeID);
            }

            int currentPage = (_currentRange / ITEMS_PER_PAGE);

            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                int pageCount = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
                ViewData["PaginationCount"] = pageCount;

                if (currentPage > pageCount)
                {
                    currentPage = pageCount - 1;
                }
            }
            else
            {
                currentPage = 0;
            }

            ViewData["SetActivePage"] = currentPage;

            return PartialView("_AdminRecipeTableModelPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        
    }
}
