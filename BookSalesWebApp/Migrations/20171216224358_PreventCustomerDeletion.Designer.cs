﻿// <auto-generated />
using BookSalesWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BookSalesWebApp.Migrations
{
    [DbContext(typeof(BookSalesWebAppContext))]
    [Migration("20171216224358_PreventCustomerDeletion")]
    partial class PreventCustomerDeletion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BookSalesWebApp.Models.Book", b =>
                {
                    b.Property<string>("ISBN")
                        .HasColumnType("VARCHAR(13)")
                        .HasMaxLength(13);

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.Property<decimal>("ListPrice");

                    b.Property<DateTime>("ReleaseDate");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(1000)")
                        .HasMaxLength(1000);

                    b.HasKey("ISBN");

                    b.ToTable("books");
                });

            modelBuilder.Entity("BookSalesWebApp.Models.BookSale", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerID");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("book_sales");
                });

            modelBuilder.Entity("BookSalesWebApp.Models.BookSaleItem", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BookSaleID");

                    b.Property<string>("ISBN")
                        .HasColumnType("VARCHAR(13)");

                    b.Property<long>("Quantity");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("ID");

                    b.HasIndex("BookSaleID");

                    b.HasIndex("ISBN");

                    b.ToTable("book_sale_items");
                });

            modelBuilder.Entity("BookSalesWebApp.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address1")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Address2")
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Province")
                        .IsRequired()
                        .HasColumnType("NVARCHAR(300)")
                        .HasMaxLength(300);

                    b.HasKey("ID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("BookSalesWebApp.Models.BookSale", b =>
                {
                    b.HasOne("BookSalesWebApp.Models.Customer", "Customer")
                        .WithMany("BookSales")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("BookSalesWebApp.Models.BookSaleItem", b =>
                {
                    b.HasOne("BookSalesWebApp.Models.BookSale", "BookSale")
                        .WithMany("BookSaleItems")
                        .HasForeignKey("BookSaleID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BookSalesWebApp.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("ISBN");
                });
#pragma warning restore 612, 618
        }
    }
}
