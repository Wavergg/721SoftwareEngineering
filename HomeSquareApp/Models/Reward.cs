using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Reward
    {
        [Key]
        public int RewardID { get; set; }

        [Column(TypeName ="varchar(8)")]
        public string RewardStatus { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        public int? OrderID { get; set; }

        public Order Order { get; set; }
    }
}
