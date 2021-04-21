using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class RecipeSteps
    {
        [Key]
        public int StepsID { get; set; }

        [MaxLength(256)]
        [Required]
        public string Steps { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
