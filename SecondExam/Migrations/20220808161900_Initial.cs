using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondExam.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedMaterials = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalMaterialTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalMaterialTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationalMaterials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuthorId = table.Column<int>(type: "int", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EducationalMaterialTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalMaterials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalMaterials_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_EducationalMaterials_EducationalMaterialTypes_EducationalMaterialTypeId",
                        column: x => x.EducationalMaterialTypeId,
                        principalTable: "EducationalMaterialTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReviewedMaterialId = table.Column<int>(type: "int", nullable: true),
                    TextReview = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitReview = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reviews_EducationalMaterials_ReviewedMaterialId",
                        column: x => x.ReviewedMaterialId,
                        principalTable: "EducationalMaterials",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationalMaterials_AuthorId",
                table: "EducationalMaterials",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalMaterials_EducationalMaterialTypeId",
                table: "EducationalMaterials",
                column: "EducationalMaterialTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ReviewedMaterialId",
                table: "Reviews",
                column: "ReviewedMaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "EducationalMaterials");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "EducationalMaterialTypes");
        }
    }
}
