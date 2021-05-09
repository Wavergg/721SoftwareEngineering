using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles ="ADMIN")]
    public class AdminOrderController : Controller
    {
        private readonly AppDbContext _context;
        private static List<Order> _ordersContext;

        private const int ITEMS_PER_PAGE = 4;
        private static int _currentRange = 0;

        public AdminOrderController(AppDbContext _context)
        {
            this._context = _context;
        }

        public void PerformOrderFilter(string filters, string category)
        {
            switch (category)
            {
                case "Email":
                    _ordersContext = _ordersContext.Where(o => o.User.DeliveryEmail.Contains(filters.ToLower())).ToList();
                    break;
                case "FirstName":
                    _ordersContext = _ordersContext.Where(o => o.User.FirstName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "LastName":
                    _ordersContext = _ordersContext.Where(o => o.User.LastName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Status":
                    _ordersContext = _ordersContext.Where(o => o.OrderStatus.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                default:
                    break;
            }
        }

        [HttpPost]
        public async Task<IActionResult> OrderNextTableData(int pageNumber)
        {
            if (_ordersContext == null)
            {
                _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;

            return PartialView("_AdminOrderTableDataPartial", _ordersContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> OrderSortTableData(string sortOrder)
        {
            if (_ordersContext == null)
            {
                _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();
            }

            switch (sortOrder)
            {
                case "orderDate_asc":
                    _ordersContext = _ordersContext.OrderBy(o => o.OrderDateTime).ToList();
                    break;
                case "firstName_asc":
                    _ordersContext = _ordersContext.OrderBy(o => o.User.FirstName).ToList();
                    break;
                case "firstName_desc":
                    _ordersContext = _ordersContext.OrderByDescending(o => o.User.FirstName).ToList();
                    break;
                case "lastName_asc":
                    _ordersContext = _ordersContext.OrderBy(o => o.User.LastName).ToList();
                    break;
                case "lastName_desc":
                    _ordersContext = _ordersContext.OrderByDescending(o => o.User.LastName).ToList();
                    break;
                case "orderStatus_desc":
                    _ordersContext = _ordersContext.OrderByDescending(o => o.OrderStatus).ToList();
                    break;
                case "orderStatus_asc":
                    _ordersContext = _ordersContext.OrderBy(o => o.OrderStatus).ToList();
                    break;
                case "deliveryOption_asc":
                    _ordersContext = _ordersContext.OrderBy(o => o.DeliveryOptions).ToList();
                    break;
                case "deliveryOption_desc":
                    _ordersContext = _ordersContext.OrderByDescending(o => o.DeliveryOptions).ToList();
                    break;
                default:
                    _ordersContext = _ordersContext.OrderByDescending(o => o.OrderDateTime).ToList();
                    break;
            }

            return PartialView("_AdminOrderTableDataPartial", _ordersContext.Take(ITEMS_PER_PAGE).ToList());
        }

        #region search bar Overloading
        //Method used when the filter is added
        [HttpPost]
        public async Task<IActionResult> OrderFilterTableData(string filters, string category)
        {
            if (_ordersContext == null)
            {
                _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();
            }

            PerformOrderFilter(filters, category);

            _currentRange = 0;
            return PartialView("_AdminOrderTableDataPartial", _ordersContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        //Method used when the filter is removed by click
        [HttpPost]
        public async Task<IActionResult> OrderRemoveFilterTableData([FromBody] List<AdminFilterModel> filters)
        {
            _ordersContext = await _context.Order.Include(o => o.User)
                            .Where(o => o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();

            foreach (AdminFilterModel filterItem in filters)
            {
                PerformOrderFilter(filterItem.value, filterItem.category);
            }
            _currentRange = 0;

            return Json("success");
        }
        #endregion

        [HttpPost]
        public IActionResult RefreshOrderTableIndex()
        {
            return PartialView("_AdminOrderTableDataPartial", _ordersContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public IActionResult UpdatePagination()
        {
            if (_ordersContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_ordersContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }

        // GET: AdminOrder
        public async Task<IActionResult> Index()
        {
            _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o=>o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();
            if (_ordersContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_ordersContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return View(_ordersContext.OrderByDescending(o => o.OrderDateTime).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        // GET: AdminProduct/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Order
                .Include(o=>o.User)
                .FirstOrDefaultAsync(o => o.OrderID == id);
            if (order == null)
            {
                return NotFound();
            }

            order.OrderDetails = await _context.OrderDetails.Where(od => od.OrderID == order.OrderID)
                                .Include(od=>od.Product).ToListAsync();

            return View(order);
        }

        // POST: AdminProduct/Edit?id=5&status="Preparing"
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> EditStatus([Bind("orderID,status")]string orderID,string status)
        {
            
            Order order = await _context.Order.Where(o => o.OrderID == orderID)
                          .Include(o=>o.User).FirstOrDefaultAsync();

            if (order != null)
            {
                if (status == "Preparing" || status == "Completed" || status == "Ready" || status == "Deleted") { 
                    order.OrderStatus = status;
                    _context.Update(order);
                    _context.SaveChanges();
                }
            }

            return PartialView("_AdminEditOrderStatusPartial",order);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(string orderID)
        {
            Order order = _context.Order.Where(o => o.OrderID == orderID).FirstOrDefault();
            order.OrderStatus = "Deleted";
            _context.Update(order);
            _context.SaveChanges();

            if (_ordersContext == null)
            {
                _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted").ToListAsync();
            } else
            {
                _ordersContext.RemoveAll(o => o.OrderID == orderID);
            }

            return PartialView("_AdminOrderTableDataPartial", _ordersContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }
    }
}
