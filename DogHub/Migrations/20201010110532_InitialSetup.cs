using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ColorId);
                });

            migrationBuilder.CreateTable(
                name: "Competitions",
                columns: table => new
                {
                    CompetitionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(unicode: false, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    CompetitionStart = table.Column<DateTime>(nullable: false),
                    CompetitionEnd = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competitions", x => x.CompetitionId);
                });

            migrationBuilder.CreateTable(
                name: "EyesColors",
                columns: table => new
                {
                    EyesColorId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EyesColorName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EyesColors", x => x.EyesColorId);
                });

            migrationBuilder.CreateTable(
                name: "Towns",
                columns: table => new
                {
                    TownId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TownName = table.Column<string>(unicode: false, maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Towns", x => x.TownId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    FullName = table.Column<string>(maxLength: 50, nullable: false),
                    TownId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Towns_TownId",
                        column: x => x.TownId,
                        principalTable: "Towns",
                        principalColumn: "TownId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Dogs",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DogPhotoUrl = table.Column<string>(nullable: false),
                    DogVideoUrl = table.Column<string>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 60, nullable: false),
                    Breed = table.Column<string>(unicode: false, maxLength: 40, nullable: false),
                    Age = table.Column<int>(nullable: true),
                    Weight = table.Column<double>(nullable: false),
                    EyesColorId = table.Column<int>(nullable: false),
                    Sellable = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dogs", x => x.DogId);
                    table.ForeignKey(
                        name: "FK_Dogs_EyesColors_EyesColorId",
                        column: x => x.EyesColorId,
                        principalTable: "EyesColors",
                        principalColumn: "EyesColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Dogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogsColors",
                columns: table => new
                {
                    ColorId = table.Column<int>(nullable: false),
                    DogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DogsColors", x => new { x.ColorId, x.DogId });
                    table.ForeignKey(
                        name: "FK_DogsColors_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "ColorId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogsColors_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DogsCompetitions",
                columns: table => new
                {
                    DogId = table.Column<int>(nullable: false),
                    CompetitionId = table.Column<int>(nullable: false),
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
                    table.PrimaryKey("PK_DogsCompetitions", x => new { x.DogId, x.CompetitionId });
                    table.ForeignKey(
                        name: "FK_DogsCompetitions_Competitions_CompetitionId",
                        column: x => x.CompetitionId,
                        principalTable: "Competitions",
                        principalColumn: "CompetitionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DogsCompetitions_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "DogId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_EyesColorId",
                table: "Dogs",
                column: "EyesColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_UserId",
                table: "Dogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DogsColors_DogId",
                table: "DogsColors",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_DogsCompetitions_CompetitionId",
                table: "DogsCompetitions",
                column: "CompetitionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TownId",
                table: "Users",
                column: "TownId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DogsColors");

            migrationBuilder.DropTable(
                name: "DogsCompetitions");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Competitions");

            migrationBuilder.DropTable(
                name: "Dogs");

            migrationBuilder.DropTable(
                name: "EyesColors");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Towns");
        }
    }
}
