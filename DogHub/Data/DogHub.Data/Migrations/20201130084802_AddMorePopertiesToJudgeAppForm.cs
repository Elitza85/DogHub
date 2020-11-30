using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class AddMorePopertiesToJudgeAppForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "JudgeApplicationForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JudgeImageId",
                table: "JudgeApplicationForms",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "JudgeApplicationForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelfDescription",
                table: "JudgeApplicationForms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JudgeImage",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Extension = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgeImage_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeApplicationForms_JudgeImageId",
                table: "JudgeApplicationForms",
                column: "JudgeImageId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeImage_UserId",
                table: "JudgeImage",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImage_JudgeImageId",
                table: "JudgeApplicationForms",
                column: "JudgeImageId",
                principalTable: "JudgeImage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JudgeApplicationForms_JudgeImage_JudgeImageId",
                table: "JudgeApplicationForms");

            migrationBuilder.DropTable(
                name: "JudgeImage");

            migrationBuilder.DropIndex(
                name: "IX_JudgeApplicationForms_JudgeImageId",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "JudgeImageId",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "SelfDescription",
                table: "JudgeApplicationForms");
        }
    }
}
