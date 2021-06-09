using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Identity;
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
        private UserManager<ApplicationUser> _userManager;

        private static List<Product> _productsContext;
        private const int ITEMS_PER_PAGE = 20;
        private static int _currentRange = 0;

        public ProductController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
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
                        .Where(p => p.Category.CategoryName.ToLower().Contains(searchString.ToLower()) || p.ProductName.Contains(searchString.ToLower()))
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
            BannerImages bannerImage = _context.BannerImages.Where(bi => bi.BannerType == BannerType.Product && bi.BannerStatus == BannerStatus.Active).FirstOrDefault();
            if(bannerImage != null)
            {
                model.ProductBannerUrl = bannerImage.BannerUrl;
            }


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

            product.Review = _context.Review.Where(r => r.ProductID == product.ProductID)
                            .OrderByDescending(r=>r.ReviewDateTime)
                            .Include(r => r.User).ToList();

            ApplicationUser user = await _userManager.GetUserAsync(User);

            ProductDetailsViewModel model = new ProductDetailsViewModel();
            model.Product = product;
            model.User = user;
            model.CurrentUserReview = product.Review.Where(r => r.UserID == user.Id).FirstOrDefault();

            return View(model);
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
            if(string.IsNullOrEmpty(productName))
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
            if (string.IsNullOrEmpty(categoryName))
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
