﻿// <auto-generated />
using System;
using Company.Project.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Company.Project.Persistence.Migrations
{
    [DbContext(typeof(TaskDbContext))]
    [Migration("20191013144512_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Company.Project.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("LastModifiedBy");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("People");
                });

            modelBuilder.Entity("Company.Project.Domain.Entities.Task", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AssignedId");

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime?>("LastModified");

                    b.Property<string>("LastModifiedBy");

                    b.Property<int?>("ResposableId");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("AssignedId");

                    b.HasIndex("ResposableId");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("Company.Project.Domain.Entities.Person", b =>
                {
                    b.OwnsOne("Company.Project.Domain.ValueObjects.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PersonId");

                            b1.HasKey("PersonId");

                            b1.ToTable("People");

                            b1.HasOne("Company.Project.Domain.Entities.Person")
                                .WithOne("Address")
                                .HasForeignKey("Company.Project.Domain.ValueObjects.Address", "PersonId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Company.Project.Domain.Entities.Task", b =>
                {
                    b.HasOne("Company.Project.Domain.Entities.Person", "Assigned")
                        .WithMany()
                        .HasForeignKey("AssignedId");

                    b.HasOne("Company.Project.Domain.Entities.Person", "Resposable")
                        .WithMany()
                        .HasForeignKey("ResposableId");
                });
#pragma warning restore 612, 618
        }
    }
}
