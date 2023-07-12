using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class FlowerDTO
    {
        public FlowerKind Kind { get; set; }
        public string Variety { get; set; }
        public Color Color { get; set; }
    }
}
