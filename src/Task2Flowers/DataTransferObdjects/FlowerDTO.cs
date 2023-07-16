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
    public class FlowerDTO
    {
        [Required(ErrorMessage = "Flower kind not defined")]
        public FlowerKind Kind { get; set; }

        [Required(ErrorMessage = "Variety not defined")]
        public string Variety { get; set; }

        [Required(ErrorMessage = "Color not defined")]
        public MyColor Color { get; set; }
    }
}
