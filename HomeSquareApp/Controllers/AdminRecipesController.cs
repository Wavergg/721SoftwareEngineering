using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminRecipesController : Controller
    {
        private readonly AppDbContext _context;
        private static List<Recipe> _recipesContext;

        private const int ITEMS_PER_PAGE = 11;
        private static int _currentRange = 0;

        public AdminRecipesController(AppDbContext context)
        {
            _context = context;
        }

        public void PerformRecipeFilter(string filters, string category)
        {
            switch (category)
            {
                case "RecipeName":
                    _recipesContext = _recipesContext.Where(r => r.RecipeName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Status":
                    _recipesContext = _recipesContext.Where(r => r.RecipeApprovalStatus.ToString().ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Author":
                    _recipesContext = _recipesContext.Where(r => r.User.FirstName.ToLower().Contains(filters.ToLower()) || r.User.LastName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                default:
                    break;
            }
        }

        public IActionResult UpdatePagination()
        {
            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }


        [HttpPost]
        public IActionResult RefreshRecipeTableIndex()
        {
            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RecipeSortTableData(string sortOrder)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            }

            switch (sortOrder)
            {
                case "recipeName_desc":
                    _recipesContext = _recipesContext.OrderByDescending(r => r.RecipeName).ToList();
                    break;
                case "recipeName_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.RecipeName).ToList();
                    break;
                case "status_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.RecipeApprovalStatus.ToString()).ToList();
                    break;
                case "status_desc":
                    _recipesContext = _recipesContext.OrderByDescending(r => r.RecipeApprovalStatus.ToString()).ToList();
                    break;
                case "addedDate_asc":
                    _recipesContext = _recipesContext.OrderBy(r => r.AddedDate).ToList();
                    break;
                default:
                    _recipesContext = _recipesContext.OrderBy(r => r.AddedDate).ToList();
                    break;
            }

            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> RecipeNextTableData(int pageNumber)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;

            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        #region search bar Overloading
        //Method used when the filter is added
        [HttpPost]
        public async Task<IActionResult> RecipeFilterTableData(string filters, string category)
        {
            if (_recipesContext == null)
            {
                _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            }

            PerformRecipeFilter(filters, category);

            _currentRange = 0;
            return PartialView("_AdminRecipeTableDataPartial", _recipesContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        //Method used when the filter is removed by click
        [HttpPost]
        public async Task<IActionResult> RecipeRemoveFilterTableData([FromBody] List<AdminFilterModel> filters)
        {
            _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            foreach (AdminFilterModel filterItem in filters)
            {
                PerformRecipeFilter(filterItem.value, filterItem.category);
            }
            _currentRange = 0;

            return Json("success");
        }
        #endregion


        // GET: AdminRecipes
        public async Task<IActionResult> Index()
        {
            _recipesContext = await _context.Recipe.Include(r => r.User).ToListAsync();
            if (_recipesContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_recipesContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;
            return View(_recipesContext.OrderByDescending(r => r.AddedDate).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

    }
}
