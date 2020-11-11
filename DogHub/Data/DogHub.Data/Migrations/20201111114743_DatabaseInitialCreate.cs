namespace DogHub.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class DatabaseInitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    BreedName = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DogColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ColorName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EyesColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    EyesColorName = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyesColors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JudgeApplicationForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    YearsOfExperience = table.Column<int>(nullable: false),
                    RaisedLitters = table.Column<int>(nullable: false),
                    NumberOfChampionsOwned = table.Column<int>(nullable: false),
                    HasBeenJudgeAssistant = table.Column<bool>(nullable: false),
                    AttendedJudgeInstituteCourse = table.Column<bool>(nullable: false),
                    JudgeInstituteCertificateUrl = table.Column<string>(nullable: false),
                    IsApproved = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeApplicationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JudgeApplicationForms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    CompetitionImageId = table.Column<int>(nullable: false),
                    CompetitionStart = table.Column<DateTime>(nullable: false),
                    CompetitionEnd = table.Column<DateTime>(nullable: false),
                    OrganisedBy = table.Column<string>(maxLength: 80, nullable: false),
                    BreedId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Competitions_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CompetitionImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    CompetitionId = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompetitionImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompetitionImages_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 60, nullable: false),
                    DogImageId = table.Column<int>(nullable: false),
                    DogVideoUrl = table.Column<string>(nullable: false),
                    BreedId = table.Column<int>(nullable: false),
                    Gender = table.Column<int>(nullable: true),
                    Age = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: true),
                    EyesColorId = table.Column<int>(nullable: false),
                    DogColorId = table.Column<int>(nullable: false),
                    Sellable = table.Column<bool>(nullable: true),
                    IsSpayedOrNeutered = table.Column<bool>(nullable: true),
                    IsSold = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 250, nullable: true),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dogs_Breeds_BreedId",
                        column: x => x.BreedId,
                        principalTable: "Breeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogs_DogColors_DogColorId",
                        column: x => x.DogColorId,
                        principalTable: "DogColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogs_EyesColors_EyesColorId",
                        column: x => x.EyesColorId,
                        principalTable: "EyesColors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dogs_AspNetUsers_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DogImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    DogId = table.Column<int>(nullable: false),
                    Extension = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogImages_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DogSCompetitions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogId = table.Column<int>(nullable: false),
                    CompetitionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogSCompetitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DogSCompetitions_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DogSCompetitions_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EvaluationForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    DogId = table.Column<int>(nullable: false),
                    BalanceRate = table.Column<int>(nullable: false),
                    WeightRate = table.Column<int>(nullable: false),
                    EyesRate = table.Column<int>(nullable: false),
                    EarsRate = table.Column<int>(nullable: false),
                    HeadShapeRate = table.Column<int>(nullable: false),
                    MuzzleRate = table.Column<int>(nullable: false),
                    ColorRate = table.Column<int>(nullable: false),
                    TotalPoints = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationForms_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EvaluationForms_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_IsDeleted",
                table: "Breeds",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionImages_CompetitionId",
                table: "CompetitionImages",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_CompetitionImages_IsDeleted",
                table: "CompetitionImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_BreedId",
                table: "Competitions",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_CompetitionImageId",
                table: "Competitions",
                column: "CompetitionImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Competitions_IsDeleted",
                table: "Competitions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DogColors_IsDeleted",
                table: "DogColors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_DogImages_DogId",
                table: "DogImages",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogImages_IsDeleted",
                table: "DogImages",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogColorId",
                table: "Dogs",
                column: "DogColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_DogImageId",
                table: "Dogs",
                column: "DogImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_EyesColorId",
                table: "Dogs",
                column: "EyesColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_IsDeleted",
                table: "Dogs",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_OwnerId",
                table: "Dogs",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_DogSCompetitions_CompetitionId",
                table: "DogSCompetitions",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_DogSCompetitions_DogId",
                table: "DogSCompetitions",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForms_DogId",
                table: "EvaluationForms",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForms_IsDeleted",
                table: "EvaluationForms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationForms_UserId",
                table: "EvaluationForms",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EyesColors_IsDeleted",
                table: "EyesColors",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeApplicationForms_IsDeleted",
                table: "JudgeApplicationForms",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_JudgeApplicationForms_UserId",
                table: "JudgeApplicationForms",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competitions_CompetitionImages_CompetitionImageId",
                table: "Competitions",
                column: "CompetitionImageId",
                principalTable: "CompetitionImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_DogImages_DogImageId",
                table: "Dogs",
                column: "DogImageId",
                principalTable: "DogImages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompetitionImages_Competitions_CompetitionId",
                table: "CompetitionImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Breeds_BreedId",
                table: "Dogs");

            migrationBuilder.DropForeignKey(
                name: "FK_DogImages_Dogs_DogId",
                table: "DogImages");

            migrationBuilder.DropTable(
                name: "DogSCompetitions");

            migrationBuilder.DropTable(
                name: "EvaluationForms");

            migrationBuilder.DropTable(
                name: "JudgeApplicationForms");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "CompetitionImages");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "DogColors");

            migrationBuilder.DropTable(
                name: "DogImages");

            migrationBuilder.DropTable(
                name: "EyesColors");
        }
    }
}
