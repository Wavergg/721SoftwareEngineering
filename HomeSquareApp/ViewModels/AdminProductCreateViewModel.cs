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
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        public double ProductPrice { get; set; }

        [Display(Name = "Stock")]
        public int? ProductStock { get; set; } = 0;

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        [Remote(action: "IsProductExist", controller: "AdminProduct")]
        public string ProductName { get; set; }

        [Display(Name = "Discount")]
        public float? ProductDiscount { get; set; } = 0;

        [Required(ErrorMessage = "Please Provide Image For The Product")]
        public virtual IFormFile Image { get; set; }

        [MaxLength(256)]
        [Display(Name = "Product Information")]
        public string ProductInformation { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Field Cannot Be Empty")]
        [Display(Name = "Serving Content")]
        public float ProductServingContent { get; set; }
        public int ProductServingTypeID { get; set; }
        public ProductServingType ServingType { get; set; }

        [Display(Name = "Product Status")]
        public int ProductStatusID { get; set; }
        public ProductStatus ProductStatus { get; set; }

        [Display(Name = "Product Category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
