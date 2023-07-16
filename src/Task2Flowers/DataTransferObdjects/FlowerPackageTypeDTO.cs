using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class FlowerPackageTypeDTO
    {
        [Required(ErrorMessage = "Title not defined")]
        public String Title { get; set; }
    }
}
