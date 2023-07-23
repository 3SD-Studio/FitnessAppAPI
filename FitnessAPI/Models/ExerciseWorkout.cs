using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("ExercisesWorkouts")]
    public class ExerciseWorkout {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [ForeignKey("Exercises")]
        public Exercise Exercise { get; set; }

        [Required]
        [ForeignKey("Workouts")]
        public Workout Workout { get;set; }
    }
}
