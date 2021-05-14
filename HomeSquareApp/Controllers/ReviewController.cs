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

        public IActionResult RefreshReview(int productID)
        {
            List<Review> reviews = _context.Review.Where(r => r.ProductID == productID)
                            .OrderByDescending(r => r.ReviewDateTime)
                            .Include(r => r.User).ToList();

            return PartialView("_ReviewsListPartial", reviews);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateReview([Bind("UserID,ProductID,ReviewContent,ReviewStars")]ReviewViewModel model)
        {
            if (ModelState.IsValid)
            {
                Review review = new Review() { 
                    ProductID = model.ProductID,
                    UserID = model.UserID,
                    ReviewContent = model.ReviewContent,
                    ReviewStars = model.ReviewStars,
                    ReviewDateTime = DateTime.Now,
                };

                _context.Add(review);
                _context.SaveChanges();
            }

            
            return Json(true);
        }


    }
}
