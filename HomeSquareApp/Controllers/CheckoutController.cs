using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;

        public CheckoutController(AppDbContext context, 
                                    SignInManager<ApplicationUser> signInManager,
                                     UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._SignInManager = signInManager;
            this._UserManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
