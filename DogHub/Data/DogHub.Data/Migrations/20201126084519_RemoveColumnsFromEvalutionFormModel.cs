using Microsoft.EntityFrameworkCore.Migrations;

namespace DogHub.Data.Migrations
{
    public partial class RemoveColumnsFromEvalutionFormModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BalanceRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "ColorRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "EarsRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "EyesRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "HeadShapeRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "MuzzleRate",
                table: "EvaluationForms");

            migrationBuilder.DropColumn(
                name: "WeightRate",
                table: "EvaluationForms");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BalanceRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ColorRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EarsRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EyesRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "HeadShapeRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MuzzleRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WeightRate",
                table: "EvaluationForms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
