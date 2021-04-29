using Microsoft.Extensions.DependencyInjection;
using Shop.Interfaces;
using Shop.Models;
using Shop.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Tools
{
    public static class Extension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Category>, CategoryRepository>();
            services.AddScoped<IRepository<Product>, ProductRepository>();
        }
    }
}
