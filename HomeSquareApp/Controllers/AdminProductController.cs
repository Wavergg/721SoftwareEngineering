using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace HomeSquareApp.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly AppDbContext _context;

        public IHostingEnvironment _HostingEnvironment { get; }

        public AdminProductController(AppDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _HostingEnvironment = hostingEnvironment;
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsProductExist(string productName)
        {
            var product = _context.Product.Where(p => p.ProductName == productName).FirstOrDefault();
            if (product == null)
            {
                return Json(true);
            }
            return Json("Product with same name already existed");
        }

        public IActionResult GetProductServingType()
        {
            var data = _context.ProductServingType.ToList();
            return Json(data);
        }

        public IActionResult GetProductStatus()
        {
            var data = _context.ProductStatus.ToList();
            return Json(data);
        }

        public IActionResult GetProductCategory()
        {
            var data = _context.Category.ToList();
            return Json(data);
        }

        // GET: AdminProduct
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Product.Include(p => p.ProductStatus);
            return View(await appDbContext.ToListAsync());
        }

        // GET: AdminProduct/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductStatus)
                .Include(p => p.ServingType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: AdminProduct/Create
        public IActionResult Create()
        {
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName");
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName");
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID");
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType");
            AdminProductCreateViewModel model = new AdminProductCreateViewModel();
            return View(model);
        }

        // POST: AdminProduct/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ProductID,ProductPrice,ProductStock,ProductName,ProductDiscount," +
            "ProductInformation,Description,ProductServingContent,ProductServingTypeID," +
            "ProductStatusID,CategoryID,Image")] AdminProductCreateViewModel model)
        {
            
            if (ModelState.IsValid)
            {
                string uniqueFileName = null;

                string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath,"lib" ,"images", "products");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Image.CopyTo(new FileStream(filePath, FileMode.Create));

                Product product = new Product() {
                    ProductName = model.ProductName,
                    ProductPrice = model.ProductPrice,
                    ProductStock = model.ProductStock,
                    ProductAddedDate = DateTime.Now,
                    ProductDiscount = model.ProductDiscount,
                    ImageUrl = uniqueFileName,
                    ProductInformation = model.ProductInformation,
                    Description = model.Description,
                    ProductServingContent = model.ProductServingContent,
                    ProductServingTypeID = model.ProductServingTypeID,
                    ProductStatusID = model.ProductStatusID,
                    CategoryID = model.CategoryID
                };

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", model.CategoryID);
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName", model.ProductStatusID);
            
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID", model.RewardPoolID);
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType", model.ProductServingTypeID);
            
            return View(model);
        }

        // GET: AdminProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName", product.ProductStatusID);
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID", product.RewardPoolID);
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType", product.ProductServingTypeID);
            return View(product);
        }

        // POST: AdminProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductPrice,ProductStock,ProductName,ProductDiscount,ReviewFiveStarsCount,ReviewFourStarsCount,ReviewThreeStarsCount,ReviewTwoStarsCount,ReviewOneStarsCount,Week5PurchaseCount,Week4PurchaseCount,Week3PurchaseCount,Week2PurchaseCount,Week1PurchaseCount,CurrentWeekPurchaseCount,ProductInformation,Description,ProductServingContent,ProductServingTypeID,ProductStatusID,CategoryID,RewardPoolID")] Product product)
        {
            if (id != product.ProductID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductID))
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
            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName", product.ProductStatusID);
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID", product.RewardPoolID);
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType", product.ProductServingTypeID);
            return View(product);
        }

        // GET: AdminProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Category)
                .Include(p => p.ProductStatus)
                .Include(p => p.RewardPool)
                .Include(p => p.ServingType)
                .FirstOrDefaultAsync(m => m.ProductID == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: AdminProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
