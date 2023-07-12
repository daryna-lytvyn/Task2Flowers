using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class AdditionalProductDTO
    {
        public AdditionalProductType Type { get; set; }
        public String Title { get; set; }
        public Color Color { get; set; }
        public String Desctiption { get; set; }
    }
}
