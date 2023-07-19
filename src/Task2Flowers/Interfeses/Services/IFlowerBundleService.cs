using System.Collections.Generic;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerBundleService : IService<FlowerBundle>
    {
        void Add(FlowerBundleDTO fBDTO);
        IReadOnlyList<FlowerBundle> GetSortByFlower();
        IReadOnlyList<FlowerBundle> GetSortByKindOfFlower();
    }
}
