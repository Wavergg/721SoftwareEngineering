using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }


        [MaxLength(64)]
        [Required]
        [Display(Name ="Category Name")]
        public string CategoryName { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
