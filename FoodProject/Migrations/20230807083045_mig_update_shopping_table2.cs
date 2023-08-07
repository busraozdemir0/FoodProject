using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Migrations
{
    public partial class mig_update_shopping_table2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
