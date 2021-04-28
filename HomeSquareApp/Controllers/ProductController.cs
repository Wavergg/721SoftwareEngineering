using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        
        private static List<Product> _productsContext;
        private const int ITEMS_PER_PAGE = 20;
        private static int _currentRange = 0;

        public ProductController(AppDbContext context)
        {
            this._context = context;
        }

        public List<Product> SortProductList(List<Product> productList,int sortBy)
        {
            switch (sortBy)
            {
                case 1:
                    productList = productList.OrderBy(p => p.ProductPrice).ToList();
                    break;
                case 2:
                    productList = productList.OrderByDescending(p => p.CurrentWeekPurchaseCount).ToList();
                    break;
                case 3:
                    productList = productList.OrderBy(p => p.SaleEndDateTime >= DateTime.Now ? 0 : 1)
                                    .ThenBy(p=>p.ProductStatus.ProductStatusName == "Sale" ? 0 : 1)
                                    .ThenByDescending(p => p.ProductDiscount).ToList();
                    break;
                default:
                    productList = productList.OrderByDescending(p => p.ProductAddedDate).ToList();
                    break;
            }
            return productList;
        }

        public IActionResult UpdatePagination()
        {
            if (_productsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_productsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }

        public async Task<IActionResult> Index(string searchString)
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                _productsContext = await _context.Product.Include(p => p.ProductStatus)
                        .Where(p => p.ProductStatus.ProductStatusName != "Hold")
                        .Include(p => p.Category)
                        .Where(p => p.Category.CategoryName.ToLower().Contains(searchString) || p.ProductName.Contains(searchString))
                        .Include(p=>p.ServingType)
                        .ToListAsync();

                ViewData["IsFiltered"] = true;
            } else { 
            _productsContext = await _context.Product.Include(p => p.ProductStatus)
                                .Where(p => p.ProductStatus.ProductStatusName != "Hold" )
                                .Include(p => p.ServingType)
                                .OrderByDescending(p => p.ProductAddedDate)
                                .ToListAsync();
            }
            List<Category> categories = await _context.Category.ToListAsync();
            
            ProductViewModel model = new ProductViewModel();

            model.Products = _productsContext.Take(ITEMS_PER_PAGE).ToList();
            model.Categories = categories;

            if (_productsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_productsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;
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

        public async Task<IActionResult> GetAllProducts(int sortBy)
        {
            _productsContext = await _context.Product.Include(p => p.ProductStatus)
                                .Where(p => p.ProductStatus.ProductStatusName != "Hold" )
                                .Include(p => p.ServingType)
                                .ToListAsync();

            _productsContext = SortProductList(_productsContext, sortBy);
            _currentRange = 0;
            return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public async Task<IActionResult> GetProductsByName(string productName, int sortBy)
        {
            if(productName == null || productName == string.Empty)
            {
                return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
            }

            _productsContext = await _context.Product.Include(p => p.ProductStatus)
                                .Where(p => p.ProductStatus.ProductStatusName != "Hold" && 
                                    p.ProductName.ToLower().Contains(productName.ToLower()))
                                .Include(p => p.ServingType)
                                .ToListAsync();

            _productsContext = SortProductList(_productsContext, sortBy);
            _currentRange = 0;
            return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public async Task<IActionResult> GetProductsByCategoryName(string categoryName, int sortBy)
        {
            if (categoryName == null || categoryName == string.Empty)
            {
                return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
            }

            _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.Category)
                                .Where(p => p.ProductStatus.ProductStatusName != "Hold" &&
                                    p.Category.CategoryName.ToLower() == categoryName.ToLower()
                                    )
                                .Include(p => p.ServingType)
                                .ToListAsync();

            _productsContext = SortProductList(_productsContext, sortBy);
            _currentRange = 0;
            return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public IActionResult SortProducts(int sortBy)
        {
            _productsContext = SortProductList(_productsContext, sortBy);
            _currentRange = 0;
            return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ProductNextData(int pageNumber)
        {
            if (_productsContext == null)
            {
                _productsContext = await _context.Product.Include(p => p.ProductStatus)
                                        .Where(p => p.ProductStatus.ProductStatusName != "Hold")
                                        .Include(p => p.Category)
                                        .Include(p=> p.ServingType)
                                        .ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;

            return PartialView("_ProductShowCasePartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }
    }
}
