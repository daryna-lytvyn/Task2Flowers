using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities;

namespace Task2Flowers
{
    public class FlowerPackage : Product
    {
        public FlowerPackageType Type { get; }

        public int Height { get; }

        public int Width { get; }

        public MyColor Color { get; }

        public string Desctiption { get; }

        public FlowerPackage(int id, FlowerPackageType type, int height, int width, MyColor color, string description) : base(id)
        {
            this.Type = type;
            this.Height = height;
            this.Width = width;
            this.Color = color;
            this.Desctiption = description;
        }
    }
}
