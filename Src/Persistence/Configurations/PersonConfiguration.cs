using Company.Project.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Company.Project.Persistence.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.Property(e => e.Id)
                .ValueGeneratedOnAdd();

            builder.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(30);
            builder.Property(e => e.LastName)
                .IsRequired()
                .HasMaxLength(30);

            builder
                .OwnsOne(e => e.Address)
                .Property(p => p.Street)
                .HasColumnName("Street");
            builder
                .OwnsOne(e => e.Address)
                .Property(p => p.City)
                .HasColumnName("City");
            builder
                .OwnsOne(e => e.Address)
                .Property(p => p.State)
                .HasColumnName("State");
            builder
                .OwnsOne(e => e.Address)
                .Property(p => p.Country)
                .HasColumnName("Country");
            builder
                .OwnsOne(e => e.Address)
                .Property(p => p.ZipCode)
                .HasColumnName("ZipCode");


        }
    }
}
