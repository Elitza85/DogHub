using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class AddUserColumnInMatchRequests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MatchRequestsSent",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "MatchRequestsReceived",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsSent_UserId",
                table: "MatchRequestsSent",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MatchRequestsReceived_UserId",
                table: "MatchRequestsReceived",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRequestsReceived_AspNetUsers_UserId",
                table: "MatchRequestsReceived",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MatchRequestsSent_AspNetUsers_UserId",
                table: "MatchRequestsSent",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchRequestsReceived_AspNetUsers_UserId",
                table: "MatchRequestsReceived");

            migrationBuilder.DropForeignKey(
                name: "FK_MatchRequestsSent_AspNetUsers_UserId",
                table: "MatchRequestsSent");

            migrationBuilder.DropIndex(
                name: "IX_MatchRequestsSent_UserId",
                table: "MatchRequestsSent");

            migrationBuilder.DropIndex(
                name: "IX_MatchRequestsReceived_UserId",
                table: "MatchRequestsReceived");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MatchRequestsSent");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MatchRequestsReceived");
        }
    }
}
