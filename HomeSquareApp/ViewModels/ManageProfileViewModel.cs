using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ManageProfileViewModel
    {
        public ChangePasswordViewModel ChangePasswordViewModel { get; set; }

        public ManageUserProfileViewModel User { get; set; }
    }
}
