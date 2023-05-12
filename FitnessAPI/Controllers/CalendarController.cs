using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FitnessAPI.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarController : ControllerBase {
        // GET: api/<CalendarController>
        [HttpGet]
        public IEnumerable<string> Get() {
            return new List<string>();
        }

        // GET api/<CalendarController>/5
        [HttpGet("{id}")]
        public string Get(int id) {
            return "value";
        }

        // POST api/<CalendarController>
        [HttpPost]
        public void Post([FromBody] string value) {
        }

        // PUT api/<CalendarController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }

        // DELETE api/<CalendarController>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
