using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("MusclesGroups")]
    public class MusclesGroups {
        [Key]
        public int Id { get; set; }
        public int Name { get; set; }
        public string? Description { get; set; }
    }
}
