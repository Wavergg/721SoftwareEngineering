using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [MaxLength(64)]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [RegularExpression(
            pattern: @"^[a-zA-Z0-9\._\+\-]+@[a-zA-Z0-9\.\-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Invalid email address"
            )]
        public string Email { get; set; }

       
        [Required]
        [MaxLength(64, ErrorMessage = "First Name Field shouldnt exceed maximum Length of 64 characters")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Last Name Field shouldnt exceed maximum Length of 64 characters")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Address Field shouldnt exceed maximum Length of 128 characters")]
        public string Address { get; set; }

        [Required]
        [Display(Name ="Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            pattern: @"^[\+]?\(?[\+]?[0-9]{1,4}\)?[\- \.]?\(?[0-9]{2,4}[\-\. ]?[0-9]{2,4}[\-\. ]?[0-9]{0,6}?\)?$",
            ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        [RegularExpression(
            pattern: "^(?=.*[0-9])(?=.*[!@#$%^&*])[a-zA-Z0-9!@#$%^&*]{8,}$",
            ErrorMessage = "Password should contain atleast 8 characters, 1 alphanumeric character and 1 symbol")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and the confirmation did not match")]
        public string ConfirmPassword { get; set; }

        
    }
}
