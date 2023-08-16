using System.ComponentModel.DataAnnotations;
using Task2Flowers.Entities;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.DataTransferObdjects
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
        public string Description { get; set; }
    }
}
