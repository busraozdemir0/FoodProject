using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodProject.Migrations
{
    public partial class mig_contact_table_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ContactSubject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactSubject",
                table: "Contacts");
        }
    }
}
