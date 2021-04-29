using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Image
    {
        private int id;

        private string url;

        public int Id { get => id; set => id = value; }
        public string Url { get => url; set => url = value; }
    }
}
