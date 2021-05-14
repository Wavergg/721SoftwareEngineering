using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class ReviewViewModel
    {
        public string UserID { get; set; }

        public int ProductID { get; set; }

        [MaxLength(1024)]
        [Required]
        public string ReviewContent { get; set; }

        public int ReviewStars { get; set; }
    }
}
