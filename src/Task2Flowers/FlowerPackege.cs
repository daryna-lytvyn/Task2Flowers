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

        public int FlowersHeight { get; }

        public FlowerPackege( int id, Flower flower, int countOfFlower, int flowersHeight)
        {
            this.Id = id;
            this.Flower = flower;
            this.CountOfFlower = countOfFlower;
            this.FlowersHeight = flowersHeight;
        }
    }
}
