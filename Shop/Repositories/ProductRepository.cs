using Shop.Interfaces;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        DataContext _data;
        public ProductRepository(DataContext data)
        {
            _data = data;
        }
        public Product Create(Product element)
        {
            _data.Products.Add(element);
            _data.SaveChanges();
            return element;
        }

        public Product Find(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> FindAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
