using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    internal class CompetitionConfiguration : IEntityTypeConfiguration<Competition>
    {
        public void Configure(EntityTypeBuilder<Competition> builder)
        {
            builder.HasKey(e => e.CompetitionId);
            builder.Property(e => e.Name)
                .IsUnicode(false);
        }

    }
}
