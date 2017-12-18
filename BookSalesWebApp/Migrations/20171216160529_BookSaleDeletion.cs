using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class BookSaleDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items");

            migrationBuilder.AlterColumn<int>(
                name: "BookSaleID",
                table: "book_sale_items",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items",
                column: "BookSaleID",
                principalTable: "book_sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items");

            migrationBuilder.AlterColumn<int>(
                name: "BookSaleID",
                table: "book_sale_items",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_book_sale_items_book_sales_BookSaleID",
                table: "book_sale_items",
                column: "BookSaleID",
                principalTable: "book_sales",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
