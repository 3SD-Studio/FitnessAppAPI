using FitnessAPI.Data;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    public class RatingeDTO {
        public int Id { get; set; }
        public int ExerciseID { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public DateTime CreationTime { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseRatingsController : ControllerBase {
        private readonly FitnessAppDbContext _dbContext;

        public ExerciseRatingsController(FitnessAppDbContext dbContext) {
            _dbContext = dbContext;
        }

        // GET api/<ExerciseRatingsController>/5
        [HttpGet("{id}")]
        public RatingeDTO Get(int id) {
            var rating = _dbContext.ExerciseRating.Find(id);
            if (rating == null)
            {
                Response.StatusCode = 404;
                return new RatingeDTO();
            }

            return new RatingeDTO
            {
                Id = rating!.Id,
                Comment = rating!.Comment,
                CreationTime = rating.Date,
                Stars = rating.Stars,
                UserID = rating.User.Id,
                Username = rating.User.UserName!,
                ExerciseID = rating.Exercise.Id
            };
        }

        // POST api/<ExerciseRatingsController>
        [HttpPost]
        public void Post([FromBody] RatingeDTO value) {
            var user = _dbContext.Users.Find(value.UserID);
            var exercise = _dbContext.Exercise.Find(value.ExerciseID);

            if (user == null || exercise == null)
            {
                Response.StatusCode = 404;
                return;
            }

            var newRating = new Ratinge()
            {
                Comment = value.Comment,
                Date = DateTime.Now,
                Stars = value.Stars,
                User = user,
                Exercise = exercise
            };

            _dbContext.ExerciseRating.Add(newRating);
            _dbContext.SaveChanges();
        }

        // DELETE api/<ExerciseRatingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            Ratinge? toRemove = _dbContext.ExerciseRating.Find(id);

            if (toRemove != null)
            {
                _dbContext.ExerciseRating.Remove(toRemove!);
                _dbContext.SaveChanges();
            }
        }
    }
}
