﻿using HomeSquareApp.Data;
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
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class RecipeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly IHostingEnvironment _HostingEnvironment;

        public RecipeController(AppDbContext _context, SignInManager<ApplicationUser> signInManager, IHostingEnvironment hostingEnvironment)
        {
            this._context = _context;
            this._SignInManager = signInManager;
            this._HostingEnvironment = hostingEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            //NYD Do DB QUERY HERE

            //NYD Replace with Strongly typed model later
            return View(id);
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
                        .Where(p => p.Category.CategoryName == category.CategoryName && p.ProductStock > 0).OrderByDescending(p=>p.ProductUpdateDate).FirstOrDefaultAsync();
                }
                else
                {
                    product = await _context.Product.Include(p=>p.ServingType).Where(p => p.ProductName.ToLower().Contains(ingredient.IngredientName.ToLower()) && p.ProductStock > 0)
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

                recipe.RecipeApprovalStatus = RecipeApprovalStatus.Pending;
                recipe.AddedDate = DateTime.Now;
                recipe.RecipeName = model.RecipeName;
                recipe.UserID = model.UserID;
                recipe.PrepareTime = model.PrepareTime;
                recipe.Servings = model.Servings;
                recipe.RecipeDescription = model.RecipeDescription;
                recipe.RecipeSteps = model.RecipeSteps;
                recipe.ImageUrl = uniqueFileName;

                _context.Add(recipe);
                await _context.SaveChangesAsync();
                //Change the return URL LATER
                return RedirectToAction(nameof(Index));
            }

            return View(model);
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
    }
}
