using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Generators
{
    public interface IServiceAdditionalProduct: IService<AdditionalProduct>
    {
        public AdditionalProduct Add(AdditionalProductDTO aPDTO);
        public IReadOnlyList<AdditionalProduct> GetSortByType();

    }
}
