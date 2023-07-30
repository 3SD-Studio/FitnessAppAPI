using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Workout")]
    public class Workout {
        [Key]
        public int Id { get; set; }

        [Required]
        //[ForeignKey("Owner")]
        //public User Owner { get; set; }

        public ICollection<Ratingw> Ratings { get; } = new List<Ratingw>();
        public ICollection<Exercise> Exercises { get; } = new List<Exercise>();
        public ICollection<User> Users { get; } = new List<User>();

        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Difficulty { get; set; }

    }
}
