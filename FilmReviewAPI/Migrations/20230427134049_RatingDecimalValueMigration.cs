using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class RatingDecimalValueMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Ratings",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 92, 86, 79, 85, 196, 129, 46, 135, 131, 163, 138, 73, 218, 194, 69, 100, 237, 38, 207, 222, 215, 39, 145, 226, 94, 0, 131, 5, 174, 226, 186, 243, 230, 163, 231, 48, 152, 7, 132, 236, 227, 107, 95, 192, 245, 65, 223, 193, 37, 59, 19, 229, 125, 226, 90, 231, 136, 9, 60, 80, 96, 251, 62 }, new byte[] { 225, 47, 116, 186, 137, 215, 156, 152, 81, 251, 132, 143, 255, 216, 180, 243, 126, 101, 139, 88, 0, 179, 86, 177, 189, 4, 131, 126, 125, 250, 56, 15, 117, 248, 166, 58, 173, 119, 195, 82, 174, 63, 254, 187, 14, 83, 202, 117, 250, 40, 179, 2, 35, 160, 43, 75, 58, 193, 168, 59, 32, 228, 30, 212, 27, 188, 214, 80, 61, 212, 66, 122, 206, 121, 35, 211, 64, 168, 180, 97, 211, 112, 41, 87, 80, 9, 61, 205, 238, 162, 70, 75, 114, 48, 116, 32, 58, 130, 247, 89, 51, 215, 139, 90, 221, 165, 38, 34, 48, 163, 12, 119, 46, 65, 88, 86, 238, 14, 8, 37, 12, 141, 51, 112, 197, 136, 128, 108 } });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Value",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 119, 129, 156, 214, 124, 79, 144, 35, 153, 123, 141, 162, 25, 186, 0, 243, 212, 245, 4, 156, 34, 4, 234, 21, 90, 241, 32, 160, 2, 82, 43, 141, 205, 46, 91, 103, 73, 119, 235, 33, 9, 96, 97, 254, 172, 191, 50, 52, 13, 18, 196, 155, 3, 133, 167, 183, 181, 47, 169, 157, 17, 20, 2 }, new byte[] { 29, 120, 182, 39, 164, 150, 175, 214, 105, 181, 33, 225, 51, 235, 26, 143, 232, 177, 42, 103, 223, 83, 129, 48, 73, 163, 22, 81, 95, 133, 211, 176, 240, 71, 34, 190, 16, 88, 48, 160, 68, 118, 220, 232, 167, 166, 70, 232, 174, 163, 255, 86, 250, 209, 130, 236, 159, 155, 241, 215, 43, 215, 149, 180, 5, 229, 85, 235, 94, 69, 70, 202, 141, 42, 108, 101, 233, 145, 22, 147, 131, 74, 164, 119, 23, 207, 151, 10, 139, 36, 94, 76, 55, 195, 65, 45, 144, 196, 127, 245, 204, 209, 84, 12, 105, 27, 7, 136, 141, 246, 17, 51, 158, 60, 8, 151, 210, 205, 96, 113, 72, 220, 173, 196, 249, 192, 122, 205 } });
        }
    }
}
