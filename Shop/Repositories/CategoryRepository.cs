using Microsoft.EntityFrameworkCore;
using Shop.Interfaces;
using Shop.Models;
using Shop.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Repositories
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(DataContext data) : base(data)
        {
        }

        public Category Create(Category element)
        {
            throw new NotImplementedException();
        }

        public Category Find(object primaryKey)
        {
            throw new NotImplementedException();
        }

        public ICollection<Category> FindAll()
        {
            return _data.Categories.ToList();
        }

        public async Task<IEnumerable<Category>> FindAllAsync()
        {
            return await _data.Categories.Include(e => e.Image).ToListAsync();
        }
    }
}
