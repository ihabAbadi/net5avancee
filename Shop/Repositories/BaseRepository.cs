using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public abstract class BaseRepository
    {
        protected DataContext _data;

        public BaseRepository(DataContext data)
        {
            _data = data;
        }
    }
}
