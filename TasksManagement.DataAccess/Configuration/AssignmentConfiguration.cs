using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TasksManagement.Domain;

namespace TasksManagement.DataAccess.Configuration
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.Property(x => x.Description).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Progress).IsRequired();
            builder.Property(x => x.Deadline).IsRequired();
            builder.Property(x => x.ProjectId).IsRequired();
        }
    }
}
