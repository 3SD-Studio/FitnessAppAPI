using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Exercise")]
    public class Exercise {
        [Key]
        public int Id { get; set; }

        //[ForeignKey("Owner")]
        [Required]
        public User Owner { get; set; }

        public ICollection<Ratinge> Ratings { get; } = new List<Ratinge>();
        public ICollection<ExerciseWorkoutCustom> ExerciseWorkout = new List<ExerciseWorkoutCustom>();
        public ICollection<MusclesGroup> MusclesGroups { get; } = new List<MusclesGroup>();

        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public int Difficulty { get; set; }
    }
}
