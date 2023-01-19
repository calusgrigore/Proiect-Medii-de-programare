﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TelefoaneOnline.Data;

#nullable disable

namespace TelefoaneOnline.Migrations
{
    [DbContext(typeof(TelefoaneOnlineContext))]
    [Migration("20230119183858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("TelefoaneOnline.Models.Categorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CategorieProdus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Culoare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("CuloareProdus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Culoare");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Cumparat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("DataAchizitie")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TelefonID")
                        .HasColumnType("int");

                    b.Property<int?>("UtilizatorID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("TelefonID");

                    b.HasIndex("UtilizatorID");

                    b.ToTable("Cumparat");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Memorie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("MemorieProdus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Memorie");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.MemorieInterna", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("MemorieID")
                        .HasColumnType("int");

                    b.Property<int>("TelefonID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MemorieID");

                    b.HasIndex("TelefonID");

                    b.ToTable("MemorieInterna");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Telefon", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int?>("CategorieID")
                        .HasColumnType("int");

                    b.Property<int?>("CuloareID")
                        .HasColumnType("int");

                    b.Property<string>("Denumire")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiagDisplay")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MemorieID")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CategorieID");

                    b.HasIndex("CuloareID");

                    b.HasIndex("MemorieID");

                    b.ToTable("Telefon");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Utilizator", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresa")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Utilizator");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Cumparat", b =>
                {
                    b.HasOne("TelefoaneOnline.Models.Telefon", "Telefon")
                        .WithMany()
                        .HasForeignKey("TelefonID");

                    b.HasOne("TelefoaneOnline.Models.Utilizator", "Utilizator")
                        .WithMany("Cumparate")
                        .HasForeignKey("UtilizatorID");

                    b.Navigation("Telefon");

                    b.Navigation("Utilizator");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.MemorieInterna", b =>
                {
                    b.HasOne("TelefoaneOnline.Models.Memorie", "Memorie")
                        .WithMany("MemoriiInterne")
                        .HasForeignKey("MemorieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TelefoaneOnline.Models.Telefon", "Telefon")
                        .WithMany()
                        .HasForeignKey("TelefonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Memorie");

                    b.Navigation("Telefon");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Telefon", b =>
                {
                    b.HasOne("TelefoaneOnline.Models.Categorie", "Categorie")
                        .WithMany("Telefoane")
                        .HasForeignKey("CategorieID");

                    b.HasOne("TelefoaneOnline.Models.Culoare", "Culoare")
                        .WithMany("Telefoane")
                        .HasForeignKey("CuloareID");

                    b.HasOne("TelefoaneOnline.Models.Memorie", "Memorie")
                        .WithMany()
                        .HasForeignKey("MemorieID");

                    b.Navigation("Categorie");

                    b.Navigation("Culoare");

                    b.Navigation("Memorie");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Categorie", b =>
                {
                    b.Navigation("Telefoane");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Culoare", b =>
                {
                    b.Navigation("Telefoane");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Memorie", b =>
                {
                    b.Navigation("MemoriiInterne");
                });

            modelBuilder.Entity("TelefoaneOnline.Models.Utilizator", b =>
                {
                    b.Navigation("Cumparate");
                });
#pragma warning restore 612, 618
        }
    }
}
