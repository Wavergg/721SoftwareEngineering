using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class UserProfileViewModel
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

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(256)]
        public string PictureUrl { get; set; }

        [MaxLength(18)]
        public string DisplayName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            pattern: @"^[\+]?\(?[\+]?[0-9]{1,4}\)?[\- \.]?\(?[0-9]{2,4}[\-\. ]?[0-9]{2,4}[\-\. ]?[0-9]{0,6}?\)?$",
            ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [MaxLength(128)]
        public string DeliveryAddress { get; set; }

        [MaxLength(16)]
        public string Suburb { get; set; }

        [MaxLength(8)]
        public string ZipCode { get; set; }

        [MaxLength(8)]
        public string Unit { get; set; }
    }
}
