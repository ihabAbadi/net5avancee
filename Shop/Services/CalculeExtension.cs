using Shop.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Services
{
    public class CalculeExtension : ICalculeComplexe
    {

        public decimal ComplexCalcule(decimal Price)
        {
            //LogiqueCalcule
            return Price * 2;
        }
    }
}
