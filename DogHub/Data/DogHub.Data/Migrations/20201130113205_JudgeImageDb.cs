using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class JudgeImageDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImage_JudgeImageId",
                table: "JudgeApplicationForms");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgeImage_AspNetUsers_UserId",
                table: "JudgeImage");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JudgeImage",
                table: "JudgeImage");

            migrationBuilder.RenameTable(
                name: "JudgeImage",
                newName: "JudgeImages");

            migrationBuilder.RenameIndex(
                name: "IX_JudgeImage_UserId",
                table: "JudgeImages",
                newName: "IX_JudgeImages_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JudgeImages",
                table: "JudgeImages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImages_JudgeImageId",
                table: "JudgeApplicationForms",
                column: "JudgeImageId",
                principalTable: "JudgeImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeImages_AspNetUsers_UserId",
                table: "JudgeImages",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImages_JudgeImageId",
                table: "JudgeApplicationForms");

            migrationBuilder.DropForeignKey(
                name: "FK_JudgeImages_AspNetUsers_UserId",
                table: "JudgeImages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_JudgeImages",
                table: "JudgeImages");

            migrationBuilder.RenameTable(
                name: "JudgeImages",
                newName: "JudgeImage");

            migrationBuilder.RenameIndex(
                name: "IX_JudgeImages_UserId",
                table: "JudgeImage",
                newName: "IX_JudgeImage_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_JudgeImage",
                table: "JudgeImage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImage_JudgeImageId",
                table: "JudgeApplicationForms",
                column: "JudgeImageId",
                principalTable: "JudgeImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeImage_AspNetUsers_UserId",
                table: "JudgeImage",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
