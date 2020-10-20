using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Migrations
{
    public partial class FinalUpdatedOnModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "ColorRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "EarsRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "EyesRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "HeadShapeRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "MuzzleRate",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "TotalPoints",
                table: "DogsCompetitions");

            migrationBuilder.DropColumn(
                name: "WeightRate",
                table: "DogsCompetitions");

            migrationBuilder.AddColumn<bool>(
                name: "AttendedJudgeInstituteCourse",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenJudgeAssistant",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfChampionsOwned",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RaisedLitters",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearsOfExperience",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VoterEvaluationFormId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "DogsCompetitions",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "JudgeEvaluationForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceRate = table.Column<int>(nullable: false),
                    WeightRate = table.Column<int>(nullable: false),
                    EyesRate = table.Column<int>(nullable: false),
                    EarsRate = table.Column<int>(nullable: false),
                    HeadShapeRate = table.Column<int>(nullable: false),
                    MuzzleRate = table.Column<int>(nullable: false),
                    ColorRate = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    DogCompetiotionId = table.Column<string>(nullable: true),
                    DogCompetitionDogId = table.Column<int>(nullable: true),
                    DogCompetitionCompetitionId = table.Column<int>(nullable: true),
                    JudgeId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeEvaluationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgeEvaluationForm_Users_JudgeId",
                        column: x => x.JudgeId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JudgeEvaluationForm_DogsCompetitions_DogCompetitionDogId_DogCompetitionCompetitionId",
                        columns: x => new { x.DogCompetitionDogId, x.DogCompetitionCompetitionId },
                        principalTable: "DogsCompetitions",
                        principalColumns: new[] { "DogId", "CompetitionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VoterEvaluationForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceRate = table.Column<int>(nullable: false),
                    WeightRate = table.Column<int>(nullable: false),
                    EyesRate = table.Column<int>(nullable: false),
                    EarsRate = table.Column<int>(nullable: false),
                    HeadShapeRate = table.Column<int>(nullable: false),
                    MuzzleRate = table.Column<int>(nullable: false),
                    ColorRate = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false),
                    DogCompetiotionId = table.Column<string>(nullable: true),
                    DogCompetitionDogId = table.Column<int>(nullable: true),
                    DogCompetitionCompetitionId = table.Column<int>(nullable: true),
                    VoterId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoterEvaluationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoterEvaluationForm_Users_VoterId",
                        column: x => x.VoterId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_VoterEvaluationForm_DogsCompetitions_DogCompetitionDogId_DogCompetitionCompetitionId",
                        columns: x => new { x.DogCompetitionDogId, x.DogCompetitionCompetitionId },
                        principalTable: "DogsCompetitions",
                        principalColumns: new[] { "DogId", "CompetitionId" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JudgeEvaluationForm_JudgeId",
                table: "JudgeEvaluationForm",
                column: "JudgeId");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeEvaluationForm_DogCompetitionDogId_DogCompetitionCompetitionId",
                table: "JudgeEvaluationForm",
                columns: new[] { "DogCompetitionDogId", "DogCompetitionCompetitionId" });

            migrationBuilder.CreateIndex(
                name: "IX_VoterEvaluationForm_VoterId",
                table: "VoterEvaluationForm",
                column: "VoterId",
                unique: true,
                filter: "[VoterId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VoterEvaluationForm_DogCompetitionDogId_DogCompetitionCompetitionId",
                table: "VoterEvaluationForm",
                columns: new[] { "DogCompetitionDogId", "DogCompetitionCompetitionId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JudgeEvaluationForm");

            migrationBuilder.DropTable(
                name: "VoterEvaluationForm");

            migrationBuilder.DropColumn(
                name: "AttendedJudgeInstituteCourse",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "HasBeenJudgeAssistant",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "NumberOfChampionsOwned",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RaisedLitters",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "YearsOfExperience",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "VoterEvaluationFormId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "DogsCompetitions");

            migrationBuilder.AddColumn<int>(
                name: "BalanceRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarsRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EyesRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadShapeRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuzzleRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TotalPoints",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightRate",
                table: "DogsCompetitions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
