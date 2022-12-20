﻿// <auto-generated />
using System;
using EFCoreCodeFirstTogether.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreCodeFirstTogether.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221123124921_Connected Person to County")]
    partial class ConnectedPersontoCounty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.County", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("County");
                });

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DueDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("Invoice");
                });

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<int>("CountyId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("ShoeSize")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CountyId");

                    b.ToTable("Person");
                });

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.Invoice", b =>
                {
                    b.HasOne("EFCoreCodeFirstTogether.Data.Person", null)
                        .WithMany("Invoices")
                        .HasForeignKey("PersonId");
                });

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.Person", b =>
                {
                    b.HasOne("EFCoreCodeFirstTogether.Data.County", "County")
                        .WithMany()
                        .HasForeignKey("CountyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("County");
                });

            modelBuilder.Entity("EFCoreCodeFirstTogether.Data.Person", b =>
                {
                    b.Navigation("Invoices");
                });
#pragma warning restore 612, 618
        }
    }
}
