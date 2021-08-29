using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Name).IsUnique();
            builder.HasMany(u => u.Users)
                    .WithOne(ur => ur.Role)
                    .HasForeignKey(cu => cu.RoleId)
                    .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
