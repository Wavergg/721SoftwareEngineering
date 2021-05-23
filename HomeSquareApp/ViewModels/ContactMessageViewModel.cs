using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ContactMessageViewModel
    {
        [Required]
        [MaxLength(64)]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [RegularExpression(
            pattern: @"^[a-zA-Z0-9\._\+\-]+@[a-zA-Z0-9\.\-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Invalid Email Address"
            )]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            pattern: @"^[\+]?\(?[\+]?[0-9]{1,4}\)?[\- \.]?\(?[0-9]{2,4}[\-\. ]?[0-9]{2,4}[\-\. ]?[0-9]{0,6}?\)?$",
            ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [MinLength(10,ErrorMessage = "Message should contains atleast 10 characters")]
        [Required]
        public string Message { get; set; }
    }
}
