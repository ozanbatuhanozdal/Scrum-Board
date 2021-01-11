﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TestApplication.DataAccess.Mapping;
using TestApplication.Entities;
using TestApplication.Entities.Models;
using TestApplication.Entities.Views;

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

        public virtual DbSet<UserFullView> userFullView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            //update-database
            //connection stringini ekleyip diğerlerini yorum satırı haline getiriniz.
            //update-database -- TestApplication-DataAccess
            // Batuhan Connection String
           optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=DevelopmentPath;Trusted_Connection=True;");
            //Deniz Connection String
           // optionsBuilder.UseSqlServer("Server=ASUS\\SQLEXPRESS;Database=DevelopmentPath;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //mapping claslarımızı dahil ediyoruz.
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new UserTypeMap());
            modelBuilder.ApplyConfiguration(new UserUserTypeMap());
            modelBuilder.ApplyConfiguration(new CustomerMap());
            modelBuilder.ApplyConfiguration(new CustomerCardMap());
            modelBuilder.ApplyConfiguration(new CustomerCardRowMap());

           //hazır bir usertype
            UserType UserTypes = new()
            {
                UserTypeId = 1,
                UserTypeName = "admin",
                UserTypeDescription = "admin"
            };

            modelBuilder.Entity<UserType>().HasData(UserTypes);

            //hazır bir kullanıcı
            User users = new()
            {
                UserId = 1,
                Name = "Batuhan",
                Password = "123",
                Email = "ozanbatuhanozdal@hotmail.com"
            };
                
           modelBuilder.Entity<User>().HasData(users);


            //belirtilen varlığa geçişler için çekirdek verileri sağlamaya 
            //yardımcı olmak için tasarlanmıştır.
            modelBuilder.Entity<UserUserType>().HasData(new UserUserType { UserUserTypeId = 1, UserId=1 ,UserTypeId =1 });
            modelBuilder.Entity<UserFullView>(x =>
            {
                x.HasKey(e => e.UserId);
                x.ToView("userView");
                x.Property(x => x.Name).HasMaxLength(50);
            });
        }


    }
}
