using HomeSquareApp.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public static class SeedData
    {

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<AppDbContext>>()))
            {

                if (!context.ProductStatus.Any())
                {
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
                    
                }

                if (!context.Roles.Any())
                {
                    var RoleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                    var UserManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                    string[] roleNames = { "ADMIN", "CUSTOMER" };
                    IdentityResult roleResult;

                    foreach (var roleName in roleNames)
                    {
                        var roleExist = await RoleManager.RoleExistsAsync(roleName);
                        if (!roleExist)
                        {
                            roleResult = await RoleManager.CreateAsync(new IdentityRole(roleName));
                        }
                    }

                    var superUser = new ApplicationUser
                    {
                        Email = "HomeAdmin@gmail.com",
                        UserName = "HomeAdmin@gmail.com",
                        FirstName = "ADMIN",
                        LastName = "ADMIN",
                        Address = "ADMIN",
                        PhoneNumber = "00000",
                    };
                    var result = await UserManager.CreateAsync(superUser, "Trihardo123#");

                    if (result.Succeeded)
                    {
                        var emailConfirmationToken = await UserManager.GenerateEmailConfirmationTokenAsync(superUser);
                        await UserManager.ConfirmEmailAsync(superUser, emailConfirmationToken);
                        await UserManager.AddToRoleAsync(superUser, "ADMIN");
                    }
                }

                context.SaveChanges();
            }
        }
    }
}
