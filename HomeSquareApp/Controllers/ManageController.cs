using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly IHostingEnvironment _HostingEnvironment;

        private const int ITEMS_PER_PAGE = 11;
        private static int _currentRange = 0;

        public ManageController(AppDbContext context, UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager,
            IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._UserManager = userManager;
            this._SignInManager = signInManager;
            this._HostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index(string pageName)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            if ( await _UserManager.IsInRoleAsync(user, "CUSTOMER") && ( pageName == "PastOrders" || pageName == "MyRecipes" || pageName == "MyRewards"))
            {
                ViewData["pageName"] = pageName;
            } 
            else
            {
                ViewData["pageName"] = "AccountSettings";
            }

            return View(user);
        }

        public IActionResult ChangePage(string pageName)
        {
            if (pageName == "PastOrders" || pageName == "MyRecipes" || pageName == "MyRewards")
            {
                ViewData["pageName"] = pageName;
            }
            else
            {
                ViewData["pageName"] = "AccountSettings";
            }
            return PartialView("_ManagePageContent");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfile(
            [Bind("UserID","FirstName", "LastName", "Image", "PhoneNumber", "Address",
            "Email","Suburb","ZipCode","Unit")] ManageUserProfileViewModel model)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;

            model.PictureUrl = user.PictureUrl;
            if (user.Id != model.UserID)
            {
                errorMsg.Message.Add("Invalid User, Please Try to Logout and Re-login");
                return Json(errorMsg);
            }

            if (ModelState.IsValid)
            {
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.PhoneNumber = model.PhoneNumber;
                user.Address = model.Address;
                user.Suburb = model.Suburb;
                user.ZipCode = model.ZipCode;
                user.Unit = model.Unit;

                if (model.Image != null)
                {
                    if(user.PictureUrl != "blank-profile.png") { 
                        string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "users", user.PictureUrl);
                        System.IO.File.Delete(filePath);
                    }
                    user.PictureUrl = ProcessUploadedFile(model.Image);
                }

                _context.Update(user);
                await _context.SaveChangesAsync();

                errorMsg.IsSuccess = true;
                errorMsg.Message.Add("Successfully updated your profile");
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

            foreach (string error in allErrors)
            {
                errorMsg.Message.Add($"{error}");
            }

            return Json(errorMsg);
        }

        [HttpPost]
        public async Task<IActionResult> OrderDetails(string orderID)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            Order order = _context.Order.Where(o => o.OrderID == orderID && user.Id == o.UserID).Include(o => o.User).FirstOrDefault();
            if (order == null)
            {
                TempData["ErrorMessage"] = "Unable to locate order";
            }
            else { 
                order.OrderDetails = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Include(od => od.Product).ToList();
            }
            return PartialView("_ManageOrderDetailsPartial", order);
        }

        [HttpPost]
        public async Task<IActionResult> OrderNextTableData(int pageNumber)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);
            _currentRange = pageNumber * ITEMS_PER_PAGE;

            List<Order> orders = _context.Order
                                .Where(o => o.UserID == user.Id && o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted")
                                .OrderByDescending(o => o.OrderDateTime)
                                .Skip(_currentRange).Take(ITEMS_PER_PAGE)
                                .ToList();

            return PartialView("_OrderTableDataPartial", orders);
        }

        [HttpPost]
        public async Task<IActionResult> RecipeNextTableData(int pageNumber)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            List<Recipe> recipes = _context.Recipe
                                .Where(r => r.UserID == user.Id)
                                .OrderByDescending(r => r.AddedDate).ToList();

            if (recipes.Count() > ITEMS_PER_PAGE)
            {
                int pageCount = ((recipes.Count() - 1) / ITEMS_PER_PAGE) + 1;
                ViewData["PaginationCount"] = pageCount;

                if (pageNumber > pageCount)
                {
                    pageNumber = pageCount - 1;
                }
            }
            else
            {
                pageNumber = 0;
            }

            ViewData["SetActivePage"] = pageNumber;

            return PartialView("_RecipeTableDataPartial",recipes.Skip(pageNumber * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE));
        }

        [HttpPost]
        public async Task<IActionResult> RewardsNextTableData(int pageNumber)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            List<Reward> rewards = _context.Reward
                                .Where(r => r.UserID == user.Id)
                                .Include(r => r.Product)
                                .OrderByDescending(r => r.RewardAddedDateTime).ToList();

            if (rewards.Count() > ITEMS_PER_PAGE)
            {
                int pageCount = ((rewards.Count() - 1) / ITEMS_PER_PAGE) + 1;
                ViewData["PaginationCount"] = pageCount;

                if (pageNumber > pageCount)
                {
                    pageNumber = pageCount - 1;
                }
            }
            else
            {
                pageNumber = 0;
            }

            ViewData["SetActivePage"] = pageNumber;

            return PartialView("_RewardTableDataPartial", rewards.Skip(pageNumber * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE));
        }


        [HttpPost]
        public async Task<IActionResult> GetUserPictureUrlAndHandleName()
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            List<string> message = new List<string>();
            message.Add(string.Format("{0} {1}", user.FirstName, user.LastName));
            if(user.PictureUrl == null)
            {
                user.PictureUrl = "blank-profile.png";
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
            }
            string pictureAbsolutePath = Path.Combine(Request.Scheme + "://" + Request.Host.Value, "lib", "images", "users", user.PictureUrl);
            message.Add(pictureAbsolutePath);
            return Json(message);
        }



        [HttpPost]
        public async Task<IActionResult> DeleteRecipeConfirmed(int recipeID, int currentPage = 0)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);
            Recipe recipe = await _context.Recipe.Where(r => r.RecipeID == recipeID && r.UserID == user.Id).Include(r => r.RecipeSteps).Include(r => r.Ingredients).FirstOrDefaultAsync();

            //DELETE CASCADE ON DATABASE
            HardDeleteRecipe(recipe);

            return ViewComponent("MyRecipes",new { _currentPage = currentPage });
        }

        private void HardDeleteRecipe(Recipe recipe)
        {
            List<RecipeUserLike> recipesLike = _context.RecipeUserLike.Where(rul => rul.RecipeID == recipe.RecipeID).ToList();
            foreach(RecipeUserLike recipeLike in recipesLike)
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

        [HttpPost]
        public async Task<IActionResult> GetAllUserRewards()
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            List<Reward> rewards = _context.Reward.Where(r => r.UserID == user.Id).ToList();

            //return PartialView("_RewardTableModelPartial", rewards);

            return ViewComponent("MyRewards");
        }

        [HttpPost]
        public async Task<IActionResult> RenderModalRewardPartial()
        {
            ApplicationUser user = await _UserManager.GetUserAsync(User);

            return PartialView("_ModalRewardPartial", user);
        }

        private string ProcessUploadedFile(IFormFile Image)
        {
            string uniqueFileName = "";

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "users");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return uniqueFileName;
        }
    }
}
