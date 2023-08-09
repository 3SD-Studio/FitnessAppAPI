using Microsoft.AspNetCore.Identity;

namespace FitnessAPI.Models {
    public class User : IdentityUser {
        public DateTime? DateOfBirth { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Ratinge> WrittenExerciseRatings { get; } = new List<Ratinge>();
        public ICollection<Ratingw> WrittenWorkoutRatings { get; } = new List<Ratingw>();
        public ICollection<WorkoutUserCustom> WorkoutUser { get; } = new List<WorkoutUserCustom>();

        //public ICollection<Workout> OwnedWorkouts { get; } = new List<Workout>();
    }
}
