using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class OrderDetails
    {
        [Key]
        public int OrderDetailsID { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [Display(Name = "Total Price")]
        public double TotalPrice { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string OrderID { get; set; }

        public Order Order { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
