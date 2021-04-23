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
    public class AdminProductServingTypesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminProductServingTypesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminProductServingTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductServingType.ToListAsync());
        }

        // GET: AdminProductServingTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productServingType = await _context.ProductServingType
                .FirstOrDefaultAsync(m => m.ProductServingTypeID == id);
            if (productServingType == null)
            {
                return NotFound();
            }

            return View(productServingType);
        }

        // GET: AdminProductServingTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminProductServingTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductServingTypeID,ServingType")] ProductServingType productServingType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productServingType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productServingType);
        }

        // GET: AdminProductServingTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productServingType = await _context.ProductServingType.FindAsync(id);
            if (productServingType == null)
            {
                return NotFound();
            }
            return View(productServingType);
        }

        // POST: AdminProductServingTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductServingTypeID,ServingType")] ProductServingType productServingType)
        {
            if (id != productServingType.ProductServingTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productServingType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductServingTypeExists(productServingType.ProductServingTypeID))
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
            return View(productServingType);
        }

        // GET: AdminProductServingTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productServingType = await _context.ProductServingType
                .FirstOrDefaultAsync(m => m.ProductServingTypeID == id);
            if (productServingType == null)
            {
                return NotFound();
            }

            return View(productServingType);
        }

        // POST: AdminProductServingTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productServingType = await _context.ProductServingType.FindAsync(id);
            _context.ProductServingType.Remove(productServingType);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductServingTypeExists(int id)
        {
            return _context.ProductServingType.Any(e => e.ProductServingTypeID == id);
        }
    }
}
