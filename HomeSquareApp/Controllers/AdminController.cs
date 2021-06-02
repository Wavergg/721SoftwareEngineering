using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly RoleManager<IdentityRole> _RoleManager;
        private readonly IHostingEnvironment _HostingEnvironment;
        private static List<Order> _ordersContext;

        public AdminController(AppDbContext context, UserManager<ApplicationUser> userManager ,
                                RoleManager<IdentityRole> roleManager, IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._UserManager = userManager;
            this._RoleManager = roleManager;
            this._HostingEnvironment = hostingEnvironment;
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

            return PartialView("_AdminOrderTableDataPartial", _ordersContext);
        }

        public async Task<IActionResult> Index()
        {
            _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus =="Preparing" || o.OrderStatus == "Ready").OrderByDescending(o=>o.OrderDateTime).ToListAsync();

           
            int dayOfWeek = ((int)DateTime.Now.DayOfWeek) == 0 ? 7 : (int)DateTime.Now.DayOfWeek;
            var previous1WeekSunday = @DateTime.Now.AddDays(-(dayOfWeek));

            List<ApplicationUser> users = _context.ApplicationUser
                                        .Where(u => u.AccountCreatedDate > previous1WeekSunday && u.EmailConfirmed).ToList();

            double totalOrderThisWeek = _context.Order.Where(o => o.OrderDateTime > previous1WeekSunday && (o.OrderStatus != "Ongoing" && o.OrderStatus != "Deleted")).Sum(o => o.OrderTotal);


            int customerCount = 0;

            foreach(ApplicationUser user in users)
            {
                bool isCustomer = await _UserManager.IsInRoleAsync(user,"CUSTOMER");
                if (isCustomer)
                {
                    customerCount++;
                }
            }
            
            AdminDashboardViewModel model = new AdminDashboardViewModel() {
                Orders = _ordersContext,
                NewUserCount = customerCount,
                TotalOrderThisWeek = totalOrderThisWeek,
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult ProductBanner()
        {
            List<BannerImages> bannerProducts = _context.BannerImages.Where(b => b.BannerType == BannerType.Product).ToList();

            BannerImageViewModel model = new BannerImageViewModel();
            model.BannerImages = bannerProducts;
            model.SetAsMainBanner = true;

            BannerImages currentBanner = bannerProducts.Where(bp => bp.BannerStatus == BannerStatus.Active).FirstOrDefault();
            
            if(currentBanner!= null)
            {
                model.ExistingImageUrl = currentBanner.BannerUrl;
            }

            ViewData["ExistingBanners"] = new SelectList(bannerProducts, "BannerUrl", "BannerName");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProductBanner([Bind("BannerImage", "SetAsMainBanner")]BannerImageViewModel model)
        {
            BannerImages banner = new BannerImages();
            

            if (ModelState.IsValid)
            {
                banner.BannerUrl = ProcessUploadedFile(model.BannerImage);
                banner.BannerType = BannerType.Product;
                banner.BannerStatus = model.SetAsMainBanner? BannerStatus.Active : BannerStatus.Inactive;
                banner.BannerName = model.BannerImage.FileName;

                if (banner.BannerStatus == BannerStatus.Active)
                {
                    List<BannerImages> existingBanners = _context.BannerImages.Where(b => b.BannerType == BannerType.Product).ToList();
                    

                    if(existingBanners.Count > 0) {
                        existingBanners.ForEach(b => b.BannerStatus = BannerStatus.Inactive);
                        foreach (BannerImages images in existingBanners)
                        {
                            _context.Update(images);
                        }
                    }
                }

                _context.Add(banner);
                _context.SaveChanges();

                TempData["  Message"] = "Succesfully Added Product Banner";
            } else
            {
                TempData["ErrorMessage"] = "Failed to Add Product Banner";
            }
            return RedirectToAction("ProductBanner");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeProductBanner([Bind("ExistingImageUrl")]BannerImageViewModel model)
        {
            if(!string.IsNullOrEmpty(model.ExistingImageUrl))
            {
                BannerImages bannerSelected = _context.BannerImages.Where(bi => bi.BannerUrl == model.ExistingImageUrl).FirstOrDefault();

                if(bannerSelected != null) {
                    List<BannerImages> existingBanners = _context.BannerImages.Where(b => b.BannerType == BannerType.Product).ToList();

                    if (existingBanners.Count > 0)
                    {
                        existingBanners.ForEach(b => b.BannerStatus = BannerStatus.Inactive);
                        foreach(BannerImages images in existingBanners)
                        {
                            _context.Update(images);
                        }
                    }

                    bannerSelected.BannerStatus = BannerStatus.Active;
                    _context.Update(bannerSelected);

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Succesfully Editing Product Banner";
                    return RedirectToAction("ProductBanner");
                }
            }
            TempData["ErrorMessage"] = "Failed to Edit Product Banner";
            return RedirectToAction("ProductBanner");
        }

        [HttpGet]
        public IActionResult RecipeBanner()
        {
            List<BannerImages> bannerRecipes = _context.BannerImages.Where(b => b.BannerType == BannerType.Recipe).ToList();

            BannerImageViewModel model = new BannerImageViewModel();
            model.BannerImages = bannerRecipes;
            model.SetAsMainBanner = true;

            BannerImages currentBanner = bannerRecipes.Where(bp => bp.BannerStatus == BannerStatus.Active).FirstOrDefault();

            if (currentBanner != null)
            {
                model.ExistingImageUrl = currentBanner.BannerUrl;
            }

            ViewData["ExistingBanners"] = new SelectList(bannerRecipes, "BannerUrl", "BannerName");

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddRecipeBanner([Bind("BannerImage", "SetAsMainBanner")] BannerImageViewModel model)
        {
            BannerImages banner = new BannerImages();


            if (ModelState.IsValid)
            {
                banner.BannerUrl = ProcessUploadedFile(model.BannerImage);
                banner.BannerType = BannerType.Recipe;
                banner.BannerStatus = model.SetAsMainBanner ? BannerStatus.Active : BannerStatus.Inactive;
                banner.BannerName = model.BannerImage.FileName;

                if (banner.BannerStatus == BannerStatus.Active)
                {
                    List<BannerImages> existingBanners = _context.BannerImages.Where(b => b.BannerType == BannerType.Recipe).ToList();


                    if (existingBanners.Count > 0)
                    {
                        existingBanners.ForEach(b => b.BannerStatus = BannerStatus.Inactive);
                        foreach (BannerImages images in existingBanners)
                        {
                            _context.Update(images);
                        }
                    }
                }

                _context.Add(banner);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Succesfully Added Recipe Banner";
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to Add Recipe Banner";
            }
            return RedirectToAction("RecipeBanner");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ChangeRecipeBanner([Bind("ExistingImageUrl")] BannerImageViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ExistingImageUrl))
            {
                BannerImages bannerSelected = _context.BannerImages.Where(bi => bi.BannerUrl == model.ExistingImageUrl).FirstOrDefault();

                if (bannerSelected != null)
                {
                    List<BannerImages> existingBanners = _context.BannerImages.Where(b => b.BannerType == BannerType.Recipe).ToList();

                    if (existingBanners.Count > 0)
                    {
                        existingBanners.ForEach(b => b.BannerStatus = BannerStatus.Inactive);
                        foreach (BannerImages images in existingBanners)
                        {
                            _context.Update(images);
                        }
                    }

                    bannerSelected.BannerStatus = BannerStatus.Active;
                    _context.Update(bannerSelected);

                    _context.SaveChanges();
                    TempData["SuccessMessage"] = "Succesfully Editing Recipe Banner";
                    return RedirectToAction("RecipeBanner");
                }
            }
            TempData["ErrorMessage"] = "Failed to Edit Recipe Banner";
            return RedirectToAction("RecipeBanner");
        }

        private string ProcessUploadedFile(IFormFile Image)
        {
            string uniqueFileName = "";

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "banner");
            uniqueFileName = Guid.NewGuid().ToString() + "_" + Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                Image.CopyTo(fileStream);
            }
            return uniqueFileName;
        }

        //[AllowAnonymous]
        //public async Task<IActionResult> Index()
        //{
        //    List<IdentityRole> identityRoles = new List<IdentityRole>();

        //    IdentityRole identityRoleAdmin = new IdentityRole()
        //    {
        //        Name = "ADMIN",
        //    };

        //    IdentityRole identityRoleCustomer = new IdentityRole()
        //    {
        //        Name = "CUSTOMER",
        //    };
        //    identityRoles.Add(identityRoleCustomer);
        //    identityRoles.Add(identityRoleAdmin);

        //    foreach (IdentityRole role in identityRoles)
        //    {
        //        await _RoleManager.CreateAsync(role);
        //    }
        //    return Json(true);
        //}
    }
}
