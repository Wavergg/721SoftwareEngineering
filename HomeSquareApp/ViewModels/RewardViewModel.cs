using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class RewardViewModel
    {
        public ApplicationUser CurrentUser { get; set; }
        public List<Reward> Rewards { get; set; }
    }
}
