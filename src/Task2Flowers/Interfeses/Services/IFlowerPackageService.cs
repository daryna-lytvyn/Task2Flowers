using System.Collections.Generic;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerPackageService : IService<FlowerPackage>
    {
        void Add(FlowerPackageDTO fPDTO);
        IReadOnlyList<FlowerPackage> GetSortByType();
    }
}
