using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class BookSaleRemoveExtraForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_books_BookFK",
                table: "book_sale_items");

            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleItemFK",
                table: "book_sale_items");

            migrationBuilder.DropForeignKey(
                name: "FK_book_sales_customers_CustomerFK",
                table: "book_sales");

            migrationBuilder.DropIndex(
                name: "IX_book_sales_CustomerFK",
                table: "book_sales");

            migrationBuilder.DropIndex(
                name: "IX_book_sale_items_BookFK",
                table: "book_sale_items");

            migrationBuilder.DropColumn(
                name: "CustomerFK",
                table: "book_sales");

            migrationBuilder.DropColumn(
                name: "BookFK",
                table: "book_sale_items");

            migrationBuilder.RenameColumn(
                name: "BookSaleItemFK",
                table: "book_sale_items",
                newName: "BookSaleID");

            migrationBuilder.RenameIndex(
                name: "IX_book_sale_items_BookSaleItemFK",
                table: "book_sale_items",
                newName: "IX_book_sale_items_BookSaleID");

            migrationBuilder.CreateIndex(
                name: "IX_book_sales_CustomerID",
                table: "book_sales",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_book_sale_items_ISBN",
                table: "book_sale_items",
                column: "ISBN");

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items",
                column: "BookSaleID",
                principalTable: "book_sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_books_ISBN",
                table: "book_sale_items",
                column: "ISBN",
                principalTable: "books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items");

            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_books_ISBN",
                table: "book_sale_items");

            migrationBuilder.DropForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales");

            migrationBuilder.DropIndex(
                name: "IX_book_sales_CustomerID",
                table: "book_sales");

            migrationBuilder.DropIndex(
                name: "IX_book_sale_items_ISBN",
                table: "book_sale_items");

            migrationBuilder.RenameColumn(
                name: "BookSaleID",
                table: "book_sale_items",
                newName: "BookSaleItemFK");

            migrationBuilder.RenameIndex(
                name: "IX_book_sale_items_BookSaleID",
                table: "book_sale_items",
                newName: "IX_book_sale_items_BookSaleItemFK");

            migrationBuilder.AddColumn<int>(
                name: "CustomerFK",
                table: "book_sales",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "BookFK",
                table: "book_sale_items",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_book_sales_CustomerFK",
                table: "book_sales",
                column: "CustomerFK");

            migrationBuilder.CreateIndex(
                name: "IX_book_sale_items_BookFK",
                table: "book_sale_items",
                column: "BookFK");

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_books_BookFK",
                table: "book_sale_items",
                column: "BookFK",
                principalTable: "books",
                principalColumn: "ISBN",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleItemFK",
                table: "book_sale_items",
                column: "BookSaleItemFK",
                principalTable: "book_sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_book_sales_customers_CustomerFK",
                table: "book_sales",
                column: "CustomerFK",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
