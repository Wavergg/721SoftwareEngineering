using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeSquareApp.Data;
using HomeSquareApp.Models;

namespace HomeSquareApp.Controllers
{
    public class AdminRecipesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminRecipesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminRecipes
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Recipe.Include(r => r.RecipeApprovalStatus).Include(r => r.User);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminRecipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.RecipeApprovalStatus)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: AdminRecipes/Create
        public IActionResult Create()
        {
            ViewData["RecipeApprovalStatusID"] = new SelectList(_context.RecipeApprovalStatus, "RecipeApprovalStatusID", "RecipeApprovalStatusID");
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: AdminRecipes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeID,RecipeName,RecipeDescription,Servings,PrepareTime,Likes,RecipeApprovalStatusID,UserID")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeApprovalStatusID"] = new SelectList(_context.RecipeApprovalStatus, "RecipeApprovalStatusID", "RecipeApprovalStatusID", recipe.RecipeApprovalStatusID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UserID);
            return View(recipe);
        }

        // GET: AdminRecipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            ViewData["RecipeApprovalStatusID"] = new SelectList(_context.RecipeApprovalStatus, "RecipeApprovalStatusID", "RecipeApprovalStatusID", recipe.RecipeApprovalStatusID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UserID);
            return View(recipe);
        }

        // POST: AdminRecipes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeID,RecipeName,RecipeDescription,Servings,PrepareTime,Likes,RecipeApprovalStatusID,UserID")] Recipe recipe)
        {
            if (id != recipe.RecipeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["RecipeApprovalStatusID"] = new SelectList(_context.RecipeApprovalStatus, "RecipeApprovalStatusID", "RecipeApprovalStatusID", recipe.RecipeApprovalStatusID);
            ViewData["UserID"] = new SelectList(_context.Users, "Id", "Id", recipe.UserID);
            return View(recipe);
        }

        // GET: AdminRecipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .Include(r => r.RecipeApprovalStatus)
                .Include(r => r.User)
                .FirstOrDefaultAsync(m => m.RecipeID == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: AdminRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var recipe = await _context.Recipe.FindAsync(id);
            _context.Recipe.Remove(recipe);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
            return _context.Recipe.Any(e => e.RecipeID == id);
        }
    }
}
