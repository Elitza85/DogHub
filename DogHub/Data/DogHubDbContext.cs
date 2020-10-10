using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DogHub.Data
{
    public class DogHubDbContext : DbContext
    {
        public DogHubDbContext()
        {

        }

        public DogHubDbContext(DbContextOptions options)
            :base(options)
        {

        }

        public DbSet<Dog> Dogs { get; set; }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<DogColor> DogsColors { get; set; }

        public DbSet<DogCompetition> DogsCompetitions { get; set; }

        public DbSet<EyesColor> EyesColors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            model.ApplyConfigurationsFromAssembly(assembly);
        }
    }
}
