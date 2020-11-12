using DogHub.Data.Models.Dogs;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DogHub.Data.Seeding
{
    public class BreedsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Breeds.Any())
            {
                return;
            }

            await dbContext.Breeds.AddAsync(new Breed { BreedName = "American Bully" });
            await dbContext.Breeds.AddAsync(new Breed { BreedName = "Chao Chao" });
            
            await dbContext.SaveChangesAsync();
        }
    }
}
