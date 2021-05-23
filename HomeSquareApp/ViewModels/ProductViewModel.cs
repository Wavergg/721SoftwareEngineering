using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ProductViewModel
    {

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }

        public string ProductBannerUrl { get; set; }
    }
}
