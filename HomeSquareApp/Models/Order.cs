﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Order
    {
        [Key]
        [MaxLength(36)]
        public string OrderID { get; set; }

        public DateTime OrderDateTime { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        [MaxLength(9)]
        [Column(TypeName = "varchar(9)")]
        public string OrderStatus { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    }
}
