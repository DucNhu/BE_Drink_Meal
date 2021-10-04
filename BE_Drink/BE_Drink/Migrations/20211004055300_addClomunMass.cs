using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class addClomunMass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "metarials");

            migrationBuilder.AddColumn<int>(
                name: "mass",
                table: "metarials",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "mass",
                table: "metarials");

            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "metarials",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
