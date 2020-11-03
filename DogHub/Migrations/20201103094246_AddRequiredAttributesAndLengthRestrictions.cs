using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Migrations
{
    public partial class AddRequiredAttributesAndLengthRestrictions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMsgs_Chats_ChatId",
                table: "ChatMsgs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMsgs_Users_UserId",
                table: "ChatMsgs");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Chats",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ChatMsgs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MessageText",
                table: "ChatMsgs",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "ChatMsgs",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMsgs_Chats_ChatId",
                table: "ChatMsgs",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMsgs_Users_UserId",
                table: "ChatMsgs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChatMsgs_Chats_ChatId",
                table: "ChatMsgs");

            migrationBuilder.DropForeignKey(
                name: "FK_ChatMsgs_Users_UserId",
                table: "ChatMsgs");

            migrationBuilder.AlterColumn<string>(
                name: "Topic",
                table: "Chats",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ChatMsgs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "MessageText",
                table: "ChatMsgs",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "ChatId",
                table: "ChatMsgs",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMsgs_Chats_ChatId",
                table: "ChatMsgs",
                column: "ChatId",
                principalTable: "Chats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ChatMsgs_Users_UserId",
                table: "ChatMsgs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
