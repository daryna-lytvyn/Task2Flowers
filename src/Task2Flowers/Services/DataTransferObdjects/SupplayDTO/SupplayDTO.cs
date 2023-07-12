using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Services.DataTransferObdjects
{
    public class SupplayDTO
    {
        public Storage<Bundle> Bundles { get; set; }

        public DateTime FinishDate { get; set; }
    }
}
