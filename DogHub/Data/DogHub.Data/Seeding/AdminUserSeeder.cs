using DogHub.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Data.Seeding
{
    public class AdminUserSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (!userManager.Users.Any(x => x.Email == "admin@admin.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    Age = 35,
                    EmailConfirmed = true,
                };
                await userManager.CreateAsync(user, "123456");

                await userManager.AddToRoleAsync(user, "Administrator");
            }
        }
    }
}
