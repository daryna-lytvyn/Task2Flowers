using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class SupplayDTO
    {
        [Required(ErrorMessage = "Bundles storage not defined")]
        public IStorage<Bundle> Bundles { get; set; }

        [Required(ErrorMessage = "Finish date not defined")]
        public DateTime FinishDate { get; set; }
    }
}
