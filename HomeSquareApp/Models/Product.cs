using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Price")]
        [Required(ErrorMessage="Field Cannot Be Empty")]
        public double ProductPrice { get; set; }

        [Display(Name = "Stock")]
        public int? ProductStock { get; set; } = 0;

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        //[Remote(action: "IsProductExist", controller: "AdminProduct")]
        public string ProductName { get; set; }

        [Required]
        public DateTime ProductUpdateDate { get; set; }

        [Display(Name = "Discount")]
        public float? ProductDiscount { get; set; } = 0;

        [Required]
        public string ImageUrl { get; set; }


        public int ReviewFiveStarsCount { get; set; } = 0;
        public int ReviewFourStarsCount { get; set; } = 0;
        public int ReviewThreeStarsCount { get; set; } = 0;
        public int ReviewTwoStarsCount { get; set; } = 0;
        public int ReviewOneStarsCount { get; set; } = 0;

        public int Week5PurchaseCount { get; set; } = 0;
        public int Week4PurchaseCount { get; set; } = 0;
        public int Week3PurchaseCount { get; set; } = 0;
        public int Week2PurchaseCount { get; set; } = 0;
        public int Week1PurchaseCount { get; set; } = 0;
        [Display(Name ="Current Week Purchase")]
        public int CurrentWeekPurchaseCount { get; set; } = 0;

        [MaxLength(256)]
        [Display(Name = "Product Information")]
        public string ProductInformation { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required(ErrorMessage="Field Cannot Be Empty")]
        [Display(Name = "Serving Content")]
        public float ProductServingContent { get; set; }
       
        public int ProductServingTypeID { get; set; }
        [Display(Name = "Serving Type")]
        public ProductServingType ServingType { get; set; }

        
        public int ProductStatusID { get; set; }
        [Display(Name = "Product Status")]
        public ProductStatus ProductStatus { get; set; }

       
        public int CategoryID { get; set; }
        [Display(Name = "Product Category")]
        public Category Category { get; set; }

        public int? RewardPoolID { get; set; }
        [ForeignKey("RewardPoolID")]
        public RewardPool RewardPool { get; set; }

        public IEnumerable<Review> Review { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
