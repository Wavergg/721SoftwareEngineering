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

        public OrderController(AppDbContext _context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this._context = _context;
            this._UserManager = userManager;
            this._SignInManager = signInManager;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> HandleOrder(int productID, int quantity)
        {
            //check quantity < stock
            Product product = _context.Product.Where(p => p.ProductID == productID).FirstOrDefault();
            if(product == null)
            {
                return Json("Product Not Found");
            } 
            else if (product.ProductStock < quantity)
            {
                return Json("Not Enough Stock");
            }

            if (_SignInManager.IsSignedIn(User))
            {
                ApplicationUser user = await _UserManager.GetUserAsync(User);

                Order order = _context.Order.Where(o => o.UserID == user.Id && o.OrderStatus == "Ongoing").FirstOrDefault();
                if (order == null)
                {
                    order = CreateOrder(user.Id);
                }

                await AttachOrderDetails(productID, quantity, order.OrderID);

                return Json("Successfully Created Order");
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
                        var userFromDb = _context.Users.FirstOrDefault(u => u.UserName == cookieID);
                        Order order = CreateOrder(userFromDb.Id);
                        await AttachOrderDetails(productID,quantity,order.OrderID);

                        return Json("Successfully Created Order");
                    }
                    return Json("Unable to Create User");
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

                        await AttachOrderDetails(productID, quantity, order.OrderID);

                        return Json("Successfully Created Order");
                    } else
                    {
                        Response.Cookies.Delete("homeSquareCookieID");
                        var cookieID = Guid.NewGuid().ToString();
                        IdentityResult result = await InitializeUserCookie(cookieID);
                        if (result.Succeeded)
                        {
                            var userFromDb = _context.Users.FirstOrDefault(u => u.UserName == cookieID);
                            Order order = CreateOrder(userFromDb.Id);
                            await AttachOrderDetails(productID, quantity, order.OrderID);

                            return Json("Successfully Created Order");
                        }
                        return Json("Something went wrong " + cookie);
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

        private async Task AttachOrderDetails(int productID, int quantity, string orderID)
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
                orderDetails.Quantity += quantity;
                orderDetails.TotalPrice += quantity * product.ProductPrice;
                _context.Update(orderDetails);
            }

            product.ProductStock -= quantity;
            _context.Update(product);
            
            await _context.SaveChangesAsync();
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
                Email = string.Format("{0}@HomeSquare.com",cookieID),
                UserName = cookieID,
                FirstName = "AnonymousUser",
                LastName = "AnonymousUser",
                Address = "homeSquareCookieID",
                PhoneNumber = "000000",
            };

            var result = await _UserManager.CreateAsync(user, cookieID);

            return result;
        }
    }
}
