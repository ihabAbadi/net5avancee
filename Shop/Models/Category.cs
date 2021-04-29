using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Category
    {
        private int id;
        private string title;
        private Image image;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public Image Image { get => image; set => image = value; }
    }
}
