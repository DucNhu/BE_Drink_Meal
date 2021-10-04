using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class blogFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "availability",
                table: "Blogers");

            migrationBuilder.RenameColumn(
                name: "desciption",
                table: "Blogers",
                newName: "description");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Blogers",
                newName: "desciption");

            migrationBuilder.AddColumn<int>(
                name: "availability",
                table: "Blogers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
