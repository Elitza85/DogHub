using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class MatchRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRequest");

            migrationBuilder.CreateTable(
                name: "MatchRequestsReceived",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SenderDogId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUnderReview = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRequestsReceived", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequestsReceived_Dogs_SenderDogId",
                        column: x => x.SenderDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MatchRequestsSent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverDogId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsUnderReview = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRequestsSent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequestsSent_Dogs_ReceiverDogId",
                        column: x => x.ReceiverDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsReceived_IsDeleted",
                table: "MatchRequestsReceived",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsReceived_SenderDogId",
                table: "MatchRequestsReceived",
                column: "SenderDogId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsSent_IsDeleted",
                table: "MatchRequestsSent",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsSent_ReceiverDogId",
                table: "MatchRequestsSent",
                column: "ReceiverDogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRequestsReceived");

            migrationBuilder.DropTable(
                name: "MatchRequestsSent");

            migrationBuilder.CreateTable(
                name: "MatchRequest",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DogId = table.Column<int>(type: "int", nullable: true),
                    DogId1 = table.Column<int>(type: "int", nullable: true),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    IsUnderReview = table.Column<bool>(type: "bit", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ReceiverDogId = table.Column<int>(type: "int", nullable: false),
                    SenderDogId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequest_Dogs_DogId",
                        column: x => x.DogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchRequest_Dogs_DogId1",
                        column: x => x.DogId1,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequest_DogId",
                table: "MatchRequest",
                column: "DogId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequest_DogId1",
                table: "MatchRequest",
                column: "DogId1");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequest_IsDeleted",
                table: "MatchRequest",
                column: "IsDeleted");
        }
    }
}
