using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class IngredientViewModel
    {
        [MaxLength(64)]
        public string ServingContent { get; set; }

        public string IngredientName { get; set; }

        public int ServingTypeID { get; set; }
    }
}
