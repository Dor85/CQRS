using System;
using Company.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;

namespace Company.Project.Persistence.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(e => e.Status).HasColumnType("varchar(10)");

            builder.HasOne(e => e.Responsable);
            builder.HasOne(e => e.Assigned);
        }
    }
}
