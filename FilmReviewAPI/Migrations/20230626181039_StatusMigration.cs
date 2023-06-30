using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class StatusMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmStatuses");

            migrationBuilder.RenameColumn(
                name: "FilmStatusId",
                table: "Films",
                newName: "StatusId");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Films",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddedByUserId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Directors",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Directors",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 1,
                column: "Status",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Films",
                keyColumn: "Id",
                keyValue: 2,
                column: "Status",
                value: 3);

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Accepted" },
                    { 2, "Rejected" },
                    { 3, "Pending" }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 228, 14, 20, 11, 97, 45, 200, 50, 206, 92, 19, 210, 28, 255, 4, 64, 255, 244, 14, 7, 87, 160, 95, 143, 122, 65, 90, 241, 225, 66, 161, 175, 37, 36, 142, 65, 137, 46, 220, 188, 16, 48, 8, 44, 254, 154, 117, 239, 154, 183, 93, 90, 191, 194, 3, 191, 146, 54, 137, 64, 240, 58, 206, 237 }, new byte[] { 157, 116, 30, 168, 83, 170, 6, 109, 5, 2, 70, 19, 8, 68, 32, 248, 160, 153, 93, 242, 209, 198, 229, 225, 164, 69, 62, 158, 5, 200, 159, 239, 191, 70, 190, 242, 224, 251, 46, 108, 61, 37, 241, 137, 104, 228, 108, 127, 49, 86, 253, 82, 137, 34, 11, 98, 173, 165, 202, 170, 216, 134, 138, 84, 103, 254, 114, 163, 196, 196, 124, 4, 223, 34, 16, 237, 250, 32, 154, 248, 82, 190, 158, 115, 127, 129, 141, 24, 155, 89, 96, 247, 72, 238, 233, 144, 96, 35, 76, 110, 255, 215, 102, 95, 61, 155, 3, 70, 174, 51, 244, 50, 155, 96, 10, 121, 74, 252, 135, 19, 140, 174, 70, 63, 216, 80, 108, 114 } });

            migrationBuilder.CreateIndex(
                name: "IX_Directors_AddedByUserId",
                table: "Directors",
                column: "AddedByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Directors_Users_AddedByUserId",
                table: "Directors",
                column: "AddedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directors_Users_AddedByUserId",
                table: "Directors");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Directors_AddedByUserId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Films");

            migrationBuilder.DropColumn(
                name: "AddedByUserId",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Directors");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Directors");

            migrationBuilder.RenameColumn(
                name: "StatusId",
                table: "Films",
                newName: "FilmStatusId");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 65, 110, 170, 134, 235, 182, 122, 7, 249, 124, 193, 88, 245, 92, 95, 95, 203, 230, 91, 91, 121, 63, 93, 166, 106, 103, 131, 217, 153, 151, 17, 97, 107, 94, 132, 54, 249, 61, 0, 50, 126, 90, 224, 40, 137, 72, 16, 226, 210, 50, 50, 143, 89, 123, 243, 218, 243, 26, 10, 144, 133, 156, 252, 100 }, new byte[] { 176, 68, 60, 51, 30, 121, 23, 118, 107, 168, 135, 31, 158, 56, 145, 102, 120, 196, 211, 142, 85, 145, 217, 136, 79, 6, 7, 7, 100, 106, 174, 114, 212, 88, 237, 59, 82, 217, 164, 13, 21, 117, 51, 81, 84, 113, 29, 53, 188, 39, 14, 65, 181, 207, 56, 198, 136, 230, 26, 211, 85, 66, 83, 73, 246, 118, 169, 240, 235, 252, 190, 237, 18, 246, 16, 252, 183, 45, 218, 193, 213, 239, 127, 230, 220, 163, 143, 2, 214, 184, 30, 134, 92, 35, 192, 98, 167, 171, 201, 116, 32, 210, 52, 168, 176, 236, 76, 148, 170, 183, 2, 45, 37, 146, 212, 142, 40, 195, 64, 248, 83, 134, 179, 246, 232, 247, 208, 252 } });
        }
    }
}
