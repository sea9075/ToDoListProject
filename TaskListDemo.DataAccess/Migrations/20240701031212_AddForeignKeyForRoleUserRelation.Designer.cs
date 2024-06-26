﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskListDemo.DataAccess.Data;

#nullable disable

namespace TaskListDemo.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240701031212_AddForeignKeyForRoleUserRelation")]
    partial class AddForeignKeyForRoleUserRelation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0-preview.5.24306.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskListDemo.Models.JobList", b =>
                {
                    b.Property<int>("JobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("JobId"));

                    b.Property<DateTime?>("Completed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Confirmed_at")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("JobId");

                    b.ToTable("JobLists");

                    b.HasData(
                        new
                        {
                            JobId = 1,
                            Created_at = new DateTime(2024, 7, 1, 11, 12, 11, 415, DateTimeKind.Local).AddTicks(8951),
                            Description = "剛才突然不能上網",
                            Status = 0,
                            Title = "無法上網"
                        },
                        new
                        {
                            JobId = 2,
                            Created_at = new DateTime(2024, 7, 1, 11, 12, 11, 417, DateTimeKind.Local).AddTicks(2748),
                            Description = "剛剛突然關機，無法重開",
                            Status = 0,
                            Title = "無法開機"
                        });
                });

            modelBuilder.Entity("TaskListDemo.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayNum")
                        .HasColumnType("int");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayNum = 1,
                            RoleName = "管理員"
                        },
                        new
                        {
                            Id = 2,
                            DisplayNum = 2,
                            RoleName = "工程師"
                        },
                        new
                        {
                            Id = 3,
                            DisplayNum = 3,
                            RoleName = "使用者"
                        });
                });

            modelBuilder.Entity("TaskListDemo.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "admin@tasklist.com",
                            Password = "kkk123456",
                            RoleId = 1,
                            UserName = "Admin"
                        },
                        new
                        {
                            UserId = 2,
                            Email = "engineer@tasklist.com",
                            Password = "kkk123456",
                            RoleId = 2,
                            UserName = "Engineer"
                        },
                        new
                        {
                            UserId = 3,
                            Email = "user@tasklist.com",
                            Password = "kkk123456",
                            RoleId = 3,
                            UserName = "User"
                        });
                });

            modelBuilder.Entity("TaskListDemo.Models.User", b =>
                {
                    b.HasOne("TaskListDemo.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });
#pragma warning restore 612, 618
        }
    }
}
