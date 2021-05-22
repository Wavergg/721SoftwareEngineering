using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

        public AdminController(AppDbContext context, UserManager<ApplicationUser> userManager ,
                                RoleManager<IdentityRole> roleManager, IHostingEnvironment hostingEnvironment)
        {
            this._context = context;
            this._UserManager = userManager;
            this._RoleManager = roleManager;
            this._HostingEnvironment = hostingEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            List<Order> _ordersContext = await _context.Order.Include(u => u.User)
                            .Where(o => o.OrderStatus =="Preparing" || o.OrderStatus == "Ready").ToListAsync();


            int dayOfWeek = ((int)DateTime.Now.DayOfWeek) == 0 ? 7 : (int)DateTime.Now.DayOfWeek;
            var previous1WeekSunday = @DateTime.Now.AddDays(-(dayOfWeek));

            List<ApplicationUser> users = _context.ApplicationUser
                                        .Where(u => u.AccountCreatedDate > previous1WeekSunday && u.EmailConfirmed).ToList();

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
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult EditProductBanner()
        {
            List<BannerImages> bannerProducts = _context.BannerImages.Where(b => b.BannerType == BannerType.Product).ToList();

            ProductBannerImageViewModel model = new ProductBannerImageViewModel()
            {
                BannerImages = bannerProducts,
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProductBanner([Bind("ProductBannerImage")]ProductBannerImageViewModel model)
        {
            BannerImages banner = new BannerImages();
            if(banner == null)
            {
                ModelState.AddModelError("","Unable to Update Existing Banner Please Refresh the Page and Try Again");
            }

            if (ModelState.IsValid)
            {
                banner.BannerUrl = ProcessUploadedFile(model.ProductBannerImage);
                banner.BannerType = BannerType.Product;
                banner.BannerStatus = model.BannerStatus;

                if(banner.BannerStatus == BannerStatus.Active)
                {
                    List<BannerImages> existingBanners = _context.BannerImages.Where(b => b.BannerType == BannerType.Product).ToList();
                    existingBanners.ForEach(b => b.BannerStatus = BannerStatus.Inactive);

                    _context.Update(existingBanners);
                }

                _context.Add(banner);
                _context.SaveChanges();

                TempData["Message"] = "Succesfully Added Product Banner";
            }
            return View(model);
        }

        private string ProcessUploadedFile(IFormFile Image)
        {
            string uniqueFileName = "";

            string uploadsFolder = Path.Combine(_HostingEnvironment.WebRootPath, "lib", "images", "products");
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
