using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class final_schema_v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Workouts",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Difficulty",
                table: "Workouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Workouts",
                type: "longtext",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "aspnetusers",
                table: "Workouts",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfSeries",
                table: "ExercisesWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RepeatInSeries",
                table: "ExercisesWorkouts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_aspnetusers",
                table: "Workouts",
                column: "aspnetusers");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_aspnetusers",
                table: "Workouts",
                column: "aspnetusers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_aspnetusers",
                table: "Workouts");

            migrationBuilder.DropIndex(
                name: "IX_Workouts_aspnetusers",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Difficulty",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "aspnetusers",
                table: "Workouts");

            migrationBuilder.DropColumn(
                name: "NumberOfSeries",
                table: "ExercisesWorkouts");

            migrationBuilder.DropColumn(
                name: "RepeatInSeries",
                table: "ExercisesWorkouts");
        }
    }
}
