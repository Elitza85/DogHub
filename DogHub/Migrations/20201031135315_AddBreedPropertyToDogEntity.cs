using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Migrations
{
    public partial class AddBreedPropertyToDogEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "Dogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs",
                column: "BreedId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_Breeds_BreedId",
                table: "Dogs",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "BreedId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_Breeds_BreedId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_BreedId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "Dogs");
        }
    }
}
