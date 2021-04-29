using FormationApiRest.Tools;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
            #region Exemple d'utilisation instance DataContext
            //DataContext data = new DataContext();
            //var req = _dataContext.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToQueryString();
            //return _dataContext.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToList();
            #endregion

            #region exemple d'utilisation instance DbContextFactory à l'interieur d'une task
            /*Task<List<Models.Person>> t = new Task<List<Models.Person>>(() =>
            {
                using DataContext data = _dataContextFactory.CreateDbContext();
                var req = data.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToQueryString();
                return data.Persons.Include(p => p.Addresses.Where(a => a.Adress.Contains("w"))).ToList();
            });
            t.Start();
            return t.Result;*/
            #endregion

            #region exemple d'utilisation requete à l'aide d'entityframework
            using DataContext data = _dataContextFactory.CreateDbContext();
            //SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int);
            //p.Value = 1;
            string value = "3 OR 1=1";
            //A vérifier
            List<Models.Person> persons = data.Persons.FromSqlInterpolated($"SELECT * FROM Person where id > {value}").ToList();
            //Passer par une commande, pour inserer ou une mise à jour 
            //data.Database.ExecuteSqlRaw("SELECT * FROM Person where id > @Id", p);
            //utiliser EFcore comme couche pour acceder au ADO.NET
            //DbCommand command = data.Database.GetDbConnection().CreateCommand();
            //command.CommandText = "SELECT * FROM Person where id > @id";
            //command.Parameters.Add(new SqlParameter("@id", 1));
            //using( DbDataReader reader = command.ExecuteReader())
            //{

            //}
            return persons;
            #endregion
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
            #region exemple d'utilisation transation efCore
            using DataContext data = _dataContextFactory.CreateDbContext();
            using var transaction = data.Database.BeginTransaction();
            try
            {
                data.Persons.Add(new Models.Person() { FirstName = "new", LastName = "new l" });
                data.SaveChanges();
                transaction.CreateSavepoint("pointSauvegarde");
                transaction.Commit();
            }catch(Exception e)
            {
                transaction.RollbackToSavepoint("pointSauvegarde");
            }
            #endregion
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
