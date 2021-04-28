using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FormationNet5.Models
{
    public class ClassA
    {
        private ITypeB b;

        public ITypeB B { get => b; set => b = value; }

        public ClassA(ITypeB b)
        {
            B = b;
        }
    }
}
