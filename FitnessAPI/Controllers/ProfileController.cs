﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitnessAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : Controller
    {
        // GET
        // GET
        [HttpGet]
        public IEnumerable<string> Get() {
            return new List<string>();
        }
        
        //
        [HttpPost]
        public void Post([FromBody] string value) {
            
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value) {
        }
        
        [HttpDelete("{id}")]
        public void Delete(int id) {
            
        }
    }
}

