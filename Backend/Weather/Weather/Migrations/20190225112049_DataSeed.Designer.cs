﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Weather.Models;

namespace Weather.Migrations
{
    [DbContext(typeof(dbContext))]
    [Migration("20190225112049_DataSeed")]
    partial class DataSeed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Weather.Models.SavedLocation", b =>
                {
                    b.Property<long>("SavedLocationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CityName");

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.HasKey("SavedLocationId");

                    b.ToTable("SavedLocations");

                    b.HasData(
                        new { SavedLocationId = 1L, CityName = "New Delhi", Latitude = 28.6139, Longitude = 77.209 },
                        new { SavedLocationId = 2L, CityName = "New Delhi", Latitude = 29.0588, Longitude = 29.0588 }
                    );
                });

            modelBuilder.Entity("Weather.Models.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<long>("Mobile");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new { UserId = 1L, Email = "naveen@gmail.com", Mobile = 7053207025L, Name = "Naveen", Password = "asdfghjkl" },
                        new { UserId = 2L, Email = "giriraj@gmail.com", Mobile = 9899320302L, Name = "Giriraj", Password = "asdfghjkl" }
                    );
                });

            modelBuilder.Entity("Weather.Models.UserLocation", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("SavedLocationId");

                    b.Property<long>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SavedLocationId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLocations");

                    b.HasData(
                        new { Id = 1L, SavedLocationId = 1L, UserId = 1L },
                        new { Id = 2L, SavedLocationId = 2L, UserId = 2L }
                    );
                });

            modelBuilder.Entity("Weather.Models.UserLocation", b =>
                {
                    b.HasOne("Weather.Models.SavedLocation", "SavedLocation")
                        .WithMany("UserLocations")
                        .HasForeignKey("SavedLocationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Weather.Models.User", "User")
                        .WithMany("UserLocations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}