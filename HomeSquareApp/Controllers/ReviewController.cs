using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class ReviewController : Controller
    {
        private readonly AppDbContext _context;

        public ReviewController(AppDbContext context)
        {
            this._context = context;
        }

        [HttpPost]
        public IActionResult RefreshReview(int productID)
        {
            List<Review> reviews = _context.Review.Where(r => r.ProductID == productID)
                            .OrderByDescending(r => r.ReviewDateTime)
                            .Include(r => r.User).ToList();

            return PartialView("_ReviewsListPartial", reviews);
        }

        public IActionResult RefreshRating(int productID)
        {
            Product product = _context.Product.Where(p => p.ProductID == productID).FirstOrDefault();

            if(product != null)
            {
                return PartialView("_UserRatingSummaryPartial", product);
            }

            return Json(true);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReview(ProductDetailsViewModel model)
        {
            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;

            Product product = _context.Product.Where(p => p.ProductID == model.Review.ProductID).FirstOrDefault();

            if (ModelState.IsValid && product != null)
            {
                
                Review review = new Review() { 
                    ProductID = model.Review.ProductID,
                    UserID = model.Review.UserID,
                    ReviewContent = model.Review.ReviewContent,
                    ReviewStars = model.Review.ReviewStars,
                    ReviewDateTime = DateTime.Now,
                };

                switch (model.Review.ReviewStars)
                {
                    case 5:
                        product.ReviewFiveStarsCount++;
                        break;
                    case 4:
                        product.ReviewFourStarsCount++;
                        break;
                    case 3:
                        product.ReviewThreeStarsCount++;
                        break;
                    case 2:
                        product.ReviewTwoStarsCount++;
                        break;
                    case 1:
                        product.ReviewOneStarsCount++;
                        break;
                    default:
                        break;
                }

                _context.Add(review);
                _context.Update(product);
                _context.SaveChanges();

                errorMsg.IsSuccess = true;
            }

            var allErrors = ModelState.Values.SelectMany(v => v.Errors.Select(b => b.ErrorMessage));

            foreach (string error in allErrors)
            {
                errorMsg.Message.Add($"{error}");
            }
            return Json(errorMsg);
        }
    }
}
