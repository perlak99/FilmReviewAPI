using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class FilmForeignKeysMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Comedy" });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Horror" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 122, 4, 155, 64, 246, 230, 216, 28, 163, 233, 136, 173, 41, 122, 114, 209, 94, 5, 173, 10, 155, 20, 229, 133, 70, 212, 121, 87, 139, 217, 239, 135, 173, 35, 22, 211, 231, 128, 78, 17, 229, 201, 142, 165, 73, 159, 4, 36, 128, 225, 187, 25, 27, 85, 84, 247, 178, 244, 44, 239, 132, 65, 120 }, new byte[] { 175, 119, 161, 203, 39, 218, 100, 78, 44, 162, 65, 210, 25, 167, 27, 118, 252, 90, 32, 154, 74, 204, 245, 48, 155, 252, 235, 56, 103, 218, 153, 102, 230, 230, 2, 138, 84, 137, 111, 119, 128, 255, 148, 252, 233, 9, 116, 42, 95, 241, 174, 31, 71, 93, 100, 16, 161, 114, 41, 25, 118, 183, 138, 123, 217, 253, 140, 182, 140, 29, 209, 77, 61, 71, 99, 29, 62, 163, 23, 178, 34, 28, 54, 168, 117, 87, 247, 191, 221, 223, 47, 94, 153, 249, 169, 174, 121, 188, 106, 18, 103, 6, 10, 171, 57, 29, 78, 3, 92, 61, 87, 214, 6, 165, 139, 212, 89, 79, 250, 137, 237, 16, 89, 118, 132, 28, 43, 33 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 3, 7, 56, 158, 219, 56, 193, 162, 184, 43, 198, 136, 241, 31, 73, 245, 197, 97, 126, 16, 69, 193, 51, 133, 145, 30, 84, 189, 167, 69, 200, 69, 199, 202, 21, 84, 236, 128, 74, 101, 108, 84, 168, 55, 168, 216, 197, 136, 189, 212, 84, 252, 18, 230, 172, 216, 7, 226, 170, 117, 126, 243, 124, 118 }, new byte[] { 9, 210, 185, 132, 194, 195, 153, 236, 8, 245, 247, 3, 40, 121, 78, 227, 180, 167, 192, 181, 71, 167, 12, 207, 104, 58, 38, 169, 134, 14, 243, 237, 200, 238, 226, 80, 144, 36, 142, 211, 247, 250, 34, 1, 106, 167, 56, 159, 253, 44, 35, 92, 233, 78, 158, 140, 181, 76, 109, 116, 4, 72, 93, 116, 25, 89, 105, 6, 195, 143, 47, 36, 118, 53, 233, 139, 24, 230, 13, 40, 168, 173, 171, 59, 30, 235, 29, 127, 140, 18, 130, 1, 179, 180, 95, 21, 65, 86, 134, 220, 18, 220, 126, 85, 12, 92, 196, 62, 107, 95, 112, 10, 139, 211, 161, 90, 216, 13, 235, 76, 241, 104, 168, 167, 33, 100, 48, 86 } });
        }
    }
}
