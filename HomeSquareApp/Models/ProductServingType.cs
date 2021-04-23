using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class ProductServingType
    {
        [Key]
        public int ProductServingTypeID { get; set; }
        [MaxLength(10)]
        [Column(TypeName ="varchar(16)")]
        [Required]
        [Display(Name = "Product Serving Type")]
        public string ServingType { get; set; }
    }
}
