using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class HomeViewModel
    {
        public List<string> BannerUrls { get; set; }

        public List<Product> LatestProducts { get; set; }

        public List<Product> FeaturedProducts { get; set; }

        public List<Recipe> FeaturedRecipes { get; set; }
    }
}
