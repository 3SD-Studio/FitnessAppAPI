using FitnessAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Data {
    public class FitnessAppDbContext : IdentityDbContext<User, IdentityRole, string> {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { 
            
        }

        public DbSet<Exercise> Exercise { get; set; } 
        //public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<MusclesGroup> MusclesGroups { get; set;}
        public DbSet<Ratingw> WorkoutRating { get; set; }
        public DbSet<Ratinge> ExerciseRating { get; set; }
        public DbSet<ExerciseWorkoutCustom> ExerciseWorkoutCustom { get; set; }

        public DbSet<WorkoutUserCustom> UserWorkoutsCustom { get; set; }

    }
}
