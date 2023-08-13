using System.Data.Entity;
using FitnessAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FitnessAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    // Data Transfer Object
    // Defines how data will be sent between API and client
    // Doesn't contain any logic
    public class RatingForExerciseDTO {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Username { get; set; }
        public DateTime CreationTime { get; set; }
        public int Stars { get; set; }
        public string Comment { get; set; }
    }
    public class ExerciseDTO {
        public int Id { get; set; }
        public string? OwnerId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Difficulty { get; set; }
        public IEnumerable<RatingForExerciseDTO> Ratings { get; set; } = new List<RatingForExerciseDTO>();
    }


    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase {
        private readonly FitnessAppDbContext _dbContext;

        public ExerciseController(FitnessAppDbContext dbContext) {
            _dbContext = dbContext;
        }

        private IEnumerable<RatingForExerciseDTO> GetRatingsForExercise(int exerciseId) {
            return _dbContext.ExerciseRating
                .Select(r => r)
                .Where(r => r.Exercise.Id == exerciseId)
                .Select(r => new RatingForExerciseDTO()
                {
                    Id = r.Id,
                    UserID = r.User.Id,
                    Username = r.User.UserName,
                    CreationTime = r.Date,
                    Stars = r.Stars,
                    Comment = r.Comment
                }).ToList();
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public IEnumerable<ExerciseDTO> Get() {
            var result = _dbContext.Exercise.Select(exercise => new ExerciseDTO {
                Id = exercise!.Id,
                OwnerId = exercise!.Owner.Id,
                Description = exercise.Description,
                Difficulty = exercise.Difficulty,
                Name = exercise.Name,
                Ratings = null
            }).ToList();

            foreach (var exercise in result)
            {
                exercise.Ratings = GetRatingsForExercise(exercise.Id);
            }

            return result;
        }

        // GET api/<ExerciseController>/5
        [HttpGet("{id}")]
        public ExerciseDTO Get(int id) {
            try
            {
                var ratings = GetRatingsForExercise(id);
                var exercise = _dbContext.Exercise.Find(id);
                // Use to load Owner 
                _dbContext.Entry(exercise).Reference(e => e.Owner).Load();

                var result = new ExerciseDTO {
                    Id = exercise!.Id,
                    OwnerId = exercise!.Owner.Id,
                    Description = exercise.Description,
                    Difficulty = exercise.Difficulty,
                    Name = exercise.Name,
                    Ratings = ratings
                };

                return result;
            } 
            catch (Exception exception) {
                Response.StatusCode = 404;
                return new ExerciseDTO();
            }

        }

        // POST api/<ExerciseController>
        [HttpPost]
        public void Post([FromBody] ExerciseDTO exercise) {
            try {
                User? owner = _dbContext.Users.FirstOrDefault(u => u.Id == exercise.OwnerId);

                Console.Write(owner.LastName);

                Exercise newExercise = new Exercise {
                    Owner = owner,
                    Name = exercise.Name,
                    Description = exercise.Description,
                    Difficulty = exercise.Difficulty
                };

                _dbContext.Add<Exercise>(newExercise);
                _dbContext.SaveChanges();
            }
            catch (Exception exception) { 
                Response.StatusCode = 400;
            }

        }

        // DELETE api/<ExerciseController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            Exercise? toRemove = _dbContext.Exercise.Find(id);

            if (toRemove != null)
            {
                _dbContext.Exercise.Remove(toRemove!);
                _dbContext.SaveChanges();
            }
        }
    }
}
