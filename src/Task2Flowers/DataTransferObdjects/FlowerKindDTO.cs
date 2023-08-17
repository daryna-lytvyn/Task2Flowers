using System;
using System.ComponentModel.DataAnnotations;

namespace Task2Flowers.DataTransferObdjects
{
    public class FlowerKindDTO
    {
        [Required(ErrorMessage = "Title not defined")]
        public String Title { get; set; }
    }
}
