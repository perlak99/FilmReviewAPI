using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class UserRolesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Films",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleUser",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUser", x => new { x.RoleId, x.UserId });
                    table.ForeignKey(
                        name: "FK_RoleUser_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "User" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "PasswordHash", "PasswordSalt", "Username" },
                values: new object[] { 1, null, new byte[] { 3, 7, 56, 158, 219, 56, 193, 162, 184, 43, 198, 136, 241, 31, 73, 245, 197, 97, 126, 16, 69, 193, 51, 133, 145, 30, 84, 189, 167, 69, 200, 69, 199, 202, 21, 84, 236, 128, 74, 101, 108, 84, 168, 55, 168, 216, 197, 136, 189, 212, 84, 252, 18, 230, 172, 216, 7, 226, 170, 117, 126, 243, 124, 118 }, new byte[] { 9, 210, 185, 132, 194, 195, 153, 236, 8, 245, 247, 3, 40, 121, 78, 227, 180, 167, 192, 181, 71, 167, 12, 207, 104, 58, 38, 169, 134, 14, 243, 237, 200, 238, 226, 80, 144, 36, 142, 211, 247, 250, 34, 1, 106, 167, 56, 159, 253, 44, 35, 92, 233, 78, 158, 140, 181, 76, 109, 116, 4, 72, 93, 116, 25, 89, 105, 6, 195, 143, 47, 36, 118, 53, 233, 139, 24, 230, 13, 40, 168, 173, 171, 59, 30, 235, 29, 127, 140, 18, 130, 1, 179, 180, 95, 21, 65, 86, 134, 220, 18, 220, 126, 85, 12, 92, 196, 62, 107, 95, 112, 10, 139, 211, 161, 90, 216, 13, 235, 76, 241, 104, 168, 167, 33, 100, 48, 86 }, "Admin" });

            migrationBuilder.InsertData(
                table: "RoleUser",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Films_UserId",
                table: "Films",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUser_UserId",
                table: "RoleUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Films_Users_UserId",
                table: "Films",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Films_Users_UserId",
                table: "Films");

            migrationBuilder.DropTable(
                name: "RoleUser");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Films_UserId",
                table: "Films");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Films");
        }
    }
}
