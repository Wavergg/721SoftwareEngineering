using HomeSquareApp.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.ViewModels
{
    public class AdminRecipeEditViewModel : RecipeCreateViewModel
    {
        public int RecipeID { get; set; }
        public string ExistingImageUrl { get; set; }
        public string ExistingImagePath { get; set; }
        public RecipeApprovalStatus RecipeStatus { get; set; }
        public new IFormFile Image { get; set; }
    }
}
