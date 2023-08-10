using System.Data.Entity;
using FitnessAPI.Data;
using Microsoft.AspNetCore.Mvc;
using FitnessAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase {
        public class ExerciseDTO {
            public int Id { get; set; }
            public string? OwnerId { get; set; }
            public string? Name { get; set; }
            public string? Description { get; set; }
            public int Difficulty { get; set; }
        }


        private readonly FitnessAppDbContext _dbContext;

        public ExerciseController(FitnessAppDbContext dbContext) {
            _dbContext = dbContext;
        }

        // GET: api/<ExerciseController>
        [HttpGet]
        public IEnumerable<ExerciseDTO> Get() {
            return _dbContext.Exercise.Select(exercise => new ExerciseDTO {
                Id = exercise!.Id,
                OwnerId = exercise!.Owner.Id,
                Description = exercise.Description,
                Difficulty = exercise.Difficulty,
                Name = exercise.Name
            }).ToList();
        }

        // GET api/<ExerciseController>/5
        [HttpGet("{id}")]
        public ExerciseDTO Get(int id) {
            try {
                var exercise = _dbContext.Exercise.Find(id);
                // Use to load Owner 
                _dbContext.Entry(exercise).Reference(e => e.Owner).Load();

                var result = new ExerciseDTO {
                    Id = exercise!.Id,
                    OwnerId = exercise!.Owner.Id,
                    Description = exercise.Description,
                    Difficulty = exercise.Difficulty,
                    Name = exercise.Name
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
            try {
                Exercise? toRemove = _dbContext.Exercise.Find(id);
                _dbContext.Exercise.Remove(toRemove!);
                _dbContext.SaveChanges();
            } 
            catch (Exception exception) {
                Response.StatusCode = 404;
            }
        }
    }
}
