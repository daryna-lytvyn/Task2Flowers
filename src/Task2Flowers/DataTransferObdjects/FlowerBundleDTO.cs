using System.ComponentModel.DataAnnotations;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.DataTransferObdjects
{
    public class FlowerBundleDTO
    {

        [Required(ErrorMessage = "Flower not defined")]
        public Flower Flower { get; set; }

        public int CountOfFlower { get; set; }

        public int Height { get; set; }
    }
}
