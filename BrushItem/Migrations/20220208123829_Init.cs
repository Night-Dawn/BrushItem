using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BrushItem.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Blanks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, comment: "题目编号", collation: "ascii_general_ci"),
                    Description = table.Column<string>(type: "longtext", nullable: true, comment: "题目描述")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Analysis = table.Column<string>(type: "longtext", nullable: true, comment: "题目分析")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CorrectAnswer = table.Column<string>(type: "longtext", nullable: true, comment: "正确答案")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "更新时间"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blanks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blanks_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    CorrectAnswer = table.Column<string>(type: "longtext", nullable: true, comment: "正确答案")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "更新时间"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_choice_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SingleChoices",
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
                    CorrectAnswer = table.Column<string>(type: "longtext", nullable: true, comment: "正确答案")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "创建时间"),
                    UpdatedTime = table.Column<DateTime>(type: "datetime(6)", nullable: false, comment: "更新时间"),
                    CategoryId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleChoices_category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Blanks_CategoryId",
                table: "Blanks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_choice_CategoryId",
                table: "choice",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleChoices_CategoryId",
                table: "SingleChoices",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blanks");

            migrationBuilder.DropTable(
                name: "choice");

            migrationBuilder.DropTable(
                name: "SingleChoices");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
