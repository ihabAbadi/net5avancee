using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Order
    {
        private int id;
        private decimal total;
        private ICollection<OrderProduct> products;

        public int Id { get => id; set => id = value; }
        public decimal Total { get => total; set => total = value; }
        public ICollection<OrderProduct> Products { get => products; set => products = value; }

        
    }
}
