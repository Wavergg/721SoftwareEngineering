using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Components
{
    public class ForgotPasswordFormViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ForgotPasswordViewModel viewModel = new ForgotPasswordViewModel();
            return View(viewModel);
        }
    }
}
