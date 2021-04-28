using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> featuredProducts = await _context.Product.Include(p => p.ProductStatus).Include(p=> p.ServingType)
                                .Where(p => p.ProductStatus.ProductStatusName == "Sale" && p.SaleEndDateTime >= DateTime.Now)
                                .OrderByDescending(p => p.SaleStartDateTime)
                                .Take(20)
                                .ToListAsync();

            List<Product> latestProduct = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.ServingType)
                                .Where(p => p.ProductStatus.ProductStatusName != "Hold")
                                .OrderByDescending(p => p.ProductAddedDate)
                                .Take(20)
                                .ToListAsync();

            HomeViewModel model = new HomeViewModel();
            model.FeaturedProducts = featuredProducts;
            model.LatestProducts = latestProduct;
            return View(model);
        }

        public IActionResult GetQuery(string searchString, string searchCategories)
        {
            if (searchString.Length < 2) return Json(null);

            if (searchCategories == "Products")
            {
                List<string> productsName = _context.Product.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()))
                                            .Take(5).Select(p => p.ProductName).ToList();

                List<string> categoryName = _context.Category.Where(c => c.CategoryName.ToLower().Contains(searchString.ToLower()))
                                            .Take(5).Select(c => c.CategoryName).ToList();

                return Json(productsName.Concat(categoryName));
            }
            else if (searchCategories == "Recipes")
            {
                return Json(true);
            }
            return Json(null);
        }

        public IActionResult StartQuery(string searchString, string searchCategories)
        {
            if (searchCategories == "Products")
            {
                return RedirectToAction("Index", "Product", new { searchString = searchString });
            }
            else if (searchCategories == "Recipes")
            {
                return Json(true);
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
