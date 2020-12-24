using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.Entities;
using TestApplication.Entities.Models;

namespace TestApplication.DataAccess.EntityFrameworkCore
{
    public class DatabaseContext : DbContext
    {

        // Entity Modellerimizi  database'e tanıtıyoruz
        public DbSet<User> User { get; set; }

        public DbSet<CustomerCard> CustomerCard { get; set; }

        public DbSet<CustomerCardRow> CustomerCardRow { get; set; }

        public DbSet<Customer> Customer { get; set; }

        public DbSet<UserType> UserType { get; set; }
        
        public DbSet<UserUserType> userUserTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Batuhan Connection String
           optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DevelopmentPath;Trusted_Connection=True;");
            //Deniz Connection String
         //   optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS;Database=DevelopmentPath;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            UserType UserTypes = new()
            {
                UserTypeId = 1,
                UserTypeName = "admin",
                UserTypeDescription = "admin"
            };

            modelBuilder.Entity<UserType>().HasData(UserTypes);

            User users = new()
            {
                UserId = 1,
                Name = "Batuhan",
                Password = "123",
                Email = "ozanbatuhanozdal@hotmail.com"
            };
                
           modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<UserUserType>().HasData(new UserUserType { UserUserTypeId = 1, UserId=1 ,UserTypeId =1 });
        }


    }
}
