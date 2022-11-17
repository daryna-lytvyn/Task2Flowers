using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class KindOfFlower
    {
        public int id { get; }

        public string title { get; }

        public KindOfFlower(int id, string title)
        {
            this.id = id;
            this.title = title;
        }

    }
}
