using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{


    public class Flower
    {
        public int Id { get; }

        public KindOfFlower Kind { get; }

        public string Variety { get; }

        public Color Color { get; }

        public Flower(int id, KindOfFlower kind, string variety, Color color)
        {
            this.Id = id;
            this.Kind = kind;
            this.Variety = variety;
            this.Color = color;
        }

    }
}