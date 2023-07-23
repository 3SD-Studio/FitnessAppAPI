using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class final_schema_v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_aspnetusers",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "aspnetusers",
                table: "Workouts",
                newName: "OwnerId");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_aspnetusers",
                table: "Workouts",
                newName: "IX_Workouts_OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_OwnerId",
                table: "Workouts",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Workouts_AspNetUsers_OwnerId",
                table: "Workouts");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Workouts",
                newName: "aspnetusers");

            migrationBuilder.RenameIndex(
                name: "IX_Workouts_OwnerId",
                table: "Workouts",
                newName: "IX_Workouts_aspnetusers");

            migrationBuilder.AddForeignKey(
                name: "FK_Workouts_AspNetUsers_aspnetusers",
                table: "Workouts",
                column: "aspnetusers",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
