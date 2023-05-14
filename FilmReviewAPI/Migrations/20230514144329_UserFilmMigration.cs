using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class UserFilmMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Users_UserId",
                table: "Films");

            migrationBuilder.DropIndex(
                name: "IX_Films_UserId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "AddedByUserId",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FavouriteFilmUser",
                columns: table => new
                {
                    FilmId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteFilmUser", x => new { x.FilmId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FavouriteFilmUser_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteFilmUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "AddedByUserId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 94, 189, 254, 111, 55, 31, 228, 208, 156, 82, 141, 10, 234, 152, 193, 182, 101, 168, 166, 159, 41, 188, 134, 146, 27, 157, 77, 154, 41, 25, 149, 213, 159, 158, 113, 124, 188, 189, 183, 125, 61, 245, 211, 69, 121, 247, 154, 69, 39, 156, 106, 197, 139, 238, 17, 210, 27, 90, 163, 107, 112, 249, 15, 76 }, new byte[] { 222, 8, 89, 191, 41, 231, 79, 3, 194, 206, 8, 13, 252, 254, 247, 183, 37, 29, 214, 40, 189, 113, 130, 159, 28, 61, 122, 4, 47, 69, 18, 116, 55, 22, 123, 130, 29, 69, 194, 193, 27, 52, 41, 211, 81, 152, 135, 78, 142, 156, 218, 116, 110, 145, 129, 41, 218, 141, 157, 150, 97, 129, 58, 166, 112, 46, 44, 170, 29, 167, 63, 215, 169, 210, 111, 119, 18, 61, 66, 112, 156, 85, 95, 103, 82, 180, 75, 167, 216, 81, 186, 42, 18, 165, 153, 167, 216, 73, 70, 193, 65, 123, 21, 69, 95, 167, 164, 108, 228, 121, 226, 156, 222, 155, 85, 81, 129, 141, 199, 117, 136, 51, 148, 75, 232, 196, 99, 166 } });

            migrationBuilder.CreateIndex(
                name: "IX_Films_AddedByUserId",
                table: "Films",
                column: "AddedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteFilmUser_UserId",
                table: "FavouriteFilmUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Users_AddedByUserId",
                table: "Films",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Users_AddedByUserId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "FavouriteFilmUser");

            migrationBuilder.DropIndex(
                name: "IX_Films_AddedByUserId",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Films");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 17, 138, 14, 144, 149, 72, 43, 89, 237, 99, 82, 72, 150, 103, 94, 56, 232, 13, 159, 186, 244, 124, 13, 144, 54, 136, 213, 150, 215, 147, 232, 30, 144, 223, 5, 195, 69, 76, 85, 42, 42, 153, 125, 221, 92, 77, 19, 86, 196, 214, 118, 180, 31, 34, 183, 247, 216, 147, 213, 238, 163, 3, 163, 166 }, new byte[] { 7, 10, 157, 212, 113, 131, 178, 61, 180, 74, 61, 72, 159, 122, 189, 145, 187, 152, 83, 118, 48, 79, 212, 69, 55, 195, 8, 10, 97, 86, 161, 108, 227, 40, 138, 102, 163, 114, 31, 204, 234, 142, 83, 43, 243, 142, 35, 81, 204, 30, 52, 57, 83, 156, 220, 64, 174, 26, 79, 199, 84, 16, 205, 8, 11, 51, 239, 82, 246, 103, 149, 124, 163, 211, 197, 238, 57, 90, 222, 103, 183, 181, 4, 25, 148, 220, 173, 111, 191, 89, 221, 82, 124, 179, 241, 32, 17, 253, 14, 61, 250, 255, 239, 117, 101, 160, 249, 211, 112, 27, 45, 4, 68, 11, 88, 184, 96, 110, 63, 32, 205, 172, 206, 168, 77, 7, 159, 23 } });

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserId",
                table: "Films",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Users_UserId",
                table: "Films",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
