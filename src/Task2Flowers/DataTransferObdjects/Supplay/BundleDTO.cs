using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class BundleDTO
    {
        public int SupplayId { get; set; }

        [Required(ErrorMessage = "Product not defined")]
        public Product Product { get; set; }

        public int Count { get; set; }
    }
}
