using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FormationApiRest.Models
{
    [Table(name:"Person")]
    public class Person
    {
        private int id;

        [Column(TypeName ="varchar(100)")]
        private string firstName;
        private string lastName;

        private List<Address> addresses;
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public int Id { get => id; set => id = value; }
        public List<Address> Addresses { get => addresses; set => addresses = value; }
    }
}
