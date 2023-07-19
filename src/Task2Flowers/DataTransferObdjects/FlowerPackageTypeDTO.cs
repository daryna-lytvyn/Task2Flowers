using System;
using System.ComponentModel.DataAnnotations;

namespace Task2Flowers.DataTransferObdjects
{
    public class FlowerPackageTypeDTO
    {
        [Required(ErrorMessage = "Title not defined")]
        public String Title { get; set; }
    }
}
