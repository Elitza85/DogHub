using DogHub.Data;
using Microsoft.EntityFrameworkCore;

namespace DogHub
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            using var db = new DogHubDbContext();
            db.Database.Migrate();
        }
    }
}