using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationApiRest.Models
{
    public class Address
    {
        private int id;
        private string adress;

        public int Id { get => id; set => id = value; }
        public string Adress { get => adress; set => adress = value; }
    }
}
