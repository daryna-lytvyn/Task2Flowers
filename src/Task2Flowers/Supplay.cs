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

        public List<Package> FlowerPackeges { get; set; }

        public DateTime? FinishDate { get; set; }

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, List<Package> flowerPackeges, DateTime date)
        {
            this.Id = id;
            this.FlowerPackeges = flowerPackeges;
            this.FinishDate = date;

        }

        public bool AddPackeges(List<Package> flowerPackeges)
        {
            if (this.FlowerPackeges == null)
            {
                this.FlowerPackeges = flowerPackeges;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddFinishDate(DateTime date)
        {
            if (this.FinishDate == FinishDate)
            {
                this.FinishDate = date;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
