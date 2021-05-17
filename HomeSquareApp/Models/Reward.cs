using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public enum RewardStatus
    {
        Available,
        Claimed
    }

    public class Reward
    {
        [Key]
        public int RewardID { get; set; }

        [Display(Name = "Reward Status")]
        public RewardStatus RewardStatus { get; set; }

        [Display(Name = "Reward Grant Date")]
        public DateTime RewardAddedDateTime { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        public string OrderID { get; set; }

        public Order Order { get; set; }
    }
}
