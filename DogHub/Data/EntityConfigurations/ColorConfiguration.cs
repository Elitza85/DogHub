using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    internal class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(e => e.ColorId);
            builder.Property(e => e.ColorName)
                .IsUnicode(false);
        }
    }
}
