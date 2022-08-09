using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SecondExam.Migrations
{
    public partial class addroles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2f278339-a9d2-48ce-9312-67e09d01feeb", "c00f4cf2-116c-4745-87a6-641051d87864", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "84f0b322-2c0b-484e-99aa-12e73c73a0b6", "d6dc75e7-d943-4405-b013-4ef2e70a3eba", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f278339-a9d2-48ce-9312-67e09d01feeb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84f0b322-2c0b-484e-99aa-12e73c73a0b6");
        }
    }
}
