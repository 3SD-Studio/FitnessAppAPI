using FitnessAPI.Data;
using FitnessAPI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    // Data Transfer Objects
    // Define how data will be sent between API and client
    // Don't contains any logic
    public class ExercisesForWorkoutDTO {
        public int Id { get; set; }
        public int NumberOfSeries { get; set; }
        public int RepeatInSeries { get; set; }
        public string? Name { get; set; }

    }

    public class WorkoutDTO {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Difficulty { get; set; }
        public IEnumerable<ExercisesForWorkoutDTO> ExerciseIDs { get; set; } = new List<ExercisesForWorkoutDTO>();
    }


    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutController : ControllerBase {
        private readonly FitnessAppDbContext _dbContext;

        public WorkoutController(FitnessAppDbContext dbContext) {
            _dbContext = dbContext;
        }

        private IEnumerable<ExercisesForWorkoutDTO> GetExercisesForWorkout(int workoutId) {
            return _dbContext.ExerciseWorkoutCustom
                .Select(e => e)
                .Where(entity => entity.Workouts.Id == workoutId)
                .Select(entity => new ExercisesForWorkoutDTO()
                {
                    Id = entity.Exercises.Id,
                    Name = entity.Exercises.Name,
                    NumberOfSeries = entity.NumberOfSeries,
                    RepeatInSeries = entity.RepeatInSeries,
                })
                .ToList();
        }

        // GET: api/<WorkoutController>
        [HttpGet]
        public IEnumerable<WorkoutDTO> Get() {
            var result =  _dbContext.Workout.Select(w => new WorkoutDTO()
            {
                Id = w.Id,
                Name = w.Name,
                Description = w.Description,
                Difficulty = w.Difficulty,
                ExerciseIDs = null

            }).ToList();

            foreach (var workout in result) {
                workout.ExerciseIDs = GetExercisesForWorkout(workout.Id);
            }

            return result;
        }

        // GET api/<WorkoutController>/5
        [HttpGet("{id}")]
        public WorkoutDTO Get(int id) {
            
            var exercises = _dbContext.ExerciseWorkoutCustom
                .Select(e => e)
                .Where(entity => entity.Workouts.Id == id)
                .Select(entity => new ExercisesForWorkoutDTO() {
                    Id = entity.Exercises.Id,
                    Name = entity.Exercises.Name,
                    NumberOfSeries = entity.NumberOfSeries,
                    RepeatInSeries = entity.RepeatInSeries,
                })
                .ToList();


            var workout = _dbContext.Workout.Find(id);

            if (workout == null) {
                Response.StatusCode = 404;
                return new WorkoutDTO();
            }

            return new WorkoutDTO() {
                Id = workout!.Id,
                Name = workout.Name,
                Description = workout.Description,
                Difficulty = workout!.Difficulty,
                ExerciseIDs = exercises
            };

        }

        // POST api/<WorkoutController>
        [HttpPost]
        public void Post([FromBody] WorkoutDTO value) {
            var newWorkout = new Workout()
            {
                Name = value.Name,
                Description = value.Description,
                Difficulty = value.Difficulty,
            };
            _dbContext.Add<Workout>(newWorkout);

            foreach (var tempExercise in value.ExerciseIDs)
            {
                try {
                    var exercise = _dbContext.Exercise.First(exercise => exercise.Id == tempExercise.Id);
                    var newExerciseWorkout = new ExerciseWorkoutCustom()
                    {
                        Workouts = newWorkout,
                        Exercises = exercise,
                        NumberOfSeries = tempExercise.NumberOfSeries,
                        RepeatInSeries = tempExercise.RepeatInSeries,
                    };
                    _dbContext.Add<ExerciseWorkoutCustom>(newExerciseWorkout);
                }
                catch (Exception exception) {
                    Response.StatusCode = 404;
                    return;
                }
            }

            _dbContext.SaveChanges();
        }

        // DELETE api/<WorkoutController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
            Workout? toRemove = _dbContext.Workout.Find(id);

            if (toRemove != null) {
                _dbContext.Workout.Remove(toRemove!);
                _dbContext.SaveChanges();
            }
        }
    }
}
