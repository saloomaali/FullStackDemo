﻿// <auto-generated />
using System;
using AutoPAS_Customer_portal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AutoPAS_Customer_portal.Migrations
{
    [DbContext(typeof(LocalDbContext))]
    partial class localDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("AutoPAS_Customer_portal.Models.PortalUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Password")
                        .HasColumnType("longtext");

                    b.Property<string>("UserName")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("portalUsers");
                });

            modelBuilder.Entity("AutoPAS_Customer_portal.Models.UserPloicyList", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<int>("PolicyNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("userPloicyList");
                });

            modelBuilder.Entity("AutoPAS_Customer_portal.Models.UserPloicyList", b =>
                {
                    b.HasOne("AutoPAS_Customer_portal.Models.PortalUser", "User")
                        .WithMany("PolicyList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("AutoPAS_Customer_portal.Models.PortalUser", b =>
                {
                    b.Navigation("PolicyList");
                });
#pragma warning restore 612, 618
        }
    }
}
