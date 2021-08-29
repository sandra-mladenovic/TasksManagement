using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess.Configuration
{
    public class StatusTypeConfiguration : IEntityTypeConfiguration<StatusType>
    {
        public void Configure(EntityTypeBuilder<StatusType> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(20);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.HasMany(u => u.Assignments)
                   .WithOne(ur => ur.StatusType)
                   .HasForeignKey(cu => cu.StatusTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
