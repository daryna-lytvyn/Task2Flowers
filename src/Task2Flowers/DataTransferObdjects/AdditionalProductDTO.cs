using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class AdditionalProductDTO
    {
        [Required(ErrorMessage = "Type not defined")]
        public AdditionalProductType Type { get; set; }

        [Required(ErrorMessage = "Title not defined")]
        public String Title { get; set; }

        [Required(ErrorMessage = "Color not defined")]
        public MyColor Color { get; set; }

        [Required(ErrorMessage = "Desctiption not defined")]
        public String Desctiption { get; set; }
    }
}
