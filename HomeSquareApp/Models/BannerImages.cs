using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public enum BannerType
    {
        Home,
        Product,
        Recipe
    }

    public enum BannerStatus
    {
        Inactive,
        Active
    }

    public class BannerImages
    {
        [Key]
        public int BannerImageID { get; set; }

        [MaxLength(256)]
        [Required]
        public string BannerUrl { get; set; }

        [MaxLength(256)]
        [Required]
        public string BannerName { get; set; }

        public BannerType BannerType { get; set; }

        public BannerStatus BannerStatus { get; set; }
    }
}
