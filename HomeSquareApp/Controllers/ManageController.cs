using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public ManageController(UserManager<ApplicationUser> userManager)
        {
            this._UserManager = userManager;
        }

        public IActionResult Index(string pageName)
        {
            ViewData["PageName"] = pageName;

            if (pageName == "AccountInformation") {
                ViewData["Active"] = "MyAccountLink";
            } 
            else if(pageName == "MyOrders")
            {
                ViewData["Active"] = "MyOrdersLink";
            } else if(pageName == "MyRewards")
            {
                ViewData["Active"] = "MyRewardsLink";
            }
            return View();
        }

        public async Task<ActionResult> AccountInformation()
        {
            var user = await _UserManager.FindByNameAsync(User.Identity.Name);
            
            UserProfileViewModel model = new UserProfileViewModel();
            model.Address = user.Address;
            model.Email = user.Email;
            model.FirstName = user.FirstName;
            model.LastName = user.LastName;
            model.PhoneNumber = user.PhoneNumber;
            model.PictureUrl = user.PictureUrl;
            model.DisplayName = user.DisplayName;

            model.DeliveryAddress = user.DeliveryAddress;
            model.Suburb = user.Suburb;
            model.ZipCode = user.ZipCode;
            model.Unit = user.Unit;

            return PartialView("_ManageAccountInformationPartial",model);
        }

        public ActionResult MyOrders()
        {
            return PartialView("_ManageMyOrdersPartial");
        }
    }
}
