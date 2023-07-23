using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("ExerciseRatings")]
    public class ExerciseRating {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("aspnetusers")]
        public FitnessAppUser User { get; set; }

        [Required]
        [ForeignKey("Exercises")]
        public Exercise Exercise { get; set; }
        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
    }
}
