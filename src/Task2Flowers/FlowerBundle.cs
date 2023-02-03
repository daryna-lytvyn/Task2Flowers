using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerBundle: Bundle
    {
       
        public int FlowersHeight { get; }

        public FlowerBundle(int id, int idOfSupplay, Flower flower, int countOfFlower, int flowersHeight): base( id,  idOfSupplay,  flower,  countOfFlower)
        {
            this.FlowersHeight = flowersHeight;
        }
    }
}
