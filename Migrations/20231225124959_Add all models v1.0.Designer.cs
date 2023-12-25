﻿// <auto-generated />
using System;
using HR_System.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HR_System.Migrations
{
    [DbContext(typeof(HRSystemDbContext))]
    [Migration("20231225124959_Add all models v1.0")]
    partial class Addallmodelsv10
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HR_System.Models.Job", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("OpenUntil")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Jobs");
                });

            modelBuilder.Entity("HR_System.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("JobId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float?>("Salary")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("JobId");

                    b.ToTable("Person");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("HR_System.Models.Applicant", b =>
                {
                    b.HasBaseType("HR_System.Models.Person");

                    b.Property<string>("CV")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MilitaryStatus")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Applicant");
                });

            modelBuilder.Entity("HR_System.Models.Employee", b =>
                {
                    b.HasBaseType("HR_System.Models.Person");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("HR_System.Models.Person", b =>
                {
                    b.HasOne("HR_System.Models.Job", "Job")
                        .WithMany("people")
                        .HasForeignKey("JobId");

                    b.Navigation("Job");
                });

            modelBuilder.Entity("HR_System.Models.Job", b =>
                {
                    b.Navigation("people");
                });
#pragma warning restore 612, 618
        }
    }
}