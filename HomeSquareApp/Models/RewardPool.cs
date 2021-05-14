using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class RewardPool
    {
        [Key]
        public int RewardPoolID { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    }
}
