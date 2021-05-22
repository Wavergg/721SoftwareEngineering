using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class OurStoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
