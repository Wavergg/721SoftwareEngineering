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
        [Range(0.001, Double.MaxValue, ErrorMessage = "The Price Must be Greater than 0")]
        public double ProductPrice { get; set; }

        [Display(Name = "Stock")]
        public int? ProductStock { get; set; } 

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Field Cannot Be Empty")]
        //[Remote(action: "IsProductExist", controller: "AdminProduct")]
        public string ProductName { get; set; }

        [Required]
        public DateTime ProductAddedDate { get; set; }

        [Required]
        public DateTime ProductUpdateDate { get; set; }

        [Display(Name = "Discount")]
        public float? ProductDiscount { get; set; }
        [Required]
        public double PriceAfterDiscount { get; set; }
        public DateTime SaleStartDateTime { get; set; }
        public DateTime SaleEndDateTime { get; set; }

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
        [Range(0.001, float.MaxValue, ErrorMessage = "The Value Must be Greater than 0")]
        public float? ProductServingContent { get; set; }
       
        [Required]
        public int? ProductServingTypeID { get; set; }
        [Display(Name = "Serving Type")]
        public virtual ProductServingType ServingType { get; set; }

        [Required]
        public int? ProductStatusID { get; set; }
        [Display(Name = "Product Status")]
        public virtual ProductStatus ProductStatus { get; set; }

        [Required]
        public int? CategoryID { get; set; }
        [Display(Name = "Product Category")]
        public virtual Category Category { get; set; }

        public int? RewardPoolID { get; set; }
        [ForeignKey("RewardPoolID")]
        public virtual RewardPool RewardPool { get; set; }

        public IEnumerable<Review> Review { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }
    }
}
