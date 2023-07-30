using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("ExerciseWorkoutCustom")]
    public class ExerciseWorkoutCustom {
        [Key]
        public int Id { get; set; }
        //[Required]
        //[ForeignKey("Exercise")]
        //public Exercise ExerciseId { get; set; }
        
        //[Required]
        [ForeignKey("Workout")]
        public Workout Workouts { get; set; }

        [ForeignKey("Exercise")]
        public Exercise Exercises { get; set; }

        public int NumberOfSeries { get; set; }
        public int RepeatInSeries { get; set; }
    }
}
