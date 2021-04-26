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
using Microsoft.AspNetCore.Http;

namespace HomeSquareApp.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly AppDbContext _context;
        private static List<Product> _productsContext;

        private const int ITEMS_PER_PAGE = 13;
        private static int _currentRange = 0;

        public IHostingEnvironment _HostingEnvironment { get; }

        public AdminProductController(AppDbContext context,IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _HostingEnvironment = hostingEnvironment;
        }

        [AcceptVerbs("Get", "Post")]
        public IActionResult IsProductExist(string productName,string productOldName = null)
        {
            if(productOldName != null && productOldName.ToLower() == productName.ToLower())
            {
                return Json(true);
            }
            var product = _context.Product.Where(p => p.ProductName.ToLower() == productName.ToLower()).FirstOrDefault();
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

        public IActionResult UpdatePagination()
        {
            if (_productsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_productsContext.Count() - 1) / ITEMS_PER_PAGE) + 1;
            }
            _currentRange = 0;

            return PartialView("_PaginationPartial");
        }

        [HttpPost]
        public IActionResult RefreshProductTableIndex()
        {
            return PartialView("_AdminProductTableDataPartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        public void PerformProductFilter( string filters,string category)
        {
            switch (category)
            {
                case "Name":
                    _productsContext = _productsContext.Where(p => p.ProductName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Status":
                    _productsContext = _productsContext.Where(p => p.ProductStatus.ProductStatusName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                case "Category":
                    _productsContext = _productsContext.Where(p => p.Category.CategoryName.ToLower().Contains(filters.ToLower())).ToList();
                    break;
                default:
                    break;
            }
        }

        // GET: AdminProduct
        public async Task<IActionResult> Index()
        {
            _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.Category).ToListAsync();
            if(_productsContext.Count() > ITEMS_PER_PAGE)
            {
                ViewData["PaginationCount"] = ((_productsContext.Count() - 1) / ITEMS_PER_PAGE)+1;
            }
            _currentRange = 0;
            
            return View(_productsContext.OrderByDescending(p => p.ProductUpdateDate).Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ProductSortTableData(string sortOrder)
        {
            if(_productsContext == null)
            {
                _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.Category).ToListAsync();
            }

            switch (sortOrder)
            {
                case "name_desc":
                    _productsContext = _productsContext.OrderByDescending(p => p.ProductName).ToList();
                    break;
                case "name_asc":
                    _productsContext = _productsContext.OrderBy(p => p.ProductName).ToList();
                    break;
                case "stock_asc":
                    _productsContext = _productsContext.OrderBy(p => p.ProductStock).ToList();
                    break;
                case "stock_desc":
                    _productsContext = _productsContext.OrderByDescending(p => p.ProductStock).ToList();
                    break;
                case "discount_desc":
                    _productsContext = _productsContext.OrderByDescending(p => p.ProductDiscount).ToList();
                    break;
                case "discount_asc":
                    _productsContext = _productsContext.OrderBy(p => p.ProductDiscount).ToList();
                    break;
                case "purchaseCount_desc":
                    _productsContext = _productsContext.OrderByDescending(p => p.CurrentWeekPurchaseCount).ToList();
                    break;
                case "purchaseCount_asc":
                    _productsContext = _productsContext.OrderBy(p => p.CurrentWeekPurchaseCount).ToList();
                    break;
                default:
                    _productsContext = _productsContext.OrderByDescending(p => p.ProductUpdateDate).ToList();
                    break;
            }
            
            return PartialView("_AdminProductTableDataPartial", _productsContext.Take(ITEMS_PER_PAGE).ToList());
        }

        [HttpPost]
        public async Task<IActionResult> ProductNextTableData(int pageNumber)
        {
            if (_productsContext == null)
            {
                _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.Category).ToListAsync();
            }

            _currentRange = pageNumber * ITEMS_PER_PAGE;
            
            return PartialView("_AdminProductTableDataPartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        #region search bar Overloading
        //Method used when the filter is added
        [HttpPost]
        public async Task<IActionResult> ProductFilterTableData(string filters, string category)
        {
            if (_productsContext == null)
            {
                _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p=>p.Category).ToListAsync();
            }

            PerformProductFilter(filters, category);

            _currentRange = 0;
            return PartialView("_AdminProductTableDataPartial", _productsContext.Skip(_currentRange).Take(ITEMS_PER_PAGE).ToList());
        }

        //Method used when the filter is removed by click
        [HttpPost]
        public async Task<IActionResult> ProductRemoveFilterTableData([FromBody] List<ProductFilterModel> filters)
        {
            _productsContext = await _context.Product.Include(p => p.ProductStatus).Include(p => p.Category).ToListAsync();
            foreach (ProductFilterModel filterItem in filters)
            {
                PerformProductFilter(filterItem.value, filterItem.category);
            }
            _currentRange = 0;
            
            return Json("success");
        }
        #endregion

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
            var date = DateTime.Now;
            model.SaleStartDateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute,0);
            model.SaleEndDateTime = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, 0);
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
            "ProductStatusID,CategoryID,Image,SaleStartDateTime,SaleEndDateTime")] AdminProductCreateViewModel model)
        {
            //Check if product with same name already existed on DB
            if(model != null && model.ProductName != null) {
                bool parseResult;
                bool.TryParse(((JsonResult)IsProductExist(model.ProductName)).Value.ToString(), out parseResult);

                if (parseResult != true)
                {
                    ModelState.AddModelError(string.Empty, "Product Name Is Not Unique");
                }
            }

            if(model.SaleStartDateTime > model.SaleEndDateTime)
            {
                ModelState.AddModelError(string.Empty, "Sale Start Date Should be Before Than the End Date");
            }
           
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessUploadedFile(model.Image);

                Product product = new Product()
                {
                    ProductName = model.ProductName,
                    ProductPrice = model.ProductPrice,
                    ProductStock = model.ProductStock == null ? 0 : model.ProductStock,
                    ProductUpdateDate = DateTime.Now,
                    ProductDiscount = model.ProductDiscount == null ? 0 : model.ProductDiscount,
                    SaleStartDateTime = model.SaleStartDateTime,
                    SaleEndDateTime = model.SaleEndDateTime,
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

        private string ProcessUploadedFile(IFormFile Image)
        {
            string uniqueFileName = "";

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "products");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using(var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return uniqueFileName;
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

            AdminProductEditViewModel model = new AdminProductEditViewModel()
            {
                ProductID = product.ProductID,
                ProductName = product.ProductName,
                ProductOldName = product.ProductName,
                ImageUrl = product.ImageUrl,
                ProductStock = product.ProductStock,
                ProductPrice = product.ProductPrice,
                ProductDiscount = product.ProductDiscount,
                SaleStartDateTime = product.SaleStartDateTime,
                SaleEndDateTime = product.SaleEndDateTime,
                ProductInformation = product.ProductInformation,
                Description = product.Description,
                ProductServingContent = product.ProductServingContent
            };

            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", product.CategoryID);
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName", product.ProductStatusID);
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID", product.RewardPoolID);
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType", product.ProductServingTypeID);
            return View(model);
        }

        // POST: AdminProduct/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, 
            [Bind("ProductID,ProductPrice,ProductStock,ProductName,ProductDiscount," +
            "ProductInformation,Description,ProductServingContent,ProductServingTypeID," +
            "ProductStatusID,CategoryID,ProductIncrement,Image,ImageUrl,SaleStartDateTime,SaleEndDateTime")] AdminProductEditViewModel model)
        {
            if (id != model.ProductID)
            {
                return NotFound();
            }

            Product product = _context.Product.Where(p => p.ProductID == model.ProductID).FirstOrDefault();

            if (model != null && model.ProductName != null && product.ProductName != model.ProductName)
            {
                bool parseResult;
                bool.TryParse(((JsonResult)IsProductExist(model.ProductName)).Value.ToString(), out parseResult);

                if (parseResult != true)
                {
                    ModelState.AddModelError(string.Empty, "Product Name Is Not Unique");
                }
            }

            if (model.SaleStartDateTime > model.SaleEndDateTime)
            {
                ModelState.AddModelError(string.Empty, "Sale Start Date Should be Before Than the End Date");
            }

            if (ModelState.IsValid)
            {

                product.ProductName = model.ProductName;
                product.ProductStock += model.ProductIncrement == null ? 0 : model.ProductIncrement;
                product.ProductPrice = model.ProductPrice;
                product.ProductDiscount = model.ProductDiscount == null ? 0 : model.ProductDiscount;
                product.SaleStartDateTime = model.SaleStartDateTime;
                product.SaleEndDateTime = model.SaleEndDateTime;
                product.ProductInformation = model.ProductInformation;
                product.Description = model.Description;
                product.ProductServingContent = model.ProductServingContent == null ? 0 : model.ProductServingContent;
                product.ProductServingTypeID = model.ProductServingTypeID;
                product.ProductStatusID = model.ProductStatusID;
                product.CategoryID = model.CategoryID;

                product.ProductUpdateDate = DateTime.Now;
                
                if (model.Image != null) {
                    string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "products",product.ImageUrl);
                    System.IO.File.Delete(filePath);
                    product.ImageUrl = ProcessUploadedFile(model.Image);
                }

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

            ViewData["CategoryID"] = new SelectList(_context.Category, "CategoryID", "CategoryName", model.CategoryID);
            ViewData["ProductStatusID"] = new SelectList(_context.Set<ProductStatus>(), "ProductStatusID", "ProductStatusName", model.ProductStatusID);
            //ViewData["RewardPoolID"] = new SelectList(_context.Set<RewardPool>(), "RewardPoolID", "RewardPoolID", product.RewardPoolID);
            ViewData["ProductServingTypeID"] = new SelectList(_context.Set<ProductServingType>(), "ProductServingTypeID", "ServingType", model.ProductServingTypeID);
            return View(model);
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
            if(!(product.ProductStock <= 0))
            {
                TempData["DeleteMessage"] = "There are still some stock in inventory, Unable to delete item";
                return RedirectToAction("Delete");
            }

            _context.Product.Remove(product);
            await _context.SaveChangesAsync();

            string filePath = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "products", product.ImageUrl);
            System.IO.File.Delete(filePath);

            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }
    }
}
