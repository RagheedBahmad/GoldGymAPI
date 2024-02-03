﻿// <auto-generated />
using System;
using GoldGymAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace GoldGymAPI.Migrations
{
    [DbContext(typeof(GoldGymContext))]
    [Migration("20240130175118_Added_Subscriptions")]
    partial class Added_Subscriptions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GoldGymAPI.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Phone")
                        .HasColumnType("integer");

                    b.Property<DateTime>("createdAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Occupation")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean");

                    b.Property<int>("Wage")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerCount")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Price")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Subscription", b =>
                {
                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<int>("ServiceId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("CustomerId", "ServiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Subscription", b =>
                {
                    b.HasOne("GoldGymAPI.Models.Customer", "Customer")
                        .WithMany("Subscriptions")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GoldGymAPI.Models.Service", "Service")
                        .WithMany("Subscriptions")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Customer", b =>
                {
                    b.Navigation("Subscriptions");
                });

            modelBuilder.Entity("GoldGymAPI.Models.Service", b =>
                {
                    b.Navigation("Subscriptions");
                });
#pragma warning restore 612, 618
        }
    }
}
