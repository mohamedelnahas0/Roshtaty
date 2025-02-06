﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Roshtaty.Repository.Data;

#nullable disable

namespace Roshtaty.Repository.Data.Migrations
{
    [DbContext(typeof(RoshtatyContext))]
    [Migration("20250124154256_AddQuantityStock")]
    partial class AddQuantityStock
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Roshtaty.Core.Entites.Active_Ingredient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActiveIngredientName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("DiseaseId")
                        .HasColumnType("int");

                    b.Property<decimal>("Strength")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("StrengthUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiseaseId");

                    b.ToTable("Active_Ingredients");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MainSystemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MainSystemId");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Disease", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("DiseaseName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Diseases");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Main_System", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("MainSystemName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("main_Systems");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Prescription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Active_IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("Dispensedmedication")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Form")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PatientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("PrescriptionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Prescription_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Active_IngredientId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Trades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Active_IngredientId")
                        .HasColumnType("int");

                    b.Property<string>("AdministrationRoute")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DistributeArea")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Dose")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Indication")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LegalStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ManufactureCountry")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PackageSize")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("PackageTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PharmaceuticalForm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductControl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PublicPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("ShelfLife")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SideEffects")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StorageConditions")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Active_IngredientId");

                    b.ToTable("tradeNames");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Active_Ingredient", b =>
                {
                    b.HasOne("Roshtaty.Core.Entites.Disease", "Disease")
                        .WithMany()
                        .HasForeignKey("DiseaseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Category", b =>
                {
                    b.HasOne("Roshtaty.Core.Entites.Main_System", "MainSystem")
                        .WithMany()
                        .HasForeignKey("MainSystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MainSystem");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Disease", b =>
                {
                    b.HasOne("Roshtaty.Core.Entites.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Prescription", b =>
                {
                    b.HasOne("Roshtaty.Core.Entites.Active_Ingredient", "Active_Ingredient")
                        .WithMany()
                        .HasForeignKey("Active_IngredientId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Active_Ingredient");
                });

            modelBuilder.Entity("Roshtaty.Core.Entites.Trades", b =>
                {
                    b.HasOne("Roshtaty.Core.Entites.Active_Ingredient", "Active_Ingredient")
                        .WithMany()
                        .HasForeignKey("Active_IngredientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Active_Ingredient");
                });
#pragma warning restore 612, 618
        }
    }
}
