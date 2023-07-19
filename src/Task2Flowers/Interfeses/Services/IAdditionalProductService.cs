using System.Collections.Generic;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IAdditionalProductService : IService<AdditionalProduct>
    {
        void Add(AdditionalProductDTO aPDTO);
        IReadOnlyList<AdditionalProduct> GetSortByType();

    }
}
