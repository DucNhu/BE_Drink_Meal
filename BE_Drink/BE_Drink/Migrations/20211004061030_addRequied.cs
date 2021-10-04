using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class addRequied : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Blogers",
                type: "nvarchar(256)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "Blogers",
                type: "nvarchar(256)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)");
        }
    }
}
