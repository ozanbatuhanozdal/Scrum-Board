﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestApplication.DataAccess.EntityFrameworkCore;

namespace TestApplication.DataAccess.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("TestApplication.Entities.CustomerCardRow", b =>
                {
                    b.Property<int>("CustomerCardRowId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerCardId")
                        .HasColumnType("int")
                        .HasColumnName("CustomerCardId");

                    b.Property<string>("DeveloperName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("DeveloperName");

                    b.Property<string>("Explanation")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Explanation");

                    b.Property<DateTime>("FinishedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Priorty")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Priorty");

                    b.Property<int>("ProgressId")
                        .HasColumnType("int");

                    b.HasKey("CustomerCardRowId");

                    b.HasIndex("CustomerCardId");

                    b.ToTable("CustomerCardRow");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)")
                        .HasColumnName("CustomerAddress");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("CustomerName");

                    b.Property<string>("CustomerPhone")
                        .IsRequired()
                        .HasMaxLength(11)
                        .IsUnicode(false)
                        .HasColumnType("varchar(11)")
                        .HasColumnName("CustomerPhone");

                    b.HasKey("CustomerId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.CustomerCard", b =>
                {
                    b.Property<int>("CustomerCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("CustomerCardId")
                        .UseIdentityColumn();

                    b.Property<double>("CostOfCardTime")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerCardName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("CustomerCardName");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("ProductManagerName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("ProductManagerName");

                    b.HasKey("CustomerCardId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CustomerCard");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("UserId")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("eMail");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("password");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2021, 1, 10, 22, 31, 41, 235, DateTimeKind.Local).AddTicks(8090),
                            Email = "ozanbatuhanozdal@hotmail.com",
                            Name = "Batuhan",
                            Password = "123"
                        });
                });

            modelBuilder.Entity("TestApplication.Entities.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userTypeId")
                        .UseIdentityColumn();

                    b.Property<string>("UserTypeDescription")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("userTypeDescription");

                    b.Property<string>("UserTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("userTypeName");

                    b.HasKey("UserTypeId");

                    b.ToTable("UserType");

                    b.HasData(
                        new
                        {
                            UserTypeId = 1,
                            UserTypeDescription = "admin",
                            UserTypeName = "admin"
                        });
                });

            modelBuilder.Entity("TestApplication.Entities.Models.UserUserType", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeId");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserUserTypeId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "UserTypeId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("userUserTypes");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            UserTypeId = 1,
                            CreatedDate = new DateTime(2021, 1, 10, 22, 31, 41, 236, DateTimeKind.Local).AddTicks(7447),
                            UserUserTypeId = 1
                        });
                });

            modelBuilder.Entity("TestApplication.Entities.CustomerCardRow", b =>
                {
                    b.HasOne("TestApplication.Entities.Models.CustomerCard", null)
                        .WithMany("CustomerCardRow")
                        .HasForeignKey("CustomerCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApplication.Entities.Models.CustomerCard", b =>
                {
                    b.HasOne("TestApplication.Entities.Models.Customer", null)
                        .WithMany("CustomerCards")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestApplication.Entities.Models.UserUserType", b =>
                {
                    b.HasOne("TestApplication.Entities.Models.User", "user")
                        .WithMany("userUserTypes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestApplication.Entities.Models.UserType", "userType")
                        .WithMany("userUserTypes")
                        .HasForeignKey("UserTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");

                    b.Navigation("userType");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.Customer", b =>
                {
                    b.Navigation("CustomerCards");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.CustomerCard", b =>
                {
                    b.Navigation("CustomerCardRow");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.User", b =>
                {
                    b.Navigation("userUserTypes");
                });

            modelBuilder.Entity("TestApplication.Entities.Models.UserType", b =>
                {
                    b.Navigation("userUserTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
