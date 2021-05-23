using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class BannerImageViewModel
    {
        public int BannerID { get; set; }

        [Required]
        [Display(Name = "Image")]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public IFormFile BannerImage { get; set; }

        public string ExistingImageUrl { get; set; }

        public bool SetAsMainBanner { get; set; }

        public List<BannerImages> BannerImages { get; set; }
    }
}
