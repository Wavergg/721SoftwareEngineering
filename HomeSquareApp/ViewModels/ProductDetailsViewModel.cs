using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ProductDetailsViewModel
    {
        public Product Product { get; set; }

        public ApplicationUser User { get; set; }

        public ReviewViewModel Review { get; set; }
    }
}
