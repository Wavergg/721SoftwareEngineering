using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([Bind("Email,Password,ConfirmPassword,Token")] ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);
                if(user != null)
                {
                    var result = await _UserManager.ResetPasswordAsync(user, model.Token, model.Password);

                    //activate user account if email is not confirmed
                    if (!await _UserManager.IsEmailConfirmedAsync(user))
                    {
                        var emailConfirmationToken = await _UserManager.GenerateEmailConfirmationTokenAsync(user);
                        await _UserManager.ConfirmEmailAsync(user, emailConfirmationToken);
                    }

                    if (result.Succeeded)
                    {
                        //sign the user in after reset
                        await _SignInManager.SignInAsync(user, false);

                        TempData["ResetMessage"] = "Succesfully resetting your password";
                        return RedirectToAction("Index", "Home");
                    }
                    foreach( var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult ResetPassword(string Token, string Email)
        {
            if (Token == null || Email == null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword([Bind("Email")]ForgotPasswordViewModel model)
        {
            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;

            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);
                
                if(user != null )
                {
                    var token = await _UserManager.GeneratePasswordResetTokenAsync(user);

                    var passwordResetLink = 
                        Url.Action("ResetPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                    try { 
                        //SENDING EMAIL (REENABLE THIS LATER)
                        MailMessage message = new MailMessage("homesquare322@gmail.com", model.Email);
                        message.Subject = "Password Reset Link";
                        message.Body = "Hi we got your back, Click here to reset your account: \n" + passwordResetLink;
                        EmailController.SendEmail(message);
                    } catch
                    {
                        errorMsg.Message.Add("Failure in sending Email confirmation, Please try again.");
                    }
                }

                //i place it here so that people cant use this reset password for checking whether the email exist or not
                //prevent bruteforcing
                errorMsg.IsSuccess = true;
                errorMsg.Message.Add($"Email to reset your password has been sent to {model.Email}");
                return Json(errorMsg);
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

            foreach (string error in allErrors)
            {
                errorMsg.Message.Add($"{error}");
            }
            return Json(errorMsg);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail(string userID, string token)
        {
            if(userID == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await _UserManager.FindByIdAsync(userID);
            if(user != null)
            {
                var result = await _UserManager.ConfirmEmailAsync(user, token);

                if (result.Succeeded)
                {
                    ViewBag.ConfirmResult = true;
                    ViewBag.ConfirmMessage = "Thank you for confirming your email, Your account has been activated";
                    return View();
                }
            }
            ViewBag.ConfirmResult = false;
            ViewBag.ConfirmMessage = "Unable to locate the user or token is invalid";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password,RememberMe")] LogInViewModel model,string returnUrl)
        {
            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;

            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);

                if(user != null && !user.EmailConfirmed && (await _UserManager.CheckPasswordAsync(user,model.Password)))
                {
                    errorMsg.Message.Add("Email not confirmed yet");
                    return Json(errorMsg);
                }

                var result = await _SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe,false);

                if (result.Succeeded)
                {
                    errorMsg.IsSuccess = true;
                    //prevent openredirect atk by checking localurl
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        if (await _UserManager.IsInRoleAsync(user,"ADMIN")) { 
                            //REDIRECT TO ADMIN PAGE
                        } else
                        {
                            //Pass In URL into the json obj and let js handle the redirect
                            errorMsg.UrlRedirect = returnUrl;
                        }
                    } else
                    {
                        //This will produce '/'
                        errorMsg.UrlRedirect = Url.Action("Index", "Home");
                    }
                    return Json(errorMsg);
                }
            }

            errorMsg.Message.Add("Invalid Login Attempt");
            return Json(errorMsg);
        }


        public async Task<IActionResult> Logout()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Register([Bind("Email,FirstName,LastName,Address,PhoneNumber,ConfirmPassword,Password")] RegisterViewModel model)
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
                        //GENERATE EMAIL GENERATION TOKEN
                        var token = await _UserManager.GenerateEmailConfirmationTokenAsync(user);

                        var confirmationLink = 
                            Url.Action("ConfirmEmail", "Account", new { userID = user.Id, token = token }, Request.Scheme);

                        //SENDING EMAIL (REENABLE THIS LATER)
                        MailMessage message = new MailMessage("homesquare322@gmail.com", model.Email);
                        message.Subject = "Confirm your E-mail registration - HomeSquare";
                        message.Body = "Thank you for registering with us, Click here to activate your account: \n" + confirmationLink;
                        EmailController.SendEmail(message);

                        errorMsg.IsSuccess = true;
                        errorMsg.Message.Add($"Registration Successful - To activate your account, please visit on the link that has been sent to {model.Email}");

                        await _UserManager.AddToRoleAsync(user, "CUSTOMER");
                    }
                    catch 
                    {
                        await _UserManager.DeleteAsync(user);
                        errorMsg.Message.Add("Failure in sending Email confirmation, Please try again.");
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
