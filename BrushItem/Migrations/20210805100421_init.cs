using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrushItem.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    username = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "choice",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "题目编号", collation: "ascii_general_ci"),
                    optionA = table.Column<string>(type: "longtext", nullable: true, comment: "选项A")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    optionB = table.Column<string>(type: "longtext", nullable: true, comment: "选项B")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    optionC = table.Column<string>(type: "longtext", nullable: true, comment: "选项C")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    optionD = table.Column<string>(type: "longtext", nullable: true, comment: "选项D")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true, comment: "题目描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Analysis = table.Column<string>(type: "longtext", nullable: true, comment: "题目分析")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: true, comment: "更新时间"),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_choice_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_choice_CategoryId",
                table: "choice",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "choice");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
