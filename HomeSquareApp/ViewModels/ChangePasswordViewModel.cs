using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(64)]
        [RegularExpression(
            pattern: @"^[a-zA-Z0-9\._\+\-]+@[a-zA-Z0-9\.\-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Invalid email address"
            )]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current Password")]
        [RegularExpression(
            pattern: "^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$",
            ErrorMessage = "Password should contain atleast 8 characters, 1 alphanumeric character and 1 symbol")]
        public string CurrentPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password should be atleast 8 characters in length")]
        [Display(Name = "New Password")]
        [RegularExpression(
            pattern: "^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$",
            ErrorMessage = "Password should contain atleast 8 characters, 1 alphanumeric character and 1 symbol")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm New Password")]
        [Compare("NewPassword", ErrorMessage = "Password and the confirmation did not match")]
        public string ConfirmNewPassword { get; set; }
    }
}
