using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class fixmetarial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImgContentFeature");

            migrationBuilder.DropTable(
                name: "ImgStepFeature");

            migrationBuilder.DropColumn(
                name: "unit",
                table: "contents");

            migrationBuilder.AddColumn<string>(
                name: "banner_cover",
                table: "contents",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                table: "Blogers",
                type: "nvarchar(500)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "banner_cover",
                table: "contents");

            migrationBuilder.AddColumn<string>(
                name: "unit",
                table: "contents",
                type: "nvarchar(256)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "summary",
                table: "Blogers",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ImgContentFeature",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar_feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    content_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgContentFeature", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ImgStepFeature",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    avatar_feature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    step_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgStepFeature", x => x.id);
                });
        }
    }
}
