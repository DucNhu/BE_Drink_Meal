using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class full_product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "availability",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "category_id",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "create_at",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "desciption",
                table: "products",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "returned",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "revenue",
                table: "products",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "sale",
                table: "products",
                type: "money",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "seller_id",
                table: "products",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "storage_instructions",
                table: "products",
                type: "nvarchar(500)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "products",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "update_at",
                table: "products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "view",
                table: "products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability",
                table: "products");

            migrationBuilder.DropColumn(
                name: "category_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "create_at",
                table: "products");

            migrationBuilder.DropColumn(
                name: "desciption",
                table: "products");

            migrationBuilder.DropColumn(
                name: "returned",
                table: "products");

            migrationBuilder.DropColumn(
                name: "revenue",
                table: "products");

            migrationBuilder.DropColumn(
                name: "sale",
                table: "products");

            migrationBuilder.DropColumn(
                name: "seller_id",
                table: "products");

            migrationBuilder.DropColumn(
                name: "status",
                table: "products");

            migrationBuilder.DropColumn(
                name: "storage_instructions",
                table: "products");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "products");

            migrationBuilder.DropColumn(
                name: "update_at",
                table: "products");

            migrationBuilder.DropColumn(
                name: "view",
                table: "products");
        }
    }
}
