using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class UserIdRequiredInJudgeAppForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JudgeApplicationForms_UserId",
                table: "JudgeApplicationForms");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JudgeApplicationForms",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JudgeApplicationForms_UserId",
                table: "JudgeApplicationForms",
                column: "UserId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_JudgeApplicationForms_UserId",
                table: "JudgeApplicationForms");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "JudgeApplicationForms",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeApplicationForms_UserId",
                table: "JudgeApplicationForms",
                column: "UserId");
        }
    }
}
