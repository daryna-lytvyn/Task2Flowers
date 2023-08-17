using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerBundleService : IService<FlowerBundle>
    {
        Task AddAsync(FlowerBundleDTO fBDTO);
        Task<IReadOnlyList<FlowerBundle>> GetSortByFlowerAsync();
        Task<IReadOnlyList<FlowerBundle>> GetSortByKindOfFlowerAsync();
    }
}
