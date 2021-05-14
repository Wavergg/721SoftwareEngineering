using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class CartViewModel
    {
        public List<OrderDetails> OrderDetails { get; set; } = new List<OrderDetails>();

        public double TotalInCart { get; set; } = 0;
    }
}
