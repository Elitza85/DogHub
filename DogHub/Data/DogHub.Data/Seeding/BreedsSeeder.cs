namespace DogHub.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using DogHub.Data.Models.Dogs;
    using Microsoft.EntityFrameworkCore.Internal;

    public class BreedsSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Breeds.Any())
            {
                return;
            }
            await dbContext.Breeds.AddAsync(new Breed { Name = "American Bully" });
            await dbContext.Breeds.AddAsync(new Breed { Name = "Chao Chao" });
            await dbContext.SaveChangesAsync();
        }
    }
}
