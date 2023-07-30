using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("WorkoutUserCustom")]
    public class WorkoutUserCustom {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }
       
        [ForeignKey("Workout")]
        public Workout Workouts { get; set; }

        public DateTime Date { get; set; }
    }
}
