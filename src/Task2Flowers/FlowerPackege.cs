using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class FlowerPackege
    {
        public int Id { get; }

        public Flower Flower { get; }

        public int CountOfFlower { get; }

        public FlowerPackege( int id, Flower flower, int countOfFlower)
        {
            this.Id = id;
            this.Flower = flower;
            this.CountOfFlower = countOfFlower;
        }
    }
}
