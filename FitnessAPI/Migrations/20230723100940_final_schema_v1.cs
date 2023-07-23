using System;
using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace FitnessAPI.Migrations
{
    /// <inheritdoc />
    public partial class final_schema_v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExerciseRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    aspnetusers = table.Column<string>(type: "varchar(255)", nullable: false),
                    Exercises = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseRatings_AspNetUsers_aspnetusers",
                        column: x => x.aspnetusers,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExerciseRatings_Exercises_Exercises",
                        column: x => x.Exercises,
                        principalTable: "Exercises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UsersWorkouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false),
                    WorkoutId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersWorkouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersWorkouts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsersWorkouts_Workouts_WorkoutId",
                        column: x => x.WorkoutId,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "WorkoutRatings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    WorkoutID = table.Column<int>(type: "int", nullable: false),
                    apsnetuser = table.Column<string>(type: "varchar(255)", nullable: false),
                    Comment = table.Column<string>(type: "longtext", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkoutRatings_AspNetUsers_apsnetuser",
                        column: x => x.apsnetuser,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkoutRatings_Workouts_WorkoutID",
                        column: x => x.WorkoutID,
                        principalTable: "Workouts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRatings_aspnetusers",
                table: "ExerciseRatings",
                column: "aspnetusers");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRatings_Exercises",
                table: "ExerciseRatings",
                column: "Exercises");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWorkouts_UserId",
                table: "UsersWorkouts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersWorkouts_WorkoutId",
                table: "UsersWorkouts",
                column: "WorkoutId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRatings_apsnetuser",
                table: "WorkoutRatings",
                column: "apsnetuser");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutRatings_WorkoutID",
                table: "WorkoutRatings",
                column: "WorkoutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExerciseRatings");

            migrationBuilder.DropTable(
                name: "UsersWorkouts");

            migrationBuilder.DropTable(
                name: "WorkoutRatings");
        }
    }
}
