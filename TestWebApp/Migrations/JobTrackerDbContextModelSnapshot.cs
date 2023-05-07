﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestWebApp.Data;

#nullable disable

namespace TestWebApp.Migrations
{
    [DbContext(typeof(JobTrackerDbContext))]
    partial class JobTrackerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TestWebApp.Models.Application", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Source")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("TestWebApp.Models.JobDesc", b =>
                {
                    b.Property<int>("JobDescId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobDescId"));

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("JobDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobDescId");

                    b.HasIndex("ApplicationId")
                        .IsUnique()
                        .HasFilter("[ApplicationId] IS NOT NULL");

                    b.ToTable("JobDescs");
                });

            modelBuilder.Entity("TestWebApp.Models.JobDesc", b =>
                {
                    b.HasOne("TestWebApp.Models.Application", "Application")
                        .WithOne("JobDesc")
                        .HasForeignKey("TestWebApp.Models.JobDesc", "ApplicationId");

                    b.Navigation("Application");
                });

            modelBuilder.Entity("TestWebApp.Models.Application", b =>
                {
                    b.Navigation("JobDesc")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
