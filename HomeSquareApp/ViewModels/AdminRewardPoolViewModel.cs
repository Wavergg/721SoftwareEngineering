using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class AdminRewardPoolViewModel
    {
        public int ProductID { get; set; }
        public Product Product { get; set; }

        [Display(Name = "Pool Quantity")]
        [Range(0, int.MaxValue,ErrorMessage = "Invalid Quantity")]
        [Required(ErrorMessage = "Invalid Quantity")]
        public int PoolQuantity { get; set; }

        [Display(Name ="Product Name")]
        public string ProductName { get; set; }
    }
}
