using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class BookSale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "book_sales",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CustomerFK = table.Column<int>(nullable: false),
                    CustomerID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_sales", x => x.ID);
                    table.ForeignKey(
                        name: "FK_book_sales_customers_CustomerFK",
                        column: x => x.CustomerFK,
                        principalTable: "customers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "book_sale_items",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BookFK = table.Column<string>(nullable: true),
                    BookSaleItemFK = table.Column<int>(nullable: true),
                    ISBN = table.Column<int>(nullable: false),
                    Quantity = table.Column<long>(nullable: false),
                    TotalPrice = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_book_sale_items", x => x.ID);
                    table.ForeignKey(
                        name: "FK_book_sale_items_books_BookFK",
                        column: x => x.BookFK,
                        principalTable: "books",
                        principalColumn: "ISBN",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_book_sale_items_book_sales_BookSaleItemFK",
                        column: x => x.BookSaleItemFK,
                        principalTable: "book_sales",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_sale_items_BookFK",
                table: "book_sale_items",
                column: "BookFK");

            migrationBuilder.CreateIndex(
                name: "IX_book_sale_items_BookSaleItemFK",
                table: "book_sale_items",
                column: "BookSaleItemFK");

            migrationBuilder.CreateIndex(
                name: "IX_book_sales_CustomerFK",
                table: "book_sales",
                column: "CustomerFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_sale_items");

            migrationBuilder.DropTable(
                name: "book_sales");
        }
    }
}
