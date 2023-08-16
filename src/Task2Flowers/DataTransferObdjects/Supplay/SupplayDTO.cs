using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Task2Flowers.Entities.Supplay;
using Task2Flowers.Interfeses;

namespace Task2Flowers.DataTransferObdjects.Supplay
{
    public class SupplayDTO
    {
        [Required(ErrorMessage = "Bundles collection not defined")]
        public List<Bundle> Bundles { get; set; }

        [Required(ErrorMessage = "Finish date not defined")]
        public DateTime FinishDate { get; set; }
    }
}
