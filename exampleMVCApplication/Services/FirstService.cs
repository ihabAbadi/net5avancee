using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace exampleMVCApplication.Services
{
    public class FirstService : ISingeletonInterface
    {
        private Guid guid;

        public FirstService()
        {
            guid = Guid.NewGuid();
        }
        public Guid GetGuid => guid;
    }
}
