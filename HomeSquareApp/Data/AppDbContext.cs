using HomeSquareApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            foreach (var foreignKey in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        } 

        public DbSet<Category> Category { get; set; }

        public DbSet<Ingredient> Ingredient { get; set; }

        public DbSet<Order> Order { get; set; }

        public DbSet<OrderDetails> OrderDetails { get; set; }

        public DbSet<Recipe> Recipe { get; set; }

        public DbSet<RecipeApprovalStatus> RecipeApprovalStatus { get; set; }

        public DbSet<RecipeSteps> RecipeSteps { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<Reward> Reward { get; set; }

        public DbSet<RewardPool> RewardPool { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductStatus> ProductStatus { get; set; }

        public DbSet<ProductServingType> ProductServingType { get; set; }
    }
}
