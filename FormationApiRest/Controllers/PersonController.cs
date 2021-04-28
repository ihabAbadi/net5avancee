using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationApiRest.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Person> Get()
        {
            return new List<Person>() {
                new Person {FirstName = "toto", LastName ="tata"},
                new Person {FirstName = "titi", LastName ="minet"},
            };
        }

        [HttpGet("{id}")]
        public Person Get([FromQuery]int id)
        {
            return new Person { FirstName = "toto", LastName = "tata" };
        }

        [HttpPost]
        public Person Post([FromBody]Person person)
        {
            return person;
        }

        [HttpPut]
        public Person Put([FromBody]Person person, [FromQuery]int id)
        {
            return person;
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok(new { message = "Delete Ok" });
        }
    }

    public record Person()
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    };
}
