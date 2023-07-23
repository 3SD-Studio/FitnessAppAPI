using FitnessAPI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FitnessAPI.Data {
    public class FitnessAppDbContext : IdentityDbContext<FitnessAppUser, IdentityRole, string> {
        public FitnessAppDbContext(DbContextOptions<FitnessAppDbContext> options) : base(options) { 
            
        }

        public DbSet<Exercise> Exercise { get; set; } 
        public DbSet<ExerciseWorkout> ExerciseWorkouts { get; set; }
        public DbSet<Workout> Workout { get; set; }
        public DbSet<MusclesGroups> MusclesGroups { get; set;}
        public DbSet<WorkoutRating> WorkoutRating { get; set; }
        public DbSet<ExerciseRating> ExerciseRating { get; set; }
        public DbSet<UserWorkout> UserWorkouts { get; set; }


    }
}
