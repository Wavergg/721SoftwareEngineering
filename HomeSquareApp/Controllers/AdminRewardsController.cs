using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminRewardsController : Controller
    {
        private readonly AppDbContext _context;

        private static List<RewardPool> _rewardsContext;

        private const int ITEMS_PER_PAGE = 11;
        private static int _currentRange = 0;

        public AdminRewardsController(AppDbContext context)
        {
            this._context = context;
        }

        private void PerformOrderFilter(string filters, string category)
        {
            switch (category)
            {
                case "Name":
                    _rewardsContext = _rewardsContext.Where(r => r.Product.ProductName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Category":
                    _rewardsContext = _rewardsContext.Where(r => r.Product.Category.CategoryName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                default:
                    break;
            }
        }

        [HttpPost]
        public async Task<IActionResult> RewardNextTableData(int pageNumber)
        {
            if (_rewardsContext == null)
            {
                _rewardsContext = await _context.RewardPool.Include(rp => rp.Product)
                                    .ThenInclude(p => p.Category)
                                    .Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted)
                                    .ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;

            return PartialView("_AdminRewardTableDataPartial", _rewardsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> OrderSortTableData(string sortOrder)
        {
            if (_rewardsContext == null)
            {
                _rewardsContext = await _context.RewardPool.Include(rp => rp.Product)
                                .ThenInclude(p => p.Category)
                                .Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted).ToListAsync();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    _rewardsContext = _rewardsContext.OrderByDescending(rp => rp.Product.ProductName).ToList();
                    break;
                case "name_asc":
                    _rewardsContext = _rewardsContext.OrderBy(rp => rp.Product.ProductName).ToList();
                    break;
                case "stock_desc":
                    _rewardsContext = _rewardsContext.OrderByDescending(rp => rp.PoolQuantity).ToList();
                    break;
                default:
                    _rewardsContext = _rewardsContext.OrderBy(rp => rp.PoolQuantity).ToList();
                    break;
            }

            return PartialView("_AdminRewardTableDataPartial", _rewardsContext.Take(ITEMS_PER_PAGE).ToList());
        }

        #region search bar Overloading
        //Method used when the filter is added
        [HttpPost]
        public async Task<IActionResult> RewardFilterTableData(string filters, string category)
        {
            if (_rewardsContext == null)
            {
                _rewardsContext = await _context.RewardPool.Include(rp => rp.Product)
                                    .ThenInclude(p => p.Category)
                                    .Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted).ToListAsync();
            }

            PerformOrderFilter(filters, category);

            _currentRange = 0;
            return PartialView("_AdminRewardTableDataPartial", _rewardsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public IActionResult RefreshRewardTableIndex()
        {
            return PartialView("_AdminRewardTableDataPartial", _rewardsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public IActionResult UpdatePagination()
        {
            if (_rewardsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_rewardsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }


        //Method used when the filter is removed by click
        [HttpPost]
        public async Task<IActionResult> RewardRemoveFilterTableData([FromBody] List<AdminFilterModel> filters)
        {
            _rewardsContext = await _context.RewardPool.Include(rp => rp.Product)
                                    .ThenInclude(p => p.Category)
                                    .Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted).ToListAsync();

            foreach (AdminFilterModel filterItem in filters)
            {
                PerformOrderFilter(filterItem.value, filterItem.category);
            }
            _currentRange = 0;

            return Json("success");
        }
        #endregion

        [HttpPost]
        public IActionResult GetProductQuery(string searchString)
        {
            if (searchString.Length < 2) return Json(null);

            List<Product> products = _context.Product.Where(p => p.ProductName.ToLower().Contains(searchString.ToLower()))
                                        .Take(5).ToList();

            return Json(products);
        }

        [HttpPost]
        public IActionResult GetProductByID(int productID)
        {
            Product product = _context.Product.Where(p => p.ProductID == productID).FirstOrDefault();

            return PartialView("_AdminRewardSelectorResultPartial",product);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int rewardID)
        {
            RewardPool reward = _context.RewardPool.Where(rp => rp.RewardPoolID == rewardID).FirstOrDefault();
            

            if (_rewardsContext == null)
            {
                _rewardsContext = await _context.RewardPool.Include(rp => rp.Product)
                                    .ThenInclude(p => p.Category)
                                    .Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted).ToListAsync();
            }
            else
            {
                reward.RewardPoolStatus = RewardPoolStatus.Deleted;
                int tempQuantityToRelease = reward.PoolQuantity;
                reward.PoolQuantity = 0;
                _context.Update(reward);

                Product product = _context.Product.Where(p => p.ProductID == reward.ProductID).FirstOrDefault();
                if(product != null) { 
                    product.ProductStock += tempQuantityToRelease;
                    _context.Update(product);
                }
                _context.SaveChanges();

                _rewardsContext.RemoveAll(rp => rp.RewardPoolID == rewardID);
            }

            int currentPage = _currentRange / ITEMS_PER_PAGE;

            if (_rewardsContext.Count() > ITEMS_PER_PAGE)
            {
                int pageCount = ((_rewardsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
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

            return PartialView("_AdminRewardTableModelPartial", _rewardsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }


        public async Task<IActionResult> Index()
        {
            _rewardsContext = await _context.RewardPool.Include(rp => rp.Product).ThenInclude(p => p.Category).Where(rp => rp.RewardPoolStatus != RewardPoolStatus.Deleted).ToListAsync();

            if (_rewardsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_rewardsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return View(_rewardsContext.OrderBy(rp => rp.PoolQuantity).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public IActionResult Create()
        {
            AdminRewardPoolViewModel model = new AdminRewardPoolViewModel();
            model.Product = new Product();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductID,PoolQuantity,ProductName")] AdminRewardPoolViewModel model)
        {
            Product product = _context.Product.Where(p => p.ProductName.ToLower() == model.ProductName.ToLower()).FirstOrDefault();
            if(product == null)
            {
                ModelState.AddModelError("", "Unable to Find Product");
            } else if(product.ProductStock < model.PoolQuantity)
            {
                ModelState.AddModelError("", "Not Enough Stock to Reserve for Reward, Current Stock: " +product.ProductStock);
            } 

            if (ModelState.IsValid)
            {
                product.ProductStock -= model.PoolQuantity;
                _context.Update(product);

                RewardPool rewardPool = new RewardPool()
                {
                    PoolQuantity = model.PoolQuantity,
                    ProductID = product.ProductID,
                    RewardPoolStatus = RewardPoolStatus.Ongoing
                };

                _context.Add(rewardPool);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return RedirectToAction("Create");
        }
    }
}
