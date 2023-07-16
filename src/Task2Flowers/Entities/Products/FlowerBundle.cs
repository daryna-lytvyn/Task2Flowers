using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerBundle: Product
    {
        public Flower Flower { get; }
        public int CountOfFlower { get; }
        public int Height { get; }

        public FlowerBundle(int id, Flower flower, int countOfFlower, int height): base( id)
        {
            this.Flower = flower;
            this.CountOfFlower = countOfFlower;
            this.Height = height;
        }
    }
}
