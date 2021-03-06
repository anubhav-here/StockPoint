﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Stockpoint.Models;

namespace Stockpoint.Migrations
{
    [DbContext(typeof(InventoryContext))]
    [Migration("20201021122649_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Stockpoint.Models.Category", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("category_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Stockpoint.Models.Inventory", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Categoryid")
                        .HasColumnType("int");

                    b.Property<int>("category_id")
                        .HasColumnType("int");

                    b.Property<string>("date_of_purchase")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("invoice_id")
                        .HasColumnType("int");

                    b.Property<string>("item_model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("item_name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price_per_unit")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.HasKey("id");

                    b.HasIndex("Categoryid");

                    b.ToTable("inventory");
                });

            modelBuilder.Entity("Stockpoint.Models.Inventory", b =>
                {
                    b.HasOne("Stockpoint.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("Categoryid");
                });
#pragma warning restore 612, 618
        }
    }
}
