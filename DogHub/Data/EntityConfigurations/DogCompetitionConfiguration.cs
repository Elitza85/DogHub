using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    public class DogCompetitionConfiguration : IEntityTypeConfiguration<DogCompetition>
    {
        public void Configure(EntityTypeBuilder<DogCompetition> builder)
        {
            builder.HasKey(e => new
            {
                e.DogId,
                e.CompetitionId
            });
        }
    }
}
