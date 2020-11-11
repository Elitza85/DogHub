using DogHub.Data.Models;
using DogHub.Data.Models.EvaluationForms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    public class VoterConfiguration :IEntityTypeConfiguration<Voter>
    {
        public void Configure(EntityTypeBuilder<Voter> builder)
        {
            builder.HasMany(v => v.VoterEvaluationForms)
                .WithOne(f => f.Voter)
                .HasForeignKey(f => f.VoterId)
                .OnDelete(DeleteBehavior.Restrict);
              
        }
    }
}
