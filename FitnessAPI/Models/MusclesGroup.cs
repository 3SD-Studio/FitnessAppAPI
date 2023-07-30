using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("MusclesGroup")]
    public class MusclesGroup {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Exercise> Exercises { get; } = new List<Exercise>();
    }
}
