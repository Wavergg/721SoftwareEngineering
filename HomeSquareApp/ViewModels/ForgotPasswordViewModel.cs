using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(64)]
        [RegularExpression(
            pattern: @"^[a-zA-Z0-9\._\+\-]+@[a-zA-Z0-9\.\-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Invalid email address"
            )]
        public string Email { get; set; }
    }
}
