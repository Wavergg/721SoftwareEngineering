using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [MaxLength(1024)]
        [Required]
        public string ReviewContent { get; set; }

        public int ReviewStars { get; set; }

        public DateTime ReviewDateTime { get; set; }

        public string UserID { get; set; }

        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        public int ProductID { get; set; }

        public Product Product { get; set; }
    }
}
