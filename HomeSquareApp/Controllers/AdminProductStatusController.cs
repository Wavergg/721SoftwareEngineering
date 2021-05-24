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
    public class AdminProductStatusController : Controller
    {
        private readonly AppDbContext _context;

        public AdminProductStatusController(AppDbContext context)
        {
            _context = context;
        }

        // GET: AdminProductStatus
        public async Task<IActionResult> Index()
        {
            List<ProductStatus> productStatuses = await _context.ProductStatus.ToListAsync();

            //productStatuses.Where(ps=>ps.ProductStatusName == "Sale").FirstOrDefault()
            //    .Products =
            //    await _context.Product.Where(p => p.ProductStatus.ProductStatusName == "Sale" && p.SaleEndDateTime <= DateTime.Now).ToListAsync();

            return View(productStatuses);
        }

        // GET: AdminProductStatus/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productStatus = await _context.ProductStatus
        //        .FirstOrDefaultAsync(m => m.ProductStatusID == id);
        //    if (productStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productStatus);
        //}

        //// GET: AdminProductStatus/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: AdminProductStatus/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ProductStatusID,ProductStatusName")] ProductStatus productStatus)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(productStatus);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productStatus);
        //}

        //// GET: AdminProductStatus/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productStatus = await _context.ProductStatus.FindAsync(id);
        //    if (productStatus == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(productStatus);
        //}

        //// POST: AdminProductStatus/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("ProductStatusID,ProductStatusName")] ProductStatus productStatus)
        //{
        //    if (id != productStatus.ProductStatusID)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(productStatus);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductStatusExists(productStatus.ProductStatusID))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(productStatus);
        //}

        //// GET: AdminProductStatus/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var productStatus = await _context.ProductStatus
        //        .FirstOrDefaultAsync(m => m.ProductStatusID == id);
        //    if (productStatus == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(productStatus);
        //}

        //// POST: AdminProductStatus/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var productStatus = await _context.ProductStatus.FindAsync(id);
        //    _context.ProductStatus.Remove(productStatus);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool ProductStatusExists(int id)
        //{
        //    return _context.ProductStatus.Any(e => e.ProductStatusID == id);
        //}
    }
}
