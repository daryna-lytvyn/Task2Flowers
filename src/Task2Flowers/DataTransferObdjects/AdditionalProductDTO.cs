using System;
using System.ComponentModel.DataAnnotations;
using Task2Flowers.Entities;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.DataTransferObdjects
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
        public String Description { get; set; }
    }
}
