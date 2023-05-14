using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class nullableDirectorMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.InsertData(
                table: "Films",
                columns: new[] { "Id", "DirectorId", "GenreId", "ReleaseYear", "Title", "UserId" },
                values: new object[] { 1, null, 1, 2012, "FilmTest", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new byte[] { 17, 138, 14, 144, 149, 72, 43, 89, 237, 99, 82, 72, 150, 103, 94, 56, 232, 13, 159, 186, 244, 124, 13, 144, 54, 136, 213, 150, 215, 147, 232, 30, 144, 223, 5, 195, 69, 76, 85, 42, 42, 153, 125, 221, 92, 77, 19, 86, 196, 214, 118, 180, 31, 34, 183, 247, 216, 147, 213, 238, 163, 3, 163, 166 }, new byte[] { 7, 10, 157, 212, 113, 131, 178, 61, 180, 74, 61, 72, 159, 122, 189, 145, 187, 152, 83, 118, 48, 79, 212, 69, 55, 195, 8, 10, 97, 86, 161, 108, 227, 40, 138, 102, 163, 114, 31, 204, 234, 142, 83, 43, 243, 142, 35, 81, 204, 30, 52, 57, 83, 156, 220, 64, 174, 26, 79, 199, 84, 16, 205, 8, 11, 51, 239, 82, 246, 103, 149, 124, 163, 211, 197, 238, 57, 90, 222, 103, 183, 181, 4, 25, 148, 220, 173, 111, 191, 89, 221, 82, 124, 179, 241, 32, 17, 253, 14, 61, 250, 255, 239, 117, 101, 160, 249, 211, 112, 27, 45, 4, 68, 11, 88, 184, 96, 110, 63, 32, 205, 172, 206, 168, 77, 7, 159, 23 }, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { new byte[] { 254, 92, 86, 79, 85, 196, 129, 46, 135, 131, 163, 138, 73, 218, 194, 69, 100, 237, 38, 207, 222, 215, 39, 145, 226, 94, 0, 131, 5, 174, 226, 186, 243, 230, 163, 231, 48, 152, 7, 132, 236, 227, 107, 95, 192, 245, 65, 223, 193, 37, 59, 19, 229, 125, 226, 90, 231, 136, 9, 60, 80, 96, 251, 62 }, new byte[] { 225, 47, 116, 186, 137, 215, 156, 152, 81, 251, 132, 143, 255, 216, 180, 243, 126, 101, 139, 88, 0, 179, 86, 177, 189, 4, 131, 126, 125, 250, 56, 15, 117, 248, 166, 58, 173, 119, 195, 82, 174, 63, 254, 187, 14, 83, 202, 117, 250, 40, 179, 2, 35, 160, 43, 75, 58, 193, 168, 59, 32, 228, 30, 212, 27, 188, 214, 80, 61, 212, 66, 122, 206, 121, 35, 211, 64, 168, 180, 97, 211, 112, 41, 87, 80, 9, 61, 205, 238, 162, 70, 75, 114, 48, 116, 32, 58, 130, 247, 89, 51, 215, 139, 90, 221, 165, 38, 34, 48, 163, 12, 119, 46, 65, 88, 86, 238, 14, 8, 37, 12, 141, 51, 112, 197, 136, 128, 108 }, "Admin" });
        }
    }
}
