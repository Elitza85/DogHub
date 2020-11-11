using DogHub.Data.Models.UserRoles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DogHub.Data.EntityConfigurations
{
    public class JudgeConfiguration : IEntityTypeConfiguration<Judge>
    {
        public void Configure(EntityTypeBuilder<Judge> builder)
        {
            
            builder.HasMany(v => v.JudgeEvaluationForms)
                .WithOne(f => f.Judge)
                .HasForeignKey(f => f.JudgeId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
