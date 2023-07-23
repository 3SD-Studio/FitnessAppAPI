﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Workouts")]
    public class Workout {
        [Key]
        public int Id { get; set; }
        [Required]
        List<ExerciseWorkout> Exercises{ get; set; }

    }
}
