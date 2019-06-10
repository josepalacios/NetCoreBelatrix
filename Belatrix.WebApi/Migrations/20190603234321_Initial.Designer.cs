﻿// <auto-generated />
using System;
using Belatrix.WebApi.Repository.Postgresql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Belatrix.WebApi.Migrations
{
    [DbContext(typeof(BelatrixDbContext))]
    [Migration("20190603234321_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Belatrix.WebApi.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("first_name")
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnName("last_name")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("LastName", "FirstName")
                        .HasName("customer_name__idx");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CustomerId");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnName("order_date");

                    b.Property<string>("OrderNumber")
                        .IsRequired()
                        .HasColumnName("order_number");

                    b.Property<decimal?>("TotalAmount")
                        .IsRequired()
                        .HasColumnName("total_amount");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .HasName("order__customer_id__idx");

                    b.HasIndex("OrderDate")
                        .HasName("order__order_date__idx");

                    b.ToTable("order");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("OrderId");

                    b.Property<int>("ProductId");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .HasName("order_item__order_id__idx");

                    b.HasIndex("ProductId")
                        .HasName("order_item__product_id__idx");

                    b.ToTable("order_item");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<bool>("IsDiscontinued")
                        .HasColumnName("is_discontinued");

                    b.Property<string>("Package")
                        .IsRequired()
                        .HasColumnName("package")
                        .HasMaxLength(30);

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnName("product_name")
                        .HasMaxLength(50);

                    b.Property<int>("SupplierId");

                    b.Property<decimal?>("UnitPrice")
                        .IsRequired()
                        .HasColumnName("unit_price");

                    b.HasKey("Id");

                    b.HasIndex("ProductName")
                        .HasName("product_name__idx");

                    b.HasIndex("SupplierId")
                        .HasName("product_supplier_id__idx");

                    b.ToTable("product");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnName("city")
                        .HasMaxLength(40);

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnName("company_name")
                        .HasMaxLength(40);

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnName("contact_name")
                        .HasMaxLength(50);

                    b.Property<string>("ContactTitle")
                        .IsRequired()
                        .HasColumnName("contact_title")
                        .HasMaxLength(40);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnName("country")
                        .HasMaxLength(40);

                    b.Property<string>("Fax")
                        .IsRequired()
                        .HasColumnName("fax")
                        .HasMaxLength(30);

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnName("phone")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("CompanyName")
                        .HasName("supplier_name__idx");

                    b.HasIndex("Country")
                        .HasName("supplier_country__idx");

                    b.ToTable("supplier");
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Order", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId")
                        .HasConstraintName("customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.OrderItem", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .HasConstraintName("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Belatrix.WebApi.Models.Product", "Product")
                        .WithMany("OrderItem")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Belatrix.WebApi.Models.Product", b =>
                {
                    b.HasOne("Belatrix.WebApi.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId")
                        .HasConstraintName("supplier_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
