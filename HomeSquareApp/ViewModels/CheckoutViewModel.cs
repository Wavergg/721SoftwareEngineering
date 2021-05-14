using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class CheckoutViewModel
    {
        public OrderViewModel OrderViewModel { get; set; }

        public Order Order { get; set; }
    }
}
