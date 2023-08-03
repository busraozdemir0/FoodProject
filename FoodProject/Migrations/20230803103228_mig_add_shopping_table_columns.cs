using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Migrations
{
    public partial class mig_add_shopping_table_columns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ShoppingDate",
                table: "Shoppings",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ShoppingQuantity",
                table: "Shoppings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "ShoppingTotal",
                table: "Shoppings",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ShoppingDate",
                table: "Shoppings");

            migrationBuilder.DropColumn(
                name: "ShoppingQuantity",
                table: "Shoppings");

            migrationBuilder.DropColumn(
                name: "ShoppingTotal",
                table: "Shoppings");
        }
    }
}
