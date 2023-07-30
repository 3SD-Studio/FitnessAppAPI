using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAPI.Models {
    [Table("Ratingw")]
    public class Ratingw {
        [Key]
        public int Id { get; set; }

        //[Required]
        //[ForeignKey("Creator")]
        public User User { get; set; }

        //[Required]
        //[ForeignKey("Workouts")]
        public Workout Workout { get; set; }

        public string Comment { get; set; }
        public int Stars { get; set; }
        public DateTime Date { get; set; }
    }
}
