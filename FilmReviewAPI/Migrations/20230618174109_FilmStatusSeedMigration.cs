using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class FilmStatusSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmStatusId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilmStatusId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 65, 110, 170, 134, 235, 182, 122, 7, 249, 124, 193, 88, 245, 92, 95, 95, 203, 230, 91, 91, 121, 63, 93, 166, 106, 103, 131, 217, 153, 151, 17, 97, 107, 94, 132, 54, 249, 61, 0, 50, 126, 90, 224, 40, 137, 72, 16, 226, 210, 50, 50, 143, 89, 123, 243, 218, 243, 26, 10, 144, 133, 156, 252, 100 }, new byte[] { 176, 68, 60, 51, 30, 121, 23, 118, 107, 168, 135, 31, 158, 56, 145, 102, 120, 196, 211, 142, 85, 145, 217, 136, 79, 6, 7, 7, 100, 106, 174, 114, 212, 88, 237, 59, 82, 217, 164, 13, 21, 117, 51, 81, 84, 113, 29, 53, 188, 39, 14, 65, 181, 207, 56, 198, 136, 230, 26, 211, 85, 66, 83, 73, 246, 118, 169, 240, 235, 252, 190, 237, 18, 246, 16, 252, 183, 45, 218, 193, 213, 239, 127, 230, 220, 163, 143, 2, 214, 184, 30, 134, 92, 35, 192, 98, 167, 171, 201, 116, 32, 210, 52, 168, 176, 236, 76, 148, 170, 183, 2, 45, 37, 146, 212, 142, 40, 195, 64, 248, 83, 134, 179, 246, 232, 247, 208, 252 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "FilmStatusId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "FilmStatusId",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 171, 99, 185, 230, 22, 34, 209, 222, 41, 72, 119, 201, 121, 1, 171, 246, 22, 24, 51, 255, 6, 37, 180, 164, 50, 130, 92, 220, 58, 83, 86, 21, 60, 208, 245, 231, 172, 23, 135, 70, 107, 130, 1, 209, 54, 240, 75, 185, 8, 223, 59, 5, 137, 97, 236, 214, 216, 126, 168, 140, 223, 30, 120, 130 }, new byte[] { 228, 139, 68, 3, 46, 168, 252, 24, 254, 207, 150, 52, 144, 36, 1, 166, 156, 79, 154, 153, 71, 72, 5, 46, 144, 247, 188, 160, 206, 168, 230, 38, 18, 128, 5, 56, 41, 203, 19, 104, 83, 152, 94, 179, 248, 68, 99, 189, 100, 53, 52, 100, 30, 161, 42, 119, 186, 16, 197, 229, 54, 196, 140, 24, 254, 177, 64, 63, 200, 175, 214, 94, 36, 122, 211, 181, 150, 141, 59, 122, 164, 193, 239, 134, 145, 44, 35, 99, 56, 163, 13, 100, 220, 121, 57, 129, 211, 210, 35, 65, 178, 49, 182, 245, 117, 66, 117, 88, 28, 120, 149, 183, 253, 39, 133, 23, 173, 221, 195, 173, 29, 5, 235, 176, 53, 188, 146, 34 } });
        }
    }
}
