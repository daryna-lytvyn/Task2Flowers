using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities;

namespace Task2Flowers
{

    public class Flower
    {
        public int Id { get; }
        public FlowerKind Kind { get; }
        public string Variety { get; }
        public MyColor Color { get; }


        public Flower(int id, FlowerKind kind, string variety, MyColor color)
        {
            this.Id = id;
            this.Kind = kind;
            this.Variety = variety;
            this.Color = color;
        }

    }
}