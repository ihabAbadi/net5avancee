using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Interfaces
{
    public interface IRepository<T>
    {
        T Create(T element);
        T Find(object primaryKey);
        ICollection<T> FindAll();

        Task<IEnumerable<T>> FindAllAsync();

    }
}
