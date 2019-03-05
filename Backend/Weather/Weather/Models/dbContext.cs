using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Weather.Models;
namespace Weather.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<SavedLocation> SavedLocations { get; set; }
        public DbSet<UserLocation> UserLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Name = "Naveen",
                Email = "naveen@gmail.com",
                Password = "asdfghjkl",
                Mobile = 7053207025
                

            }, new User
            {
                UserId = 2,
                Name = "Giriraj",
                Email = "giriraj@gmail.com",
                Password = "asdfghjkl",
                Mobile = 9899320302
            });

            modelBuilder.Entity<SavedLocation>().HasData(new SavedLocation
            {
                SavedLocationId = 1,
                CityName = "New Delhi",
                Latitude = 28.6139,
                Longitude = 77.2090



            }, new SavedLocation
            {
                SavedLocationId = 2,
                CityName = "Haryana",
                Latitude = 29.0588,
                Longitude = 76.0856
            });
            modelBuilder.Entity<UserLocation>().HasData(new UserLocation
            {
                Id=1,
                UserId=1,
                SavedLocationId=1


            }, new UserLocation
            {
                Id = 2,
                UserId = 2,
                SavedLocationId = 2
            });
        }
    }

}
