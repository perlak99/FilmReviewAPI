using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class FilmStatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmStatusId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FilmStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "FilmStatuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Accepted" },
                    { 2, "Rejected" },
                    { 3, "Pending" }
                });

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "AddedByUserId", "DirectorId", "FilmStatusId", "GenreId", "ReleaseYear", "Title" },
                values: new object[] { 2, 1, null, 0, 2, 0, "test" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 171, 99, 185, 230, 22, 34, 209, 222, 41, 72, 119, 201, 121, 1, 171, 246, 22, 24, 51, 255, 6, 37, 180, 164, 50, 130, 92, 220, 58, 83, 86, 21, 60, 208, 245, 231, 172, 23, 135, 70, 107, 130, 1, 209, 54, 240, 75, 185, 8, 223, 59, 5, 137, 97, 236, 214, 216, 126, 168, 140, 223, 30, 120, 130 }, new byte[] { 228, 139, 68, 3, 46, 168, 252, 24, 254, 207, 150, 52, 144, 36, 1, 166, 156, 79, 154, 153, 71, 72, 5, 46, 144, 247, 188, 160, 206, 168, 230, 38, 18, 128, 5, 56, 41, 203, 19, 104, 83, 152, 94, 179, 248, 68, 99, 189, 100, 53, 52, 100, 30, 161, 42, 119, 186, 16, 197, 229, 54, 196, 140, 24, 254, 177, 64, 63, 200, 175, 214, 94, 36, 122, 211, 181, 150, 141, 59, 122, 164, 193, 239, 134, 145, 44, 35, 99, 56, 163, 13, 100, 220, 121, 57, 129, 211, 210, 35, 65, 178, 49, 182, 245, 117, 66, 117, 88, 28, 120, 149, 183, 253, 39, 133, 23, 173, 221, 195, 173, 29, 5, 235, 176, 53, 188, 146, 34 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmStatuses");

            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "FilmStatusId",
                table: "Films");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 170, 51, 244, 183, 219, 137, 93, 61, 194, 246, 223, 137, 217, 192, 111, 202, 110, 0, 70, 28, 108, 201, 63, 114, 59, 43, 240, 255, 198, 56, 126, 244, 175, 80, 142, 185, 60, 235, 47, 120, 5, 55, 169, 217, 108, 168, 224, 108, 38, 55, 20, 235, 204, 127, 107, 22, 19, 48, 167, 92, 219, 173, 210, 213 }, new byte[] { 54, 158, 77, 250, 53, 146, 55, 94, 53, 211, 173, 96, 152, 178, 133, 89, 119, 84, 128, 153, 219, 63, 246, 225, 117, 254, 106, 36, 171, 183, 115, 137, 34, 38, 220, 192, 140, 110, 133, 167, 38, 212, 252, 123, 3, 35, 115, 211, 150, 211, 223, 33, 223, 167, 230, 56, 164, 97, 123, 3, 199, 88, 10, 46, 173, 243, 219, 203, 170, 22, 166, 91, 219, 0, 115, 254, 149, 113, 58, 174, 199, 174, 66, 130, 133, 195, 102, 220, 69, 61, 15, 223, 39, 120, 45, 166, 248, 219, 6, 179, 185, 251, 221, 134, 67, 62, 138, 59, 31, 197, 124, 183, 133, 231, 139, 210, 197, 219, 161, 18, 140, 49, 156, 129, 72, 177, 69, 35 } });
        }
    }
}
