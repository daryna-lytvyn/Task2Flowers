using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class FlowerBundleDTO
    {
        public Flower Flower { get; set; }
        public int CountOfFlower { get; set; }
        public int Height { get; set; }
    }
}
