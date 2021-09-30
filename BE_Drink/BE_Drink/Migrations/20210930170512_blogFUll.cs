using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BE_Drink.Migrations
{
    public partial class blogFUll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogClass");

            migrationBuilder.CreateTable(
                name: "Blogers",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    banner_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cover_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cooking_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    summary = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    desciption = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    availability = table.Column<int>(type: "int", nullable: false),
                    url_video_utube = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    view = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogers", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogers");

            migrationBuilder.CreateTable(
                name: "BlogClass",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    availability = table.Column<int>(type: "int", nullable: false),
                    banner_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    category_id = table.Column<int>(type: "int", nullable: false),
                    cooking_time = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cover_img = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    create_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    desciption = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    status = table.Column<int>(type: "int", nullable: false),
                    summary = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    update_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    url_video_utube = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    user_id = table.Column<string>(type: "nvarchar(256)", nullable: true),
                    view = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogClass", x => x.id);
                });
        }
    }
}
