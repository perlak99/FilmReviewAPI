using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class MakeDirectorIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 97, 27, 233, 24, 134, 142, 230, 228, 147, 249, 65, 115, 164, 41, 165, 98, 19, 180, 46, 210, 132, 129, 49, 249, 63, 63, 117, 176, 148, 253, 0, 79, 136, 83, 60, 198, 94, 89, 248, 230, 233, 76, 142, 88, 74, 248, 187, 121, 77, 0, 9, 118, 115, 31, 103, 32, 3, 31, 78, 42, 215, 155, 61 }, new byte[] { 148, 28, 67, 86, 15, 85, 86, 133, 9, 186, 163, 52, 109, 245, 34, 117, 65, 92, 154, 210, 224, 148, 110, 180, 8, 238, 66, 127, 125, 193, 158, 156, 1, 222, 42, 147, 254, 153, 36, 48, 255, 193, 122, 55, 84, 75, 93, 120, 145, 100, 30, 210, 205, 213, 173, 184, 108, 15, 152, 242, 73, 67, 21, 75, 213, 131, 104, 194, 208, 217, 74, 236, 238, 70, 247, 102, 5, 249, 67, 206, 64, 223, 193, 154, 132, 191, 49, 153, 107, 63, 105, 27, 234, 91, 76, 196, 189, 220, 178, 42, 162, 172, 197, 107, 106, 105, 132, 241, 62, 159, 124, 184, 30, 119, 134, 218, 30, 138, 201, 33, 27, 232, 132, 207, 158, 122, 233, 31 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films");

            migrationBuilder.AlterColumn<int>(
                name: "DirectorId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 254, 122, 4, 155, 64, 246, 230, 216, 28, 163, 233, 136, 173, 41, 122, 114, 209, 94, 5, 173, 10, 155, 20, 229, 133, 70, 212, 121, 87, 139, 217, 239, 135, 173, 35, 22, 211, 231, 128, 78, 17, 229, 201, 142, 165, 73, 159, 4, 36, 128, 225, 187, 25, 27, 85, 84, 247, 178, 244, 44, 239, 132, 65, 120 }, new byte[] { 175, 119, 161, 203, 39, 218, 100, 78, 44, 162, 65, 210, 25, 167, 27, 118, 252, 90, 32, 154, 74, 204, 245, 48, 155, 252, 235, 56, 103, 218, 153, 102, 230, 230, 2, 138, 84, 137, 111, 119, 128, 255, 148, 252, 233, 9, 116, 42, 95, 241, 174, 31, 71, 93, 100, 16, 161, 114, 41, 25, 118, 183, 138, 123, 217, 253, 140, 182, 140, 29, 209, 77, 61, 71, 99, 29, 62, 163, 23, 178, 34, 28, 54, 168, 117, 87, 247, 191, 221, 223, 47, 94, 153, 249, 169, 174, 121, 188, 106, 18, 103, 6, 10, 171, 57, 29, 78, 3, 92, 61, 87, 214, 6, 165, 139, 212, 89, 79, 250, 137, 237, 16, 89, 118, 132, 28, 43, 33 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Directors_DirectorId",
                table: "Films",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
