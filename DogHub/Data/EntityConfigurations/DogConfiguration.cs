using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    internal class DogConfiguration : IEntityTypeConfiguration<Dog>
    {
        public void Configure(EntityTypeBuilder<Dog> builder)
        {
            builder.HasKey(e => e.DogId);
            builder.Property(e => e.Name)
                .IsUnicode(false);
            builder.Property(e => e.Breed)
                .IsUnicode(false);
        }
    }
}
