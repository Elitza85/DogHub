using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class PropertiesWithoutValueInJudgeAppFrom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "JudgeApplicationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "JudgeApplicationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsUnderReview",
                table: "JudgeApplicationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "JudgeApplicationForms");

            migrationBuilder.DropColumn(
                name: "IsUnderReview",
                table: "JudgeApplicationForms");
        }
    }
}
