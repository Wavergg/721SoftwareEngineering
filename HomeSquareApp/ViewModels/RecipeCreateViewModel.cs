using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class RecipeCreateViewModel
    {

        [Required]
        [MaxLength(64)]
        [Display(Name = "Recipe Name")]
        public string RecipeName { get; set; }

        [Required]
        [MaxLength(512)]
        [Display(Name = "Description")]
        public string RecipeDescription { get; set; }

        [Required]
        [Range(1,int.MaxValue)]
        public int Servings { get; set; }

        [Required]
        [MaxLength(64)]
        [Display(Name = "Prepare & Cook Time")]
        public string PrepareTime { get; set; }

        [Required]
        public string UserID { get; set; }

        public string FirstName { get; set; }

        [Required]
        [AllowedExtensions(new string[] { ".jpg", ".jpeg", ".png" })]
        public virtual IFormFile Image { get; set; }

        public List<IngredientViewModel> Ingredients { get; set; } = new List<IngredientViewModel>();

        public List<RecipeSteps> RecipeSteps { get; set; } = new List<RecipeSteps>();
    }
}
