using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Workouts")]
    public class Workout {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("OwnerId")]
        public FitnessAppUser Owner { get; set; }

        public string? Name { get; set; }
        public string? Description { get; set; }

        public int Difficulty { get; set; }

    }
}
