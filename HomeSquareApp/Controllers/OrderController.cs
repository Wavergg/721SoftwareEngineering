using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Controllers
{
    public class OrderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _UserManager;
        private readonly SignInManager<ApplicationUser> _SignInManager;

        private int currentStockAvailable = 0;

        public OrderController(AppDbContext _context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._context = _context;
            this._UserManager = userManager;
            this._SignInManager = signInManager;
        }

        private async Task<IdentityResult> InitializeUserCookie(string cookieID)
        {
            //Initialize Cookie
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Append("homeSquareCookieID", cookieID, option);

            //Create User Based On Cookie
            var user = new ApplicationUser
            {
                Email = string.Format("{0}@HomeSquare.com", cookieID),
                UserName = cookieID,
                FirstName = "AnonymousUser",
                LastName = "AnonymousUser",
                Address = "homeSquareCookieID",
                PhoneNumber = "000000",
            };

            var result = await _UserManager.CreateAsync(user, cookieID);

            return result;
        }

        private async Task<ApplicationUser> GetCurrentUser()
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
            return user;
        }

        [HttpPost]
        public async Task<IActionResult> GetCurrentCartCount()
        {
            int cartCount = 0;
            ApplicationUser user = await GetCurrentUser();

            if (user != null) { 
                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order != null)
                {
                    cartCount = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Count();
                }
            }
            return Json(cartCount);
        }

        [HttpPost]
        public async Task<IActionResult> LoadCart()
        {
            CartViewModel model = new CartViewModel();
            ApplicationUser user = await GetCurrentUser();

            if (user != null) { 
                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order != null)
                {
                    model.OrderDetails = _context.OrderDetails.Where(od => od.OrderID == order.OrderID)
                                        .Include(od => od.Product)
                                        .ThenInclude(p=>p.ServingType).ToList();
                    model.TotalInCart = model.OrderDetails.Sum(od => od.TotalPrice);
                }
            }
            return PartialView("_ModalCartPartial", model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItem(int orderDetailsID)
        {
            ApplicationUser user = await GetCurrentUser();
            ErrorMessage message = new ErrorMessage();

            
            if(user != null)
            {
                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order != null)
                {
                    List<OrderDetails> orderDetailsList = _context.OrderDetails.Where(od => od.OrderID == order.OrderID)
                                                .Include(od => od.Product)
                                                .ToList();

                    OrderDetails orderDetails = orderDetailsList.Where(od => od.OrderDetailsID == orderDetailsID).FirstOrDefault();

                    if (orderDetails != null)
                    {
                        _context.Remove(orderDetails);
                        _context.SaveChanges();
                        message.IsSuccess = true;

                        orderDetailsList.Remove(orderDetails);
                        message.Message.Add(String.Format("{0:F2}",orderDetailsList.Sum(od=>od.TotalPrice)));
                        
                    }
                }
            } else
            {
                message.IsSuccess = false;
                message.Message.Add("Unable to locate user");
            }

            return Json(message);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateItemQuantity(int orderDetailsID,int quantity)
        {
            ApplicationUser user = await GetCurrentUser();
            ErrorMessage message = new ErrorMessage();


            if (user != null)
            {
                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order != null)
                {
                    List<OrderDetails> orderDetailsList = _context.OrderDetails.Where(od => od.OrderID == order.OrderID)
                                                .Include(od => od.Product)
                                                .ToList();

                    OrderDetails orderDetails = orderDetailsList.Where(od => od.OrderDetailsID == orderDetailsID).FirstOrDefault();

                    if (orderDetails != null)
                    {
                        if(orderDetails.Product.ProductStock >= quantity) { 
                            orderDetails.Quantity = quantity;
                            orderDetails.TotalPrice = quantity * orderDetails.Product.ProductPrice;
                            _context.Update(orderDetails);
                            _context.SaveChanges();

                            message.IsSuccess = true;
                            message.Message.Add(String.Format("{0:F2}", orderDetailsList.Sum(od => od.TotalPrice)));
                            message.Message.Add(String.Format("{0:F2}", orderDetails.TotalPrice));
                        } else
                        {
                            quantity = orderDetails.Product.ProductStock == null ? 0 : (int)orderDetails.Product.ProductStock;
                            orderDetails.Quantity = quantity;
                            orderDetails.TotalPrice = quantity * orderDetails.Product.ProductPrice;
                            _context.Update(orderDetails);
                            _context.SaveChanges();

                            message.IsSuccess = false;
                            message.Message.Add(String.Format("{0:F2}", orderDetailsList.Sum(od => od.TotalPrice)));
                            message.Message.Add(String.Format("{0:F2}", orderDetails.TotalPrice));
                            message.Message.Add(string.Format("Not Enough Stock, {0} Lefts", orderDetails.Product.ProductStock));
                            message.Message.Add($"{orderDetails.Product.ProductStock}");
                        }
                    }
                }
            }
            
            return Json(message);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleOrder(int productID, int quantity)
        {
            //check quantity < stock
            Product product = _context.Product.Where(p => p.ProductID == productID).FirstOrDefault();
            List<string> message = new List<string>();
            if(product == null)
            {
                message.Add("Product Not Found");
                return Json(new ErrorMessage(false,message));
            } 
            else if(quantity == 0)
            {
                message.Add("Quantity Cannot be Empty");
                return Json(new ErrorMessage(false, message));
            }

            bool isAvailable = false;

            if (_SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);

                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order == null)
                {
                    order = CreateOrder(user.Id);
                }

                isAvailable = await AttachOrderDetails(productID, quantity, order.OrderID);
            }
            else
            {
                string cookie = Request.Cookies["homeSquareCookieID"];
                if (cookie == null)
                {
                    //Initialize Cookie
                    var cookieID = Guid.NewGuid().ToString();
                    IdentityResult result = await InitializeUserCookie(cookieID);

                    if (result.Succeeded) {
                        var userFromDb = _context.Users.FirstOrDefault(u => u.UserName == cookieID );
                        Order order = CreateOrder(userFromDb.Id);
                        isAvailable = await AttachOrderDetails(productID,quantity,order.OrderID);
                    } 
                    else { 
                        message.Add("Service Not Available at This Time");
                        return Json(new ErrorMessage(true, message));
                    }
                } 
                else
                {
                    ApplicationUser user = await _UserManager.FindByNameAsync(cookie);

                    if(user != null)
                    {
                        Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                        if(order == null)
                        {
                            order = CreateOrder(user.Id);
                        }

                        isAvailable = await AttachOrderDetails(productID, quantity, order.OrderID);
                    }
                    else
                    {
                        Response.Cookies.Delete("homeSquareCookieID");
                        var cookieID = Guid.NewGuid().ToString();
                        IdentityResult result = await InitializeUserCookie(cookieID);
                        if (result.Succeeded)
                        {
                            var userFromDb = _context.Users.FirstOrDefault(u => u.UserName == cookieID);
                            Order order = CreateOrder(userFromDb.Id);
                            isAvailable = await AttachOrderDetails(productID, quantity, order.OrderID);
                        } 
                        else
                        {
                            message.Add("Service Not Available at This Time");
                            return Json(new ErrorMessage(false, message));
                        }
                    }
                }
            }

            if (!isAvailable)
            {
                message.Add(string.Format("Not Enough Stock, {0} Lefts", currentStockAvailable));
                return Json(new ErrorMessage(false, message));
            }
            message.Add("Item Added");
            return Json(new ErrorMessage(true, message));
        }

        private Order CreateOrder(string userID)
        {
            Order order = new Order()
            {
                OrderID = Guid.NewGuid().ToString(),
                OrderStatus = "Ongoing",
                UserID = userID,
            };
            _context.Add(order);
            _context.SaveChanges();

            return order;
        }

        private async Task<bool> AttachOrderDetails(int productID, int quantity, string orderID)
        {
            
            OrderDetails orderDetails = _context.OrderDetails.Where(od => od.OrderID == orderID && od.ProductID == productID).FirstOrDefault();
            Product product = _context.Product.Where(p => p.ProductID == productID).FirstOrDefault();
            //check if order with same product alrdy exist, if not then create new orderdetails, if yes update quantity +total
            if (orderDetails == null)
            {
                orderDetails = new OrderDetails()
                {
                    ProductID = product.ProductID,
                    OrderID = orderID,
                    Quantity = quantity,
                    TotalPrice = product.ProductPrice * quantity,
                };
                _context.Add(orderDetails);
            } else
            {
                var quantityAfterIncrease = orderDetails.Quantity + quantity;
                if(quantityAfterIncrease <= product.ProductStock) { 
                    orderDetails.Quantity = quantityAfterIncrease;
                    orderDetails.TotalPrice += quantity * product.ProductPrice;
                    _context.Update(orderDetails);
                } else
                {
                    currentStockAvailable = product.ProductStock == null ? 0 : (int)product.ProductStock - orderDetails.Quantity;
                    return false;
                }
            }
            
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
