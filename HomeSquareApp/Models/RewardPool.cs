using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public enum RewardPoolStatus
    {
        Ongoing,
        Deleted
    }

    public class RewardPool
    {
        [Key]
        public int RewardPoolID { get; set; }
       

        [Display(Name = "Pool Quantity")]
        [Range(0,int.MaxValue)]
        public int PoolQuantity { get; set; }

        public int ProductID { get; set; }
        [ForeignKey("ProductID")]
        public Product Product { get; set; }

        public RewardPoolStatus RewardPoolStatus { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    }
}
