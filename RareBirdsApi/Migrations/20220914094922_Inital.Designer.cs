﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RareBirdsApi.Models;

#nullable disable

namespace RareBirdsApi.Migrations
{
    [DbContext(typeof(RareBirdsDbContext))]
    [Migration("20220914094922_Inital")]
    partial class Inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RareBirdsApi.Models.Bird", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Genus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(24)");

                    b.Property<string>("Species")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Birds");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Genus = "Perdix",
                            NickName = "Grey Patridge",
                            Rarity = "Red",
                            Species = "Perdix"
                        },
                        new
                        {
                            Id = 2,
                            Genus = "Cuculus",
                            NickName = "Cuckoo",
                            Rarity = "Red",
                            Species = "Canorus"
                        });
                });

            modelBuilder.Entity("RareBirdsApi.Models.Sighting", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BirdId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateSighted")
                        .HasColumnType("datetime2");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longditude")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BirdId");

                    b.ToTable("Sightings");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirdId = 1,
                            DateSighted = new DateTime(2022, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = -4.1638948895306491,
                            Longditude = 50.960933075310408
                        },
                        new
                        {
                            Id = 2,
                            BirdId = 1,
                            DateSighted = new DateTime(2022, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Latitude = -5.1638948895306491,
                            Longditude = 51.960933075310408
                        });
                });

            modelBuilder.Entity("RareBirdsApi.Models.Sighting", b =>
                {
                    b.HasOne("RareBirdsApi.Models.Bird", "Bird")
                        .WithMany("Sightings")
                        .HasForeignKey("BirdId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bird");
                });

            modelBuilder.Entity("RareBirdsApi.Models.Bird", b =>
                {
                    b.Navigation("Sightings");
                });
#pragma warning restore 612, 618
        }
    }
}
