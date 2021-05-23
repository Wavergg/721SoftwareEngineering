using HomeSquareApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class RecipeViewModel
    {
        public List<Recipe> Recipes { get; set; }

        public string RecipeBannerImageUrl { get; set; }
    }
}
