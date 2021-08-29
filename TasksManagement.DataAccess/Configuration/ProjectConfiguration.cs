using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.HasIndex(x => x.Code).IsUnique();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(10);

            builder.HasMany(t => t.Assignments)
                .WithOne(p => p.Project)
                .HasForeignKey(tp => tp.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
