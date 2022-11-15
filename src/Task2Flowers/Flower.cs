using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{


    class Flower
    {
        private int id;

        private string kind;

        private string variety;

        private Color color;

        public Flower(int id, string kind, string variety, Color color)
        {
            this.id = id;
            this.kind = kind;
            this.variety = variety;
            this.color = color;
        }
    }
}