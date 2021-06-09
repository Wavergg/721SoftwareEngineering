using HomeSquareApp.Controllers;
using HomeSquareApp.Data;
using HomeSquareApp.Models;
using HomeSquareApp.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;

namespace HomeSquareApp.Tests
{
    public class ProductController_Test
    {
        [Fact]
        public async void Test_ProductAction()
        {
            #region Arrange
            // todo: define the required assets
            var options = new DbContextOptionsBuilder<AppDbContext>()
                            .UseInMemoryDatabase(databaseName: "HomeSquareMockDb")
                            .Options;

            //AppDbContext context = new AppDbContext(options);
            MockData mockData = new MockData();
            using(AppDbContext context = new AppDbContext(options)) { 
                mockData.CreateMockProductStatus(context);
                mockData.CreateMockProductServingType(context);
                mockData.CreateMockCategory(context);

                IFormFile file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 0, "Data", "dummy.jpg");
            
                AdminProductCreateViewModel model = new AdminProductCreateViewModel()
                {
                    ProductPrice = 15.33333,
                    ProductStock = 5,
                    ProductName = "Coke123",
                    ProductDiscount = (float?)0.5,
                    ProductInformation = "Coke 1.5 L Soft Drink",
                    Description = "Coke 1.5 L Soft Drink",
                    ProductServingContent = 0,
                    ProductServingTypeID = context.ProductServingType.FirstOrDefault().ProductServingTypeID,
                    ProductStatusID = context.ProductStatus.Where(ps=>ps.ProductStatusName == "Sale").FirstOrDefault().ProductStatusID,
                    CategoryID = context.Category.Where(c=>c.CategoryName == "Drink").FirstOrDefault().CategoryID,
                    Image = file,
                    SaleStartDateTime = DateTime.Now,
                    SaleEndDateTime = DateTime.Now.AddDays(2)
                };

                #endregion
                #region Act
                // todo: invoke the test
                //-------------------------------------------Test Creation of Product From Admin-----------------------------------------
                var adminProductController = new AdminProductController(context, null);
                
                await adminProductController.Create(model);
                var creationResult = context.Product.Where(p => p.ProductName == "Coke123").FirstOrDefault() == null ? false : true;

                Assert.True(creationResult);
                #endregion
            }
        }
    }
}
