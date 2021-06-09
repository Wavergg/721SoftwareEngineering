using HomeSquareApp.Data;
using HomeSquareApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeSquareApp.Tests
{
    public class MockData
    {



        public DbSet<Category> CreateMockCategory(AppDbContext context)
        {
            context.Category.AddRange(
                new Category()
                {
                   CategoryName = "Drink" ,
                }
            );
            context.SaveChanges();

           
            return context.Category;
        }

        public DbSet<ProductStatus> CreateMockProductStatus(AppDbContext context)
        {
            if (!context.ProductStatus.Any()) { 
                context.ProductStatus.AddRange(
                    new ProductStatus
                    {
                        ProductStatusName = "Hold"
                    },
                    new ProductStatus
                    {
                        ProductStatusName = "Sale"
                    },
                    new ProductStatus
                    {
                        ProductStatusName = "Published"
                    }
                );
                context.SaveChanges();
            }
            return context.ProductStatus;
        }

        public DbSet<ProductServingType> CreateMockProductServingType(AppDbContext context)
        {
            if (!context.ProductServingType.Any()) { 
                context.ProductServingType.AddRange(
                    new ProductServingType
                    {
                        ServingType = "Grams"
                    },
                    new ProductServingType
                    {
                        ServingType = "Kg"
                    },
                    new ProductServingType
                    {
                        ServingType = "L"
                    },
                    new ProductServingType
                    {
                        ServingType = "ml"
                    },
                    new ProductServingType
                    {
                        ServingType = "Pcs"
                    }
                );
                context.SaveChanges();
            }
            return context.ProductServingType;
        }
    }
}
