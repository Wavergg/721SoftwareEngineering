using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class MyRewardsViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;

        private const int ITEMS_PER_PAGE = 11;

        public MyRewardsViewComponent(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._UserManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int _currentRange = 0)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(UserClaimsPrincipal);

            List<Reward> rewards = _context.Reward.Where(r => r.UserID == user.Id)
                                    .Include(r=>r.Product)
                                    .OrderByDescending(r=>r.RewardAddedDateTime).ToList();


            if (rewards.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((rewards.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }

            RewardViewModel model = new RewardViewModel()
            {
                CurrentUser = user,
                Rewards = rewards.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList()
            };

            return View(model);
        }
    }
}
