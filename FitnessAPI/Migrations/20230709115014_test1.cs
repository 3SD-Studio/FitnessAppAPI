using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class test1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "aspnetusers",
                table: "Exercises",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Exercises_aspnetusers",
                table: "Exercises",
                column: "aspnetusers");

            migrationBuilder.AddForeignKey(
                name: "FK_Exercises_AspNetUsers_aspnetusers",
                table: "Exercises",
                column: "aspnetusers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exercises_AspNetUsers_aspnetusers",
                table: "Exercises");

            migrationBuilder.DropIndex(
                name: "IX_Exercises_aspnetusers",
                table: "Exercises");

            migrationBuilder.DropColumn(
                name: "aspnetusers",
                table: "Exercises");
        }
    }
}
