using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationNet5.Models
{
    public class Car : Vehicule
    {
        string model;
        decimal price;

        public string Model { get => model; set => model = value; }
        public decimal Price { get => price; set => price = value; }

        public Car(string model, decimal price)
        {
            Model = model;
            Price = price;
        }

        public void Deconstruct(out string model, out decimal price)
        {
            model = Model;
            price = Price;
        }
    }
}
