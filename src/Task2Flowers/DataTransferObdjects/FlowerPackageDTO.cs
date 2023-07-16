using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class FlowerPackageDTO
    {
        [Required(ErrorMessage = "Flower package type not defined")]
        public FlowerPackageType Type { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        [Required(ErrorMessage = "Color not defined")]
        public MyColor Color { get; set; }

        [Required(ErrorMessage = "Desctiption not defined")]
        public string Desctiption { get; set; }
    }
}
