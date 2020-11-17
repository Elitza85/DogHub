using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class ChangesInTHeEvaluationFormAndJudgeApplicationForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsApproved",
                table: "JudgeApplicationForms");

            migrationBuilder.AddColumn<int>(
                name: "CompetitionId",
                table: "EvaluationForms",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForms_CompetitionId",
                table: "EvaluationForms",
                column: "CompetitionId");

            migrationBuilder.AddForeignKey(
                name: "FK_EvaluationForms_Competitions_CompetitionId",
                table: "EvaluationForms",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EvaluationForms_Competitions_CompetitionId",
                table: "EvaluationForms");

            migrationBuilder.DropIndex(
                name: "IX_EvaluationForms_CompetitionId",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "CompetitionId",
                table: "EvaluationForms");

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                table: "JudgeApplicationForms",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
