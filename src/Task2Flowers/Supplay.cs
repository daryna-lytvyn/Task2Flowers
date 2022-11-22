using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class Supplay
    {
        public int Id { get; }
        
        public List<Package> FlowerPackeges { get; }

        public DateTime Date { get; }

        public Supplay(int id, List<Package> flowerPackeges, DateTime date)
        {
            this.Id = id;
            this.FlowerPackeges = flowerPackeges;
            this.Date = date;

        }
    }
}
