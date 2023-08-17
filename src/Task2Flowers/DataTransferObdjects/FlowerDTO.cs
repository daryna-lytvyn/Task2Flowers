using System.ComponentModel.DataAnnotations;
using Task2Flowers.Entities;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.DataTransferObdjects
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
