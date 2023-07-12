using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class BundleDTO
    {
        public int SupplayId { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
    }
}
