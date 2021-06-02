using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class AdminProductCreateViewModel
    {
        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Required(ErrorMessage = "Price Field Cannot Be Empty")]
        [Range(0.001, Double.MaxValue, ErrorMessage = "The Price Must be Greater than 0")]
        public double ProductPrice { get; set; }

        [Display(Name = "Stock")]
        public int? ProductStock { get; set; } = 0;

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Name Field Cannot Be Empty")]
        [Remote(action: "IsProductExist", controller: "AdminProduct")]
        public virtual string ProductName { get; set; }

        [Display(Name = "Discount")]
        [Range(0,1,ErrorMessage = "Discount Range should be from 0 to 1")]
        public float? ProductDiscount { get; set; }

        [Required]
        public double PriceAfterDiscount { get; set; }

        [Display(Name = "Sale Start Date-Time")]
        public DateTime SaleStartDateTime { get; set; }

        [Display(Name = "Sale End Date-Time")]
        public DateTime SaleEndDateTime { get; set; }

        [Required(ErrorMessage = "Please Provide Image For The Product")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png", ".gif", ".tiff" })]
        public virtual IFormFile Image { get; set; }

        [MaxLength(256)]
        [Display(Name = "Product Information")]
        public string ProductInformation { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Serving Content Field Cannot Be Empty")]
        [Display(Name = "Serving Content")]
        [Range(0.001, float.MaxValue, ErrorMessage = "The Value Must be Greater than 0")]
        public float? ProductServingContent { get; set; }

        [Display(Name = "Serving Type")]
        [Required]
        public int? ProductServingTypeID { get; set; }
        public virtual ProductServingType ServingType { get; set; }

        [Display(Name = "Product Status")]
        [Required]
        public int? ProductStatusID { get; set; }
        public virtual ProductStatus ProductStatus { get; set; }

        [Display(Name = "Product Category")]
        [Required]
        public int? CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
