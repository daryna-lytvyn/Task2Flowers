using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class Supplay
    {
        public int Id { get; }
        
        public List<FlowerPackege> FlowerPackeges { get; }

        public DateTime Date { get; }

        public Supplay(int id, List<FlowerPackege> flowerPackeges, DateTime date)
        {
            this.Id = id;
            this.FlowerPackeges = flowerPackeges;
            this.Date = date;

        }

    }
}
