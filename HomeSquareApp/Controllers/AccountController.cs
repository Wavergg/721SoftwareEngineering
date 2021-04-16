using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            this._UserManager = userManager;
            this._SignInManager = signInManager;
        }

        [AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await _UserManager.FindByEmailAsync(email);
            if(user == null)
            {
                return Json(true);
            }
            return Json("Email is already in use");
        }

       

        [HttpPost]
        public async Task<JsonResult> Register(RegisterViewModel model)
        {
            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;

            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber,
                };

                var result = await _UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    try {
                        //REENABLE THIS LATER 
                        EmailController.SendEmail(model.Email);

                        errorMsg.IsSuccess = true;
                        errorMsg.Message.Add($"Email verification has been sent to {model.Email}");
                    }
                    catch 
                    {
                        await _UserManager.DeleteAsync(user);
                        errorMsg.Message.Add($"Failure in sending Email confirmation, Please try again.");
                    }
                    return Json(errorMsg);
                }

               
                foreach(var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName") continue;
                    errorMsg.Message.Add($"{error.Description}");
                }
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

            foreach(string error in allErrors)
            {
                errorMsg.Message.Add($"{error}");
            }
            return Json(errorMsg);
        }
    }
}
