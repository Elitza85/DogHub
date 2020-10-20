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
            builder.HasOne(v => v.VoterEvaluationFormResult)
                .WithOne(f => f.Voter)
                .HasForeignKey<VoterEvaluationForm>(f => f.VoterId);
              
        }
    }
}
