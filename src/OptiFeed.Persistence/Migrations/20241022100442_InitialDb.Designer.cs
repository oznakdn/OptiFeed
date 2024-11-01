﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OptiFeed.Persistence.Context;

#nullable disable

namespace OptiFeed.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241022100442_InitialDb")]
    partial class InitialDb
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("OptiFeed.Core.Models.Feed", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("ADFContent")
                        .HasColumnType("float");

                    b.Property<double>("CostPerKg")
                        .HasColumnType("float");

                    b.Property<double>("DryMatter")
                        .HasColumnType("float");

                    b.Property<double>("EnergyContent")
                        .HasColumnType("float");

                    b.Property<double>("MaxUsage")
                        .HasColumnType("float");

                    b.Property<double>("MinUsage")
                        .HasColumnType("float");

                    b.Property<double>("NDFContent")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("ProteinContent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Feeds");
                });
#pragma warning restore 612, 618
        }
    }
}
