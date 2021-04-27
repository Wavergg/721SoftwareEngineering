using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index(int queryId)
        {
            List<Product> products = await _context.Product.Include(p => p.ProductStatus).Include(p => p.ServingType)
                                 .Where(p => p.ProductStatus.ProductStatusName != "Hold")
                                 .Where(p =>  queryId == 0 ? true : p.CategoryID == queryId)
                                 .OrderByDescending(p => p.ProductUpdateDate)
                                 .Take(20)
                                 .ToListAsync();

            List<Category> categories = await _context.Category.ToListAsync();

            ProductViewModel model = new ProductViewModel();

            model.Products = products;
            model.Categories = categories;

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            Product product = await _context.Product.Include(p=>p.ProductStatus)
                        .Where(p=>p.ProductID == id && p.ProductStatus.ProductStatusName != "Hold")
                        .Include(p=>p.ServingType)
                        .FirstOrDefaultAsync();

            if(product == null)
            {
                return RedirectToAction("Index");
            }

            product.Review = _context.Review.Where(r => r.ProductID == product.ProductID).ToList();

            return View(product);
        }
        
        public async Task<IActionResult> Category(int queryId)
        {
            if(queryId == 0)
            {
                RedirectToAction("Index");
            }

            List<Product> products = await _context.Product.Include(p => p.ProductStatus)
                                 .Include(p => p.ServingType)
                                 .Where(p => p.ProductStatus.ProductStatusName != "Hold" && p.CategoryID == queryId)
                                 .OrderByDescending(p => p.ProductUpdateDate)
                                 .Take(20)
                                 .ToListAsync();

            List<Category> categories = await _context.Category.ToListAsync();

            ProductViewModel model = new ProductViewModel();

            model.Products = products;
            model.Categories = categories;

            return View(model);
        }
    }
}
