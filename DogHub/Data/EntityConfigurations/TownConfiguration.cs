using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    public class TownConfiguration : IEntityTypeConfiguration<Town>
    {
        public void Configure(EntityTypeBuilder<Town> builder)
        {
            builder.HasKey(e => e.TownId);
            builder.Property(e => e.TownName)
                .IsUnicode(false);
        }
    }
}
