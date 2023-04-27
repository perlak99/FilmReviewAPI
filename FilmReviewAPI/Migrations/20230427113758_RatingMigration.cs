using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class RatingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    FilmId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ratings_Films_FilmId",
                        column: x => x.FilmId,
                        principalTable: "Films",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ratings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 103, 119, 129, 156, 214, 124, 79, 144, 35, 153, 123, 141, 162, 25, 186, 0, 243, 212, 245, 4, 156, 34, 4, 234, 21, 90, 241, 32, 160, 2, 82, 43, 141, 205, 46, 91, 103, 73, 119, 235, 33, 9, 96, 97, 254, 172, 191, 50, 52, 13, 18, 196, 155, 3, 133, 167, 183, 181, 47, 169, 157, 17, 20, 2 }, new byte[] { 29, 120, 182, 39, 164, 150, 175, 214, 105, 181, 33, 225, 51, 235, 26, 143, 232, 177, 42, 103, 223, 83, 129, 48, 73, 163, 22, 81, 95, 133, 211, 176, 240, 71, 34, 190, 16, 88, 48, 160, 68, 118, 220, 232, 167, 166, 70, 232, 174, 163, 255, 86, 250, 209, 130, 236, 159, 155, 241, 215, 43, 215, 149, 180, 5, 229, 85, 235, 94, 69, 70, 202, 141, 42, 108, 101, 233, 145, 22, 147, 131, 74, 164, 119, 23, 207, 151, 10, 139, 36, 94, 76, 55, 195, 65, 45, 144, 196, 127, 245, 204, 209, 84, 12, 105, 27, 7, 136, 141, 246, 17, 51, 158, 60, 8, 151, 210, 205, 96, 113, 72, 220, 173, 196, 249, 192, 122, 205 } });

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_FilmId",
                table: "Ratings",
                column: "FilmId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 194, 97, 27, 233, 24, 134, 142, 230, 228, 147, 249, 65, 115, 164, 41, 165, 98, 19, 180, 46, 210, 132, 129, 49, 249, 63, 63, 117, 176, 148, 253, 0, 79, 136, 83, 60, 198, 94, 89, 248, 230, 233, 76, 142, 88, 74, 248, 187, 121, 77, 0, 9, 118, 115, 31, 103, 32, 3, 31, 78, 42, 215, 155, 61 }, new byte[] { 148, 28, 67, 86, 15, 85, 86, 133, 9, 186, 163, 52, 109, 245, 34, 117, 65, 92, 154, 210, 224, 148, 110, 180, 8, 238, 66, 127, 125, 193, 158, 156, 1, 222, 42, 147, 254, 153, 36, 48, 255, 193, 122, 55, 84, 75, 93, 120, 145, 100, 30, 210, 205, 213, 173, 184, 108, 15, 152, 242, 73, 67, 21, 75, 213, 131, 104, 194, 208, 217, 74, 236, 238, 70, 247, 102, 5, 249, 67, 206, 64, 223, 193, 154, 132, 191, 49, 153, 107, 63, 105, 27, 234, 91, 76, 196, 189, 220, 178, 42, 162, 172, 197, 107, 106, 105, 132, 241, 62, 159, 124, 184, 30, 119, 134, 218, 30, 138, 201, 33, 27, 232, 132, 207, 158, 122, 233, 31 } });
        }
    }
}
