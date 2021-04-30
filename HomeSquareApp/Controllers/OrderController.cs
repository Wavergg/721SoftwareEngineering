using HomeSquareApp.Data;
using HomeSquareApp.Models;
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

        [HttpPost]
        public async Task<IActionResult> GetCurrentCartCount()
        {
            int cartCount = 0;

            if (_SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);

                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if(order != null) { 
                    cartCount = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Count();
                }
            }
            else
            {
                string cookie = Request.Cookies["homeSquareCookieID"];
                if (cookie != null)
                {
                    ApplicationUser user = await _UserManager.FindByNameAsync(cookie);
                    Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();

                    if (order != null)
                    {
                        cartCount = _context.OrderDetails.Where(od => od.OrderID == order.OrderID).Count();
                    }
                }
            }

            return Json(cartCount);
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
            else if (product.ProductStock < quantity)
            {
                message.Add(string.Format("Not Enough Stock, {0} Lefts",product.ProductStock));
                return Json(new ErrorMessage(false, message));
            }

            if (_SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);

                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order == null)
                {
                    order = CreateOrder(user.Id);
                }

                bool isAvailable = await AttachOrderDetails(productID, quantity, order.OrderID);

                if (!isAvailable)
                {
                    message.Add(string.Format("Not Enough Stock, {0} Lefts", currentStockAvailable));
                    return Json(new ErrorMessage(false, message));
                }
                message.Add("Item Added");
                return Json(new ErrorMessage(true, message));
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
                        await AttachOrderDetails(productID,quantity,order.OrderID);

                        message.Add("Item Added");
                        return Json(new ErrorMessage(true, message));
                    }
                    message.Add("Service Not Available at This Time");
                    return Json(new ErrorMessage(true, message));
                } else
                {
                    ApplicationUser user = await _UserManager.FindByNameAsync(cookie);

                    if(user != null)
                    {
                        Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                        if(order == null)
                        {
                            order = CreateOrder(user.Id);
                        }

                        bool isAvailable = await AttachOrderDetails(productID, quantity, order.OrderID);

                        if (!isAvailable)
                        {
                            message.Add(string.Format("Not Enough Stock, {0} Lefts", currentStockAvailable));
                            return Json(new ErrorMessage(false, message));
                        }
                        message.Add("Item Added");
                        return Json(new ErrorMessage(true, message));
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
                            bool isSuccess = await AttachOrderDetails(productID, quantity, order.OrderID);

                            message.Add("Item Added");
                            return Json(new ErrorMessage(true, message));
                            
                        }
                        message.Add("Service Not Available at This Time");
                        return Json(new ErrorMessage(false, message));
                    }
                }
            }
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
