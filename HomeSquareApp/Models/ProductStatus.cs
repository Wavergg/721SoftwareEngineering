using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class ProductStatus
    {
        [Key]
        public int ProductStatusID { get; set; }

        [Column(TypeName="varchar(16)")]
        [Required]
        [Display(Name ="Product Status Name")]
        public string ProductStatusName { get; set; }
    }
}
