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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Batuhan Connection String
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DevelopmentPath;Trusted_Connection=True;");
        }
        


    }
}
