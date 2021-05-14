using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _RoleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            this._RoleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
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
