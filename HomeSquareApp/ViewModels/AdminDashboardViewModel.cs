using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class AdminDashboardViewModel
    {
        public List<Order> Orders { get; set; }

        public int NewUserCount { get; set; }
    }
}
