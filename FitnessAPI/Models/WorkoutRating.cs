using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("WorkoutRatings")]
    public class WorkoutRating {
        [Key]
        public int Id { get; set; }
        [Required]
        [ForeignKey("WorkoutID")]
        public Workout Workout { get; set; }

        [Required]
        [ForeignKey("apsnetuser")]
        public FitnessAppUser User { get; set; }
        
        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
    }
}
