using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class DivideMatchRequestsInTwoTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRequests");

            migrationBuilder.CreateTable(
                name: "MatchRequestsReceived",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReceiverDogId = table.Column<int>(type: "int", nullable: false),
                    SenderDogId = table.Column<int>(type: "int", nullable: false),
                    IsUnderReview = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchRequestsReceived", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequestsReceived_Dogs_ReceiverDogId",
                        column: x => x.ReceiverDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                    SenderDogId = table.Column<int>(type: "int", nullable: false),
                    ReceiverDogId = table.Column<int>(type: "int", nullable: false),
                    IsUnderReview = table.Column<bool>(type: "bit", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    IsRejected = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    table.ForeignKey(
                        name: "FK_MatchRequestsSent_Dogs_SenderDogId",
                        column: x => x.SenderDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsReceived_IsDeleted",
                table: "MatchRequestsReceived",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsReceived_ReceiverDogId",
                table: "MatchRequestsReceived",
                column: "ReceiverDogId");

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

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsSent_SenderDogId",
                table: "MatchRequestsSent",
                column: "SenderDogId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchRequestsReceived");

            migrationBuilder.DropTable(
                name: "MatchRequestsSent");

            migrationBuilder.CreateTable(
                name: "MatchRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_MatchRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchRequests_Dogs_ReceiverDogId",
                        column: x => x.ReceiverDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatchRequests_Dogs_SenderDogId",
                        column: x => x.SenderDogId,
                        principalTable: "Dogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequests_IsDeleted",
                table: "MatchRequests",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequests_ReceiverDogId",
                table: "MatchRequests",
                column: "ReceiverDogId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequests_SenderDogId",
                table: "MatchRequests",
                column: "SenderDogId");
        }
    }
}
