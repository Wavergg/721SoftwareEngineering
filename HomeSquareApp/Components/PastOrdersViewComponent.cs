using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class PastOrdersViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;

        private const int ITEMS_PER_PAGE = 11;

        public PastOrdersViewComponent(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._UserManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int _currentRange = 0)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(UserClaimsPrincipal);

            List<Order> orders = _context.Order
                                .Where(o => o.UserID == user.Id && o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted")
                                .OrderByDescending(o=>o.OrderDateTime).ToList();

            if (orders.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((orders.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }

            return View(orders.Skip(_currentRange).Take(ITEMS_PER_PAGE));
        }
    }
}
