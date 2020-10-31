using DogHub.Data.Models;
using DogHub.Data.Models.EvaluationForms;
using DogHub.Data.Models.UserRoles;
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

        public DbSet<Breed> Breeds { get; set; }

        public DbSet<Competition> Competitions { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<DogColor> DogsColors { get; set; }

        public DbSet<DogCompetition> DogsCompetitions { get; set; }

        public DbSet<EyesColor> EyesColors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Voter> Voters { get; set; }

        public DbSet<Owner> Owners { get; set; }

        public DbSet<Judge> Judges { get; set; }

        public DbSet<JudgeEvaluationForm> JudgeEvaluationForms { get; set; }

        public DbSet<VoterEvaluationForm> VoterEvaluationForms { get; set; }

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
