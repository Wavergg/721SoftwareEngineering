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
        public string ReviewContent { get; set; }

        [Range(1,5,ErrorMessage = "Select Amount of Stars for Product Review")]
        public int ReviewStars { get; set; }
    }
}
