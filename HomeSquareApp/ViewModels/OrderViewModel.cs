using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class OrderViewModel
    {
        [Required]
        public string OrderID { get; set; }

        [MaxLength(8)]
        public string DeliveryOptions { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "First Name Shouldn't Exceed 64 Characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Last Name Shouldn't Exceed 64 Characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Email Shouldn't Exceed 64 Characters")]
        [EmailAddress]
        [RegularExpression(
            pattern: @"^[a-zA-Z0-9\._\+\-]+@[a-zA-Z0-9\.\-]+\.[A-Za-z]{2,4}$",
            ErrorMessage = "Invalid email address"
            )]
        [Display(Name = "Email")]
        public string DeliveryEmail { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(
            pattern: @"^[\+]?\(?[\+]?[0-9]{1,4}\)?[\- \.]?\(?[0-9]{2,4}[\-\. ]?[0-9]{2,4}[\-\. ]?[0-9]{0,6}?\)?$",
            ErrorMessage = "Not a valid Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(128, ErrorMessage = "Address Field shouldnt exceed maximum Length of 128 Characters")]
        [Display(Name = "Delivery Address")]
        public string DeliveryAddress { get; set; }

        [MaxLength(32, ErrorMessage = "Suburb Shouldn't Exceed 32 Characters")]
        public string Suburb { get; set; }

        [MaxLength(8, ErrorMessage = "Zip Shouldn't Exceed 8 Characters")]
        public string ZipCode { get; set; }


        [MaxLength(8, ErrorMessage = "Unit # Shouldn't Exceed 8 Characters")]
        public string Unit { get; set; }

        [Required]
        [MaxLength(64, ErrorMessage = "Field Shouldn't Exceed 64 Characters")]
        [Display(Name = "Name on Card")]
        public string NameOnCard { get; set; }

        [Required]
        [MinLength(16, ErrorMessage = "Credit Card Number Shouldn't Be Less Than 16 Characters")]
        [MaxLength(19, ErrorMessage = "Credit Card Number Shouldn't Exceed 19 Characters")]
        [Display(Name = "Credit Card Number")]
        public string CreditCardNumber { get; set; }

        [Required]
        [Display(Name = "Expiry Month")]
        [Range(2,2, ErrorMessage = "Should be in MM format")]
        [RegularExpression(
            pattern: @"^(0?[1-9]|1[012])$",
            ErrorMessage = "Not a valid month")]
        public string ExpiryMonth { get; set; }

        [Required]
        [Display(Name = "Expiry Year")]
        [Range( 2 , 2, ErrorMessage = "Should be in YY format")]
        public string ExpiryYear { get; set; }

        [Required]
        [Display(Name = "CVV")]
        [StringLength(maximumLength: 3,MinimumLength = 3,ErrorMessage = "Should be 3 Digit")]
        public string CVV { get; set; }
    }
}
