using FitnessAPI.Data;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    public class RatingwDTO {
        public int Id { get; set; }
        public int WorkoutID { get; set;}
        public string UserID { get; set; }
        public string Username { get; set; }
        public DateTime CreationTime { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutRatingsController : ControllerBase {
        private readonly FitnessAppDbContext _dbContext;

        public WorkoutRatingsController(FitnessAppDbContext dbContext) {
            _dbContext = dbContext;
        }

        // GET api/<WorkoutRatingsController>/5
        [HttpGet("{id}")]
        public RatingwDTO Get(int id)
        {
            var rating = _dbContext.WorkoutRating.Find(id);
            if (rating == null) {
                Response.StatusCode = 404;
                return new RatingwDTO();
            }

            return new RatingwDTO {
                Id = rating!.Id,
                Comment = rating!.Comment,
                CreationTime = rating.Date,
                Stars = rating.Stars,
                UserID = rating.User.Id,
                Username = rating.User.UserName!,
                WorkoutID = rating.Workout.Id
            };  
        }

        // POST api/<WorkoutRatingsController>
        [HttpPost]
        public void Post([FromBody] RatingwDTO value) {
            var user = _dbContext.Users.Find(value.UserID);
            var workout = _dbContext.Workout.Find(value.WorkoutID);
            
            if (user == null || workout == null) {
                Response.StatusCode = 404;
                return;
            }

            var newRating = new Ratingw() {
                Comment = value.Comment,
                Date = DateTime.Now,
                Stars = value.Stars,
                User = user,
                Workout = workout
            };

            _dbContext.WorkoutRating.Add(newRating);
            _dbContext.SaveChanges();
        }

        // DELETE api/<WorkoutRatingsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            Ratingw? toRemove = _dbContext.WorkoutRating.Find(id);

            if (toRemove != null) {
                _dbContext.WorkoutRating.Remove(toRemove!);
                _dbContext.SaveChanges();
            }
        }
    }
}
