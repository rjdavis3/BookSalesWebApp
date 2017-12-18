using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class PreventCustomerDeletion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales");

            migrationBuilder.AddForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales");

            migrationBuilder.AddForeignKey(
                name: "FK_book_sales_customers_CustomerID",
                table: "book_sales",
                column: "CustomerID",
                principalTable: "customers",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
