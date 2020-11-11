using DogHub.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DogHub.Data.EntityConfigurations
{
    public class DogColorConfiguration : IEntityTypeConfiguration<DogColor>
    {
        public void Configure(EntityTypeBuilder<DogColor> builder)
        {
            builder.HasKey(e => new
            {
                e.ColorId,
                e.DogId
            });
        }
    }
}
