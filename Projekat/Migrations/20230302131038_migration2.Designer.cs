﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projekat.Repositories;

#nullable disable

namespace Projekat.Migrations
{
    [DbContext(typeof(RepositoryDbContext))]
    [Migration("20230302131038_migration2")]
    partial class migration2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Client", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Country", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("Country");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("HoursPerWeek")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique()
                        .HasFilter("[Name] IS NOT NULL");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Client", b =>
                {
                    b.HasOne("Projekat.Core.Domain.Entities.Country", "Country")
                        .WithMany("Clients")
                        .HasForeignKey("CountryId");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Country", b =>
                {
                    b.HasOne("Projekat.Core.Domain.Entities.Client", null)
                        .WithMany("Countries")
                        .HasForeignKey("ClientId");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Client", b =>
                {
                    b.Navigation("Countries");
                });

            modelBuilder.Entity("Projekat.Core.Domain.Entities.Country", b =>
                {
                    b.Navigation("Clients");
                });
#pragma warning restore 612, 618
        }
    }
}
