using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookSalesWebApp.Migrations
{
    public partial class Customer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "books",
                type: "NVARCHAR(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "books",
                type: "NVARCHAR(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address1 = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Address2 = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: true),
                    City = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    Country = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    FirstName = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    LastName = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    PostalCode = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    Province = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "books",
                type: "NVARCHAR(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "Author",
                table: "books",
                type: "NVARCHAR(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(1000)",
                oldMaxLength: 1000);
        }
    }
}
