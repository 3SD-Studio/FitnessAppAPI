using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("UsersWorkouts")]
    public class UserWorkout {
        [Key]
        public int Id { get; set; }
        public DateTime Date {get; set; }

        [ForeignKey("UserId")]
        public FitnessAppUser User { get; set; }
        [ForeignKey("WorkoutId")]
        public Workout Workout { get; set; }
    }
}
