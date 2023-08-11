using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IAdditionalProductService : IService<AdditionalProduct>
    {
        Task AddAsync(AdditionalProductDTO additionalProductDTO);
        Task<IReadOnlyList<AdditionalProduct>> GetSortByTypeAsync();

    }
}
