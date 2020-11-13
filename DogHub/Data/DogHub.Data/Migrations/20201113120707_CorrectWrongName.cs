using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class CorrectWrongName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogSCompetitions_Competitions_CompetitionId",
                table: "DogSCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_DogSCompetitions_Dogs_DogId",
                table: "DogSCompetitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogSCompetitions",
                table: "DogSCompetitions");

            migrationBuilder.RenameTable(
                name: "DogSCompetitions",
                newName: "DogsCompetitions");

            migrationBuilder.RenameIndex(
                name: "IX_DogSCompetitions_DogId",
                table: "DogsCompetitions",
                newName: "IX_DogsCompetitions_DogId");

            migrationBuilder.RenameIndex(
                name: "IX_DogSCompetitions_CompetitionId",
                table: "DogsCompetitions",
                newName: "IX_DogsCompetitions_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogsCompetitions",
                table: "DogsCompetitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DogsCompetitions_Competitions_CompetitionId",
                table: "DogsCompetitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DogsCompetitions_Dogs_DogId",
                table: "DogsCompetitions",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DogsCompetitions_Competitions_CompetitionId",
                table: "DogsCompetitions");

            migrationBuilder.DropForeignKey(
                name: "FK_DogsCompetitions_Dogs_DogId",
                table: "DogsCompetitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DogsCompetitions",
                table: "DogsCompetitions");

            migrationBuilder.RenameTable(
                name: "DogsCompetitions",
                newName: "DogSCompetitions");

            migrationBuilder.RenameIndex(
                name: "IX_DogsCompetitions_DogId",
                table: "DogSCompetitions",
                newName: "IX_DogSCompetitions_DogId");

            migrationBuilder.RenameIndex(
                name: "IX_DogsCompetitions_CompetitionId",
                table: "DogSCompetitions",
                newName: "IX_DogSCompetitions_CompetitionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DogSCompetitions",
                table: "DogSCompetitions",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DogSCompetitions_Competitions_CompetitionId",
                table: "DogSCompetitions",
                column: "CompetitionId",
                principalTable: "Competitions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DogSCompetitions_Dogs_DogId",
                table: "DogSCompetitions",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
