using FormationNet5.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationNet5.Tools
{
    public static class ToolsClass
    {

        public static (int, string, string, bool) returnTuple()
        {
            return (10, "toto", "titi", true);
        }

        public static decimal CalculateTax(this Vehicule vehicule) => vehicule switch
        {
            Car _ => 10,
            Truck _ => 20,
            null => throw new ArgumentNullException(nameof(vehicule)),
            _ => throw new Exception("Error implementation")
        };
    }
}
