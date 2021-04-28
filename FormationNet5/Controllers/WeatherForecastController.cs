using FormationNet5.Models;
using FormationNet5.Tools;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationNet5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            //test first record
            //Weather w = new Weather(20);
            /*Weather w = new(20);
            Weather w2 = w with { temperature = 30 };
            Person p = new Person { FirstName = "ihab", LastName = "abadi" };
            //p.FirstName = "toto";
            //example use discards operator
            var (_, element,_,test) = ToolsClass.returnTuple();
            Vehicule c = new Car("ford", 10000);
            c.CalculateTax();
            if(c is Car)
            {
                var (_, price) = (Car)c;
            }*/
            //Exemple Injection dependance
            ClassB b = new ClassB();
            ClassA a = new ClassA(b);
            
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }

    public record Weather(int temperature);

    public record Person
    {
        public string FirstName { get; init; }
        public string LastName { get; init; }
    };
}
