using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class KindOfFlower
    {
        public int Id { get; }

        public string Title { get; }

        public KindOfFlower(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
