using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    public class EyesColorConfiguration : IEntityTypeConfiguration<EyesColor>
    {
        public void Configure(EntityTypeBuilder<EyesColor> builder)
        {
            builder.HasKey(e => e.EyesColorId);
            builder.Property(e => e.EyesColorName)
                .IsUnicode(false);
        }
    }
}
