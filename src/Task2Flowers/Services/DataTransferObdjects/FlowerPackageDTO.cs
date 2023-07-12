using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class FlowerPackageDTO
    {
        public FlowerPackageType Type { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public Color Color { get; set; }

        public string Desctiption { get; set; }
    }
}
