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
    public class AdminProductEditViewModel : AdminProductCreateViewModel
    {
        public int ProductID { get; set; }

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        [Remote(action: "IsProductExist", controller: "AdminProduct",AdditionalFields = "ProductOldName")]
        public new string ProductName { get; set; }

        public string ProductOldName { get; set; }

        [Display(Name = "Product Stock Increment")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int? ProductIncrement { get; set; } 

        public string ImageUrl { get; set; }

        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public new IFormFile Image { get; set; }
    }
}
