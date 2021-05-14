using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class RecipeUserLike
    {
        [Key]
        public int RecipeUserLikeID { get; set; }

        [Required]
        public string UserID { get; set; }

        public ApplicationUser User { get; set; }
        [Required]
        public int RecipeID { get; set; }

        public Recipe Recipe { get; set; }
    }
}
