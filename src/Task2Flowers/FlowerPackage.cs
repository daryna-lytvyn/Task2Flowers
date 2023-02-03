using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class FlowerPackage : Product
    {
        public FlowerPackageType Type { get; }

        public int Height { get; }

        public int Width { get; }

        public FlowerPackage(int id, FlowerPackageType type, int height, int width, Color color, string description) : base(id, color, description)
        {
            this.Type = type;
            this.Height = height;
            this.Width = width;
        }
    }
}
