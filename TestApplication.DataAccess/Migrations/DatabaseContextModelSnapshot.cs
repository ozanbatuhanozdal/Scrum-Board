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

                    b.Property<string>("Guid")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)")
                        .HasColumnName("Name");

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.HasKey("UserId");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            CreatedDate = new DateTime(2021, 1, 11, 7, 4, 0, 164, DateTimeKind.Local).AddTicks(9455),
                            Email = "ozanbatuhanozdal@hotmail.com",
                            Guid = "e15bddf8-c087-4ca9-b7ea-5b6bfa6408e8",
                            Name = "Batuhan",
                            PasswordHash = new byte[] { 156, 8, 27, 62, 92, 139, 243, 29, 169, 69, 253, 195, 115, 179, 188, 122, 100, 161, 64, 55, 204, 157, 113, 24, 38, 50, 46, 245, 255, 166, 15, 161, 50, 125, 201, 94, 154, 109, 70, 20, 160, 31, 180, 136, 37, 83, 43, 228, 48, 78, 40, 76, 131, 195, 243, 141, 201, 112, 243, 151, 166, 39, 83, 9 },
                            PasswordSalt = new byte[] { 164, 11, 55, 81, 215, 216, 114, 249, 112, 44, 201, 7, 204, 93, 213, 216, 67, 155, 107, 42, 105, 243, 67, 193, 235, 120, 230, 226, 36, 154, 10, 193, 57, 42, 162, 73, 62, 86, 202, 221, 118, 214, 145, 78, 153, 91, 222, 93, 193, 254, 21, 225, 244, 30, 122, 56, 23, 109, 80, 246, 213, 71, 74, 98, 55, 183, 228, 162, 48, 155, 25, 90, 154, 233, 135, 243, 124, 86, 162, 198, 191, 78, 75, 179, 68, 199, 138, 242, 136, 83, 120, 136, 241, 116, 137, 224, 45, 227, 142, 48, 70, 94, 208, 253, 235, 110, 235, 63, 10, 57, 48, 27, 42, 34, 243, 208, 254, 73, 61, 44, 40, 56, 118, 150, 223, 103, 149, 152 }
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
                    b.Property<int>("UserUserTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("UserId");

                    b.Property<int>("UserTypeId")
                        .HasColumnType("int")
                        .HasColumnName("UserTypeId");

                    b.HasKey("UserUserTypeId");

                    b.HasIndex("UserId");

                    b.HasIndex("UserTypeId");

                    b.ToTable("userUserTypes");

                    b.HasData(
                        new
                        {
                            UserUserTypeId = 1,
                            CreatedDate = new DateTime(2021, 1, 11, 7, 4, 0, 166, DateTimeKind.Local).AddTicks(3204),
                            UserId = 1,
                            UserTypeId = 1
                        });
                });

            modelBuilder.Entity("TestApplication.Entities.Views.UserFullView", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("UserTypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserTypeName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToView("userView");
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
