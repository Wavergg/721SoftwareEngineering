using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Recipe
    {
        [Key]
        public int RecipeID { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name ="Recipe Name")]
        public string RecipeName { get; set; }

        [Required]
        [MaxLength(512)]
        [Display(Name = "Recipe Description")]
        public string RecipeDescription { get; set; }

        [Required]
        public int Servings { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Prepare & Cook Time")]
        public string PrepareTime { get; set; }

        public int Likes { get; set; } = 0;

        public int RecipeApprovalStatusID { get; set; }
        public RecipeApprovalStatus RecipeApprovalStatus { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public ApplicationUser User { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<RecipeSteps> RecipeSteps { get; set; }
    }
}
