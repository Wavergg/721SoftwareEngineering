using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class AccountProfileSettingsViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _UserManager;

        public AccountProfileSettingsViewComponent(UserManager<ApplicationUser> userManager)
        {
            this._UserManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ManageProfileViewModel model = new ManageProfileViewModel();
            ApplicationUser user = await _UserManager.GetUserAsync(UserClaimsPrincipal);

            model.User = new ManageUserProfileViewModel()
            {
                UserID = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                PictureUrl = user.PictureUrl,
                PhoneNumber = user.PhoneNumber,
                Address = user.Address,
                Email = user.Email,
                Suburb = user.Suburb,
                ZipCode = user.ZipCode,
                Unit = user.Unit,
            };

            model.ChangePasswordViewModel = new ChangePasswordViewModel();

            return View(model);
        }
    }
}
