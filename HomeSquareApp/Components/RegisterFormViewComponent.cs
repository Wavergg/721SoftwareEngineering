using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class RegisterFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            RegisterViewModel viewModel = new RegisterViewModel();
            return View(viewModel);
        }
    }
}
