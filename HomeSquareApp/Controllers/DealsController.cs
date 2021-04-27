using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class DealsController : Controller
    {
        private readonly AppDbContext _context;

        public DealsController(AppDbContext context)
        {
            this._context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> model = await _context.Product.Include(p => p.ProductStatus).Include(p => p.ServingType)
                                .Where(p => p.ProductStatus.ProductStatusName == "Sale" && p.SaleEndDateTime >= DateTime.Now)
                                .OrderByDescending(p => p.SaleStartDateTime)
                                .Take(20)
                                .ToListAsync();
            return View(model);
        }
    }
}
