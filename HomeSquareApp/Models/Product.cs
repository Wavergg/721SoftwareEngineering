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
        [Required]
        public double ProductPrice { get; set; }

        [Display(Name = "Stock")]
        public int ProductStock { get; set; } = 0;

        [MaxLength(128)]
        [Display(Name = "Product Name")]
        [Required]
        public string ProductName { get; set; }

        [Display(Name = "Discount")]
        public float ProductDiscount { get; set; } = 0;


        public int ReviewFiveStars { get; set; } = 0;
        public int ReviewFourStars { get; set; } = 0;
        public int ReviewThreeStars { get; set; } = 0;
        public int ReviewTwoStars { get; set; } = 0;
        public int ReviewOneStars { get; set; } = 0;

        public int Week5Purchase { get; set; } = 0;
        public int Week4Purchase { get; set; } = 0;
        public int Week3Purchase { get; set; } = 0;
        public int Week2Purchase { get; set; } = 0;
        public int Week1Purchase { get; set; } = 0;
        public int CurrentWeekPurchase { get; set; } = 0;

        [MaxLength(256)]
        public string ProductInformation { get; set; }

        [MaxLength(512)]
        public string Description { get; set; }

        [Required]
        public float ProductServingContent { get; set; }
        public int ProductServingTypeID { get; set; }
        public ProductServingType ServingType { get; set; }

        public int ProductStatusID { get; set; }
        public ProductStatus ProductStatus { get; set; }

        public int CategoryID { get; set; }
        public Category Category { get; set; }

        public int? RewardPoolID { get; set; }
        [ForeignKey("RewardPoolID")]
        public RewardPool RewardPool { get; set; }

        public IEnumerable<Review> Review { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public IEnumerable<OrderDetails> OrderDetails { get; set; }

       
    }
}
