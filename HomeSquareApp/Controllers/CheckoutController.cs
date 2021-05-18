using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<ApplicationUser> _SignInManager;
        private readonly UserManager<ApplicationUser> _UserManager;

        public CheckoutController(AppDbContext context,
                                    SignInManager<ApplicationUser> signInManager,
                                     UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._SignInManager = signInManager;
            this._UserManager = userManager;
        }



        public async Task<IActionResult> Index()
        {
            CheckoutViewModel model = new CheckoutViewModel();
            model.OrderViewModel = new OrderViewModel();

            ApplicationUser user = null;
            if (_SignInManager.IsSignedIn(User))
            {
                user = await _UserManager.GetUserAsync(User);

                model.OrderViewModel.FirstName = user.FirstName;
                model.OrderViewModel.LastName = user.LastName;
                model.OrderViewModel.DeliveryAddress = user.Address;
                model.OrderViewModel.PhoneNumber = user.PhoneNumber;
                model.OrderViewModel.DeliveryEmail = user.Email;
                model.OrderViewModel.Suburb = user.Suburb;
                model.OrderViewModel.Unit = user.Unit;
                model.OrderViewModel.ZipCode = user.ZipCode;
            }
            else
            {
                string cookie = Request.Cookies["homeSquareCookieID"];
                if (cookie != null)
                {
                    user = await _UserManager.FindByNameAsync(cookie);
                }
            }

            if (user != null)
            {
                model.Order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (model.Order != null)
                {
                    model.Order.OrderDetails = _context.OrderDetails.Where(od => od.OrderID == model.Order.OrderID)
                                        .Include(od => od.Product)
                                        .ThenInclude(p=>p.ProductStatus)
                                        .ToList();

                    foreach(OrderDetails orderDetails in model.Order.OrderDetails)
                    {
                        if(orderDetails.Product.ProductStatus.ProductStatusName == "Sale" &&
                            orderDetails.Product.SaleStartDateTime <= DateTime.Now &&
                            orderDetails.Product.SaleEndDateTime >= DateTime.Now)
                        {
                            orderDetails.TotalPrice = orderDetails.Product.PriceAfterDiscount * orderDetails.Quantity;
                        } else
                        {
                            orderDetails.TotalPrice = orderDetails.Product.ProductPrice * orderDetails.Quantity;
                        }
                    }

                    model.OrderViewModel.OrderID = model.Order.OrderID;
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                TempData["OpenLogin"] = true;
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        public IActionResult Success(string orderID)
        {
            Order order = _context.Order.Where(o => o.OrderID == orderID).Include(o=>o.User).FirstOrDefault();

            if(order == null)
            {
                TempData["ErrorMessage"] = "Unable to locate order";
                return RedirectToAction("Index","Home");
            }

            order.OrderDetails = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Include(od=>od.Product).ToList();

            return View(order);
        }

        public async Task<IActionResult> UpdateOrderSummary()
        {
            ApplicationUser user = null;
            if (_SignInManager.IsSignedIn(User))
            {
                user = await _UserManager.GetUserAsync(User);
            }
            else
            {
                string cookie = Request.Cookies["homeSquareCookieID"];
                if (cookie != null)
                {
                    user = await _UserManager.FindByNameAsync(cookie);
                }
            }

            if(user == null)
            {
                return Json(false);
            }

            Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
            if(order != null)
            {
                order.OrderDetails = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Include(od=>od.Product).ToList();
            }

            return PartialView("_OrderSummaryPartial",order.OrderDetails);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitOrder([Bind("OrderID,DeliveryOptions,FirstName,LastName,DeliveryEmail," +
            "PhoneNumber,DeliveryAddress,Suburb,ZipCode,Unit,NameOnCard,CreditCardNumber,ExpiryMonth,ExpiryYear,CVV")]OrderViewModel model)
        {
            ErrorMessage errorMsg = new ErrorMessage();
            errorMsg.IsSuccess = false;
            bool isAnonymous = true;
            ApplicationUser user = null;

            //NOT GONNA HANDLE CARD EXCEPT CHECKING LENGTH
            if (model.CreditCardNumber != null && model.CreditCardNumber.Length != 19)
            {
                ModelState.AddModelError("", "Invalid Card Number");
            }

            if (_SignInManager.IsSignedIn(User))
            {
                user = await _UserManager.GetUserAsync(User);
                isAnonymous = false;
            }
            else
            {
                string cookie = Request.Cookies["homeSquareCookieID"];
                if (cookie != null)
                {
                    user = await _UserManager.FindByNameAsync(cookie);
                    isAnonymous = true;
                } else
                {
                    errorMsg.Message.Add("Unable to Locate User");
                    return Json(errorMsg);
                }
            }

            if (ModelState.IsValid)
            {
                //SENDING EMAIL(REENABLE THIS LATER)
                //try
                //{
                //    MailMessage message = new MailMessage("homesquare322@gmail.com", model.DeliveryEmail);
                //    message.Subject = "Order Confirmation";
                //    message.Body = "Thank you for your purchase, Here is your order URL: \n" +
                //                    Url.Action("Success", "Checkout", new { orderID = model.OrderID }, Request.Scheme);
                //    EmailController.SendEmail(message);
                //}
                //catch
                //{
                //    errorMsg.Message.Add("Failure in sending Email confirmation, Please try again.");
                //    return Json(errorMsg);
                //}

                Order order;
                try
                {
                    order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing")
                            .Include(o => o.OrderDetails)
                            .ThenInclude(od => od.Product)
                            .FirstOrDefault();
                    if (order == null || order.OrderDetails.Count() == 0)
                    {
                        errorMsg.Message.Add("Unable to locate order");
                        return Json(errorMsg);
                    }

                    //List<OrderDetails> orderToRemove = new List<OrderDetails>();
                    List<Product> productToUpdate = new List<Product>();
                    //check availability
                    foreach (OrderDetails orderDetail in order.OrderDetails)
                    {
                        if (orderDetail.Quantity > orderDetail.Product.ProductStock)
                        {
                            errorMsg.Message.Add(string.Format($"{orderDetail.Product.ProductName} Has Been Sold Out"));
                            _context.OrderDetails.Remove(orderDetail);
                            _context.SaveChanges();
                        }
                        else
                        {
                            Product product = _context.Product.Where(p => p.ProductID == orderDetail.ProductID).FirstOrDefault();
                            product.ProductStock -= orderDetail.Quantity;
                            product.CurrentWeekPurchaseCount += orderDetail.Quantity;
                            productToUpdate.Add(product);
                        }
                    }

                    if (errorMsg.Message.Count() > 0)
                    {
                        return Json(errorMsg);
                    }
                    
                    foreach(Product product in productToUpdate)
                    {
                        _context.Update(product);
                    }
                    
                    order.OrderDateTime = DateTime.Now;
                    order.OrderStatus = "Preparing";
                    order.DeliveryOptions = model.DeliveryOptions;
                    order.OrderTotal = order.OrderDetails.Sum(od => od.TotalPrice);

                    //Attach Reward
                    List<Reward> rewards = _context.Reward.Where(r => r.UserID == user.Id && r.RewardStatus == RewardStatus.Available).ToList();

                    foreach(Reward reward in rewards)
                    {
                        OrderDetails orderDetails = new OrderDetails()
                        {
                            OrderID = order.OrderID,
                            ProductID = reward.ProductID,
                            Quantity = 1,
                            TotalPrice = 0,
                        };
                        _context.OrderDetails.Add(orderDetails);

                        reward.RewardStatus = RewardStatus.Claimed;
                        reward.OrderID = order.OrderID;
                        _context.Update(reward);
                    }

                    _context.Order.Update(order);
                    _context.SaveChanges();
                }
                catch
                {
                    errorMsg.Message.Add("Failure in creating order, please try again.");
                    return Json(errorMsg);
                }

                try
                {
                    if (isAnonymous)
                    {
                        user.LastName = model.LastName;
                        user.FirstName = model.FirstName;
                        user.PhoneNumber = model.PhoneNumber;
                    }
                    user.DeliveryAddress = model.DeliveryAddress;
                    user.DeliveryEmail = model.DeliveryEmail;
                    user.Suburb = model.Suburb;
                    user.ZipCode = model.ZipCode;
                    user.Unit = model.Unit;
                    if(order.OrderTotal >= 100)
                    {
                        user.RewardPlayChanceCount++;
                    }
                    _context.ApplicationUser.Update(user);
                    _context.SaveChanges();
                    errorMsg.IsSuccess = true;
                    errorMsg.UrlRedirect = Url.Action("Success", "Checkout", new { orderID = model.OrderID });
                    return Json(errorMsg);
                }
                catch
                {
                    order.OrderStatus = "Ongoing";
                    order.DeliveryOptions = "";
                    _context.Order.Update(order);
                    _context.SaveChanges();
                    errorMsg.Message.Add("Failure in filling user information, order is not applied");
                    return Json(errorMsg);
                }
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
