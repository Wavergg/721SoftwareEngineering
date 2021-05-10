﻿// <auto-generated />
using System;
using HomeSquareApp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HomeSquareApp.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HomeSquareApp.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("DeliveryAddress")
                        .HasMaxLength(128);

                    b.Property<string>("DeliveryEmail")
                        .HasMaxLength(64);

                    b.Property<string>("DisplayName")
                        .HasMaxLength(18);

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(256);

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Suburb")
                        .HasMaxLength(32);

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("Unit")
                        .HasMaxLength(8);

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("ZipCode")
                        .HasMaxLength(8);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.HasKey("CategoryID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Ingredient", b =>
                {
                    b.Property<int>("IngredientID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<int>("RecipeID");

                    b.Property<string>("ServingContent")
                        .HasMaxLength(64);

                    b.HasKey("IngredientID");

                    b.HasIndex("ProductID");

                    b.HasIndex("RecipeID");

                    b.ToTable("Ingredient");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Order", b =>
                {
                    b.Property<string>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(36);

                    b.Property<string>("DeliveryOptions")
                        .HasColumnType("varchar(8)")
                        .HasMaxLength(8);

                    b.Property<DateTime>("OrderDateTime");

                    b.Property<string>("OrderStatus")
                        .HasColumnType("varchar(9)")
                        .HasMaxLength(9);

                    b.Property<string>("UserID");

                    b.HasKey("OrderID");

                    b.HasIndex("UserID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("HomeSquareApp.Models.OrderDetails", b =>
                {
                    b.Property<int>("OrderDetailsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<double>("TotalPrice");

                    b.HasKey("OrderDetailsID");

                    b.HasIndex("OrderID");

                    b.HasIndex("ProductID");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryID")
                        .IsRequired();

                    b.Property<int>("CurrentWeekPurchaseCount");

                    b.Property<string>("Description")
                        .HasMaxLength(512);

                    b.Property<string>("ImageUrl")
                        .IsRequired();

                    b.Property<double>("PriceAfterDiscount");

                    b.Property<DateTime>("ProductAddedDate");

                    b.Property<float?>("ProductDiscount");

                    b.Property<string>("ProductInformation")
                        .HasMaxLength(256);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(128);

                    b.Property<double>("ProductPrice");

                    b.Property<float?>("ProductServingContent")
                        .IsRequired();

                    b.Property<int?>("ProductServingTypeID")
                        .IsRequired();

                    b.Property<int?>("ProductStatusID")
                        .IsRequired();

                    b.Property<int?>("ProductStock");

                    b.Property<DateTime>("ProductUpdateDate");

                    b.Property<int>("ReviewFiveStarsCount");

                    b.Property<int>("ReviewFourStarsCount");

                    b.Property<int>("ReviewOneStarsCount");

                    b.Property<int>("ReviewThreeStarsCount");

                    b.Property<int>("ReviewTwoStarsCount");

                    b.Property<int?>("RewardPoolID");

                    b.Property<DateTime>("SaleEndDateTime");

                    b.Property<DateTime>("SaleStartDateTime");

                    b.Property<int>("Week1PurchaseCount");

                    b.Property<int>("Week2PurchaseCount");

                    b.Property<int>("Week3PurchaseCount");

                    b.Property<int>("Week4PurchaseCount");

                    b.Property<int>("Week5PurchaseCount");

                    b.HasKey("ProductID");

                    b.HasIndex("CategoryID");

                    b.HasIndex("ProductServingTypeID");

                    b.HasIndex("ProductStatusID");

                    b.HasIndex("RewardPoolID")
                        .IsUnique()
                        .HasFilter("[RewardPoolID] IS NOT NULL");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("HomeSquareApp.Models.ProductServingType", b =>
                {
                    b.Property<int>("ProductServingTypeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ServingType")
                        .IsRequired()
                        .HasColumnType("varchar(16)")
                        .HasMaxLength(10);

                    b.HasKey("ProductServingTypeID");

                    b.ToTable("ProductServingType");
                });

            modelBuilder.Entity("HomeSquareApp.Models.ProductStatus", b =>
                {
                    b.Property<int>("ProductStatusID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ProductStatusName")
                        .IsRequired()
                        .HasColumnType("varchar(16)");

                    b.HasKey("ProductStatusID");

                    b.ToTable("ProductStatus");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Recipe", b =>
                {
                    b.Property<int>("RecipeID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("AddedDate");

                    b.Property<string>("ImageUrl");

                    b.Property<int>("Likes");

                    b.Property<string>("PrepareTime")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("RecipeApprovalStatus");

                    b.Property<string>("RecipeDescription")
                        .IsRequired()
                        .HasMaxLength(512);

                    b.Property<string>("RecipeName")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<int>("Servings");

                    b.Property<string>("UserID");

                    b.HasKey("RecipeID");

                    b.HasIndex("UserID");

                    b.ToTable("Recipe");
                });

            modelBuilder.Entity("HomeSquareApp.Models.RecipeSteps", b =>
                {
                    b.Property<int>("StepsID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RecipeID");

                    b.Property<string>("Steps")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("StepsID");

                    b.HasIndex("RecipeID");

                    b.ToTable("RecipeSteps");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.Property<string>("ReviewContent")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.Property<DateTime>("ReviewDateTime");

                    b.Property<int>("ReviewStars");

                    b.Property<string>("UserID");

                    b.HasKey("ReviewID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Review");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Reward", b =>
                {
                    b.Property<int>("RewardID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OrderID");

                    b.Property<int?>("RewardPoolID");

                    b.Property<string>("RewardStatus")
                        .HasColumnType("varchar(8)");

                    b.Property<string>("UserID");

                    b.HasKey("RewardID");

                    b.HasIndex("OrderID");

                    b.HasIndex("RewardPoolID");

                    b.HasIndex("UserID");

                    b.ToTable("Reward");
                });

            modelBuilder.Entity("HomeSquareApp.Models.RewardPool", b =>
                {
                    b.Property<int>("RewardPoolID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductID");

                    b.HasKey("RewardPoolID");

                    b.ToTable("RewardPool");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("HomeSquareApp.Models.Ingredient", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Product", "Product")
                        .WithMany("Ingredients")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.Order", b =>
                {
                    b.HasOne("HomeSquareApp.Models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.OrderDetails", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.Product", "Product")
                        .WithMany("OrderDetails")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.Product", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.ProductServingType", "ServingType")
                        .WithMany()
                        .HasForeignKey("ProductServingTypeID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.ProductStatus", "ProductStatus")
                        .WithMany()
                        .HasForeignKey("ProductStatusID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.RewardPool", "RewardPool")
                        .WithOne("Product")
                        .HasForeignKey("HomeSquareApp.Models.Product", "RewardPoolID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.Recipe", b =>
                {
                    b.HasOne("HomeSquareApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.RecipeSteps", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Recipe", "Recipe")
                        .WithMany("RecipeSteps")
                        .HasForeignKey("RecipeID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.Review", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Product", "Product")
                        .WithMany("Review")
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("HomeSquareApp.Models.Reward", b =>
                {
                    b.HasOne("HomeSquareApp.Models.Order", "Order")
                        .WithMany("Rewards")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.RewardPool")
                        .WithMany("Rewards")
                        .HasForeignKey("RewardPoolID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.ApplicationUser", "User")
                        .WithMany("Rewards")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("HomeSquareApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("HomeSquareApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("HomeSquareApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("HomeSquareApp.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });
#pragma warning restore 612, 618
        }
    }
}
