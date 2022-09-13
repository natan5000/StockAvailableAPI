﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockAvailableAPI.Data;

#nullable disable

namespace StockAvailableAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220911045103_agregandoColumnaType")]
    partial class agregandoColumnaType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("StockAvailableAPI.Models.Box", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productId")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("productId");

                    b.ToTable("boxes");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.Operation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("codeBox")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<int>("typeOperationID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("typeOperationID");

                    b.ToTable("operations");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("active")
                        .HasColumnType("int");

                    b.Property<string>("code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("products");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.TypeOperation", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TypeOperationID")
                        .HasColumnType("int");

                    b.Property<int>("type")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TypeOperationID");

                    b.ToTable("typeOperations");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.Box", b =>
                {
                    b.HasOne("StockAvailableAPI.Models.Product", "Product")
                        .WithMany("Boxes")
                        .HasForeignKey("productId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.Operation", b =>
                {
                    b.HasOne("StockAvailableAPI.Models.TypeOperation", "TypeOperation")
                        .WithMany()
                        .HasForeignKey("typeOperationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeOperation");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.TypeOperation", b =>
                {
                    b.HasOne("StockAvailableAPI.Models.TypeOperation", null)
                        .WithMany("typeOperations")
                        .HasForeignKey("TypeOperationID");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.Product", b =>
                {
                    b.Navigation("Boxes");
                });

            modelBuilder.Entity("StockAvailableAPI.Models.TypeOperation", b =>
                {
                    b.Navigation("typeOperations");
                });
#pragma warning restore 612, 618
        }
    }
}