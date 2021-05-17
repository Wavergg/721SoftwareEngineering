using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ManageUserProfileViewModel
    {
        [Required]
        public string UserID { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            pattern: @"^[\+]?\(?[\+]?[0-9]{1,4}\)?[\- \.]?\(?[0-9]{2,4}[\-\. ]?[0-9]{2,4}[\-\. ]?[0-9]{0,6}?\)?$",
            ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "First Name Field shouldnt exceed maximum Length of 64 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Last Name Field shouldnt exceed maximum Length of 64 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Address Name Field shouldnt exceed maximum Length of 128 characters")]
        public string Address { get; set; }

        [MaxLength(32, ErrorMessage = "Suburb Field shouldnt exceed maximum Length of 32 characters")]
        public string Suburb { get; set; }

        [MaxLength(8, ErrorMessage = "Zip Code Field shouldnt exceed maximum Length of 64 characters")]
        public string ZipCode { get; set; }

        [MaxLength(8, ErrorMessage = "Unit Field shouldnt exceed maximum Length of 64 characters")]
        public string Unit { get; set; }

        [MaxLength(256)]
        public string PictureUrl { get; set; }

        [Display(Name = "Profile Image")]
        public IFormFile Image { get; set; }
    }
}
