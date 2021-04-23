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

        [Display(Name = "Product Stock Increment")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Value should be greater than or equal to 1")]
        public int? ProductIncrement { get; set; } = 0;

        public string ImageUrl { get; set; }

        
        public new IFormFile Image { get; set; }
    }
}
