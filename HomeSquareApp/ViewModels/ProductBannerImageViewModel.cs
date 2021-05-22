using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ProductBannerImageViewModel
    {
        public int BannerID { get; set; }

        [Required]
        [Display(Name = "Image")]
        public IFormFile ProductBannerImage { get; set; }

        public BannerStatus BannerStatus { get; set; }

        public string ExistingImageUrl { get; set; }

        public List<BannerImages> BannerImages { get; set; }
    }
}
