﻿// <auto-generated />
using System;
using CompanyAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CompanyAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230725120614_addUsersToDB")]
    partial class addUsersToDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CompanyAPI.Model.Organization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CellNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Iban")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mbs")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Oib")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Website")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Organizations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CellNumber = "098/888555",
                            City = "Zagreb",
                            CompanyName = "AB Gradnja",
                            Country = "Hrvatska",
                            CreatedTime = new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2195),
                            Email = "info@ab.hr",
                            Fax = "01/888555",
                            Iban = "HR012345678998787121",
                            Mbs = "012345648",
                            Oib = "123456",
                            Phone = "01/888555",
                            PostNumber = "1000",
                            Street = "Ilica 12",
                            Website = "www/ab.hr"
                        },
                        new
                        {
                            Id = 2,
                            CellNumber = "098/999252",
                            City = "Zagreb",
                            CompanyName = "CD Gradnja",
                            Country = "Hrvatska",
                            CreatedTime = new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2254),
                            Email = "info@cd.hr",
                            Fax = "01/999252",
                            Iban = "HR0123456789264581",
                            Mbs = "01234564897",
                            Oib = "1234564587",
                            Phone = "01/999252",
                            PostNumber = "10000",
                            Street = "Ilica 152",
                            Website = "www/cd.hr"
                        },
                        new
                        {
                            Id = 3,
                            CellNumber = "098/2255663",
                            City = "Zagreb",
                            CompanyName = "Adria",
                            Country = "Hrvatska",
                            CreatedTime = new DateTime(2023, 7, 25, 14, 6, 14, 891, DateTimeKind.Local).AddTicks(2257),
                            Email = "info@2255663.hr",
                            Fax = "01/2255663",
                            Iban = "HR012345676543210",
                            Mbs = "9876543210",
                            Oib = "9874563210",
                            Phone = "01/2255663",
                            PostNumber = "10000",
                            Street = "Selska ulica 15",
                            Website = "www/adria.hr"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}