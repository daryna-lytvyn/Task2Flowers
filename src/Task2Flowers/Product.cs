using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public abstract class Product
    {
        public int Id { get; }

        public Color Color { get; }

        public string Desctiption { get; }

        public Product (int id, Color color, string description)
        {
            this.Id = id;
            this.Title = title;
            this.Color = color;
            this.Desctiption = description;
        }
    }
}
