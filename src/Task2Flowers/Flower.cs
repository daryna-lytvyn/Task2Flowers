using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{

    public class Flower: Product
    {
        public KindOfFlower Kind { get; }

        public string Variety { get; }

        public Flower(int id, KindOfFlower kind, string variety, Color color, string description) : base(id, color, description)
        {
            this.Kind = kind;
            this.Variety = variety;
        }

    }
}