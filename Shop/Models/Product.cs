using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Product
    {
        private int id;
        private string title;
        private decimal price;
        private Category category;
        private ICollection<Image> images;

        public int Id { get => id; set => id = value; }
        public string Title { get => title; set => title = value; }
        public decimal Price { get => price; set => price = value; }
        public Category Category { get => category; set => category = value; }
        public ICollection<Image> Images { get => images; set => images = value; }

        [NotMapped]
        public decimal ComplexCalcule
        {
            get => Price * 2;
        }

        public Product()
        {
            Images = new List<Image>();
        }
    }
}
