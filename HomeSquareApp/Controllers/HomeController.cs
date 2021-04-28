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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
