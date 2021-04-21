using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Ingredient
    {
        [Key]
        public int IngredientID { get; set; }
        
        public int Quantity { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int RecipeID { get; set; }
        public Recipe Recipe { get; set; }
    }
}
