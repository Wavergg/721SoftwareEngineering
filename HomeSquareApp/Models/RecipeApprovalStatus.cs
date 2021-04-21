using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class RecipeApprovalStatus
    {
        [Key]
        public int RecipeApprovalStatusID { get; set; }

        [MaxLength(12)]
        public string ApprovalStatus { get; set; }
    }
}
