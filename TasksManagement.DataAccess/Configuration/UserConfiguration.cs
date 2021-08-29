using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(x => x.Username).IsRequired();
            builder.HasIndex(x => x.Username).IsUnique();
            builder.Property(x => x.Username).HasMaxLength(30);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(30);
            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Password).IsRequired();
            builder.HasMany(t => t.Assignments)
                   .WithOne(u => u.User)
                   .HasForeignKey(tu => tu.UserId);


        }
    }
}
