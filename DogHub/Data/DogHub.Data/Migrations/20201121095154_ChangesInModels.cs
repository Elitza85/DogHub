using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class ChangesInModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrganiserName",
                table: "Organisers");

            migrationBuilder.DropColumn(
                name: "BreedName",
                table: "Breeds");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Organisers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "DogImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RemoteImageUrl",
                table: "DogImages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Breeds",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Organisers");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "DogImages");

            migrationBuilder.DropColumn(
                name: "RemoteImageUrl",
                table: "DogImages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Breeds");

            migrationBuilder.AddColumn<string>(
                name: "OrganiserName",
                table: "Organisers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BreedName",
                table: "Breeds",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
