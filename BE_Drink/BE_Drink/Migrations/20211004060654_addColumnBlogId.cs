using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class addColumnBlogId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "blog_id",
                table: "Step",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "blog_id",
                table: "metarials",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "blog_id",
                table: "contents",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "blog_id",
                table: "Step");

            migrationBuilder.DropColumn(
                name: "blog_id",
                table: "metarials");

            migrationBuilder.DropColumn(
                name: "blog_id",
                table: "contents");
        }
    }
}
