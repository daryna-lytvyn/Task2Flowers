using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Entities
{
    public class MyColor
    {
        public int Id { get; }
        public String Title { get; }
        
        public Byte R { get; }
        public Byte G { get; }
        public Byte B { get; }

        public MyColor(int id, String title, Byte r, Byte g, Byte b)
        {
            this.Id = id;
            this.Title = title;
            this.R = r;
            this.G = g;
            this.B = b;
        }
    }
}
