using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmReviewAPI.Migrations
{
    public partial class CommentRepliesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParentCommentId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 187, 76, 160, 41, 10, 250, 36, 251, 49, 2, 176, 99, 15, 226, 240, 204, 201, 23, 223, 228, 168, 74, 42, 169, 76, 51, 235, 113, 64, 87, 56, 241, 33, 1, 121, 31, 155, 189, 121, 40, 12, 51, 49, 173, 74, 8, 171, 48, 163, 149, 45, 19, 179, 162, 58, 159, 82, 18, 194, 10, 9, 154, 155, 163 }, new byte[] { 140, 120, 236, 29, 60, 107, 30, 210, 156, 45, 137, 214, 9, 194, 101, 153, 44, 74, 24, 252, 101, 199, 221, 18, 242, 3, 70, 216, 79, 239, 219, 53, 126, 220, 153, 64, 51, 40, 64, 43, 229, 239, 151, 153, 63, 105, 192, 55, 144, 160, 213, 72, 71, 59, 96, 171, 100, 226, 188, 78, 86, 143, 220, 19, 104, 94, 237, 214, 25, 20, 89, 236, 156, 169, 184, 76, 43, 121, 17, 8, 4, 88, 127, 29, 29, 112, 26, 228, 9, 17, 4, 6, 251, 215, 196, 249, 91, 36, 172, 253, 58, 105, 249, 14, 81, 253, 140, 10, 80, 159, 179, 214, 236, 110, 166, 165, 229, 125, 135, 51, 223, 102, 178, 89, 177, 12, 34, 228 } });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments",
                column: "ParentCommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_ParentCommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "ParentCommentId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { new byte[] { 94, 189, 254, 111, 55, 31, 228, 208, 156, 82, 141, 10, 234, 152, 193, 182, 101, 168, 166, 159, 41, 188, 134, 146, 27, 157, 77, 154, 41, 25, 149, 213, 159, 158, 113, 124, 188, 189, 183, 125, 61, 245, 211, 69, 121, 247, 154, 69, 39, 156, 106, 197, 139, 238, 17, 210, 27, 90, 163, 107, 112, 249, 15, 76 }, new byte[] { 222, 8, 89, 191, 41, 231, 79, 3, 194, 206, 8, 13, 252, 254, 247, 183, 37, 29, 214, 40, 189, 113, 130, 159, 28, 61, 122, 4, 47, 69, 18, 116, 55, 22, 123, 130, 29, 69, 194, 193, 27, 52, 41, 211, 81, 152, 135, 78, 142, 156, 218, 116, 110, 145, 129, 41, 218, 141, 157, 150, 97, 129, 58, 166, 112, 46, 44, 170, 29, 167, 63, 215, 169, 210, 111, 119, 18, 61, 66, 112, 156, 85, 95, 103, 82, 180, 75, 167, 216, 81, 186, 42, 18, 165, 153, 167, 216, 73, 70, 193, 65, 123, 21, 69, 95, 167, 164, 108, 228, 121, 226, 156, 222, 155, 85, 81, 129, 141, 199, 117, 136, 51, 148, 75, 232, 196, 99, 166 } });
        }
    }
}
