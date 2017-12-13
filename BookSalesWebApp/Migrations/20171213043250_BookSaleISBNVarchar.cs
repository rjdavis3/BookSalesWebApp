using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class BookSaleISBNVarchar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "book_sale_items",
                type: "VARCHAR(13)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "book_sale_items",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(13)",
                oldNullable: true);
        }
    }
}
