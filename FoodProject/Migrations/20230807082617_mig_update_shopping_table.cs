using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Migrations
{
    public partial class mig_update_shopping_table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Foods_FoodID",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_FoodID",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "FoodID",
                table: "Payments");

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Foods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Foods_PaymentId",
                table: "Foods",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Foods_Payments_PaymentId",
                table: "Foods",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "PaymentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Foods_Payments_PaymentId",
                table: "Foods");

            migrationBuilder.DropIndex(
                name: "IX_Foods_PaymentId",
                table: "Foods");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Foods");

            migrationBuilder.AddColumn<int>(
                name: "FoodID",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Payments_FoodID",
                table: "Payments",
                column: "FoodID");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Foods_FoodID",
                table: "Payments",
                column: "FoodID",
                principalTable: "Foods",
                principalColumn: "FoodID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
