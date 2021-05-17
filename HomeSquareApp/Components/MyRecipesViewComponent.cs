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
    public class MyRecipesViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;

        private const int ITEMS_PER_PAGE = 11;

        public MyRecipesViewComponent(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._UserManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync(int _currentPage = 0)
        {
            ApplicationUser user = await _UserManager.GetUserAsync(UserClaimsPrincipal);

            List<Recipe> recipes = _context.Recipe
                                .Where(r => r.UserID == user.Id)
                                .OrderByDescending(r => r.AddedDate).ToList();

            
            if (recipes.Count() > ITEMS_PER_PAGE)
            {
                int pageCount = ((recipes.Count() - 1) / ITEMS_PER_PAGE) + 1;
                ViewData["PaginationCount"] = pageCount;

                if (_currentPage > pageCount)
                {
                    _currentPage = pageCount - 1;
                }
            }
            else
            {
                _currentPage = 0;
            }

            ViewData["SetActivePage"] = _currentPage;

            return View(recipes.Skip(_currentPage * ITEMS_PER_PAGE).Take(ITEMS_PER_PAGE));
        }
    }
}
