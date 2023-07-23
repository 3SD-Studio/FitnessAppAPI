using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Exercises")]
    public class Exercise {
        [Key]
        public int Id { get; set; }

        [ForeignKey("aspnetusers")]
        [Required]
        public FitnessAppUser Owner { get; set; }
        [Required]
        public string? Name { get; set; } 
        public string? Description { get; set; }
        public List<MusclesGroups> MusclesGroups { get; set; }  = new List<MusclesGroups>();
        [Required]
        public int Difficulty { get; set; }
    }
}
