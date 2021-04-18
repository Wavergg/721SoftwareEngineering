using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class LogInFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            LogInViewModel viewModel = new LogInViewModel();
            return View(viewModel);
        }
    }
}
