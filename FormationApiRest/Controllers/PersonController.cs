using FormationApiRest.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

        //DataContext _dataContext;
        //public PersonController(DataContext dataContext)
        //{
        //    _dataContext = dataContext;
        //}

        IDbContextFactory<DataContext> _dataContextFactory;

        public PersonController(IDbContextFactory<DataContext> dataContextFactory)
        {
            _dataContextFactory = dataContextFactory;
        }
        [HttpGet]
        //public List<Person> Get() => new () {new Person {FirstName = "toto", LastName ="tata"},new Person {FirstName = "titi", LastName ="minet"},};
        public List<Models.Person> Get()
        {
            //DataContext data = new DataContext();
            //var req = _dataContext.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToQueryString();
            //return _dataContext.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToList();
            Task<List<Models.Person>> t = new Task<List<Models.Person>>(() =>
            {
                using DataContext data = _dataContextFactory.CreateDbContext();
                var req = data.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToQueryString();
                return data.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToList();
            });
            t.Start();
            return t.Result;
        }

        [HttpGet("{id}")]
        public Person Get([FromQuery]int id)
        {
            //DataContext data = new DataContext();
            //data.Persons.Add(new Models.Person { FirstName = "toto", LastName = "tata" });
            //data.Persons.Add(new Models.Person { FirstName = "titi", LastName = "minet", Addresses = new List<Models.Address>() { new Models.Address() { Adress = "warner"} } });
            //data.SaveChanges();
            //var liste = data.Persons.Include(p => p.Addresses).AsSplitQuery().ToQueryString();
            
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
