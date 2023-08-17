using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerService : IService<Flower>
    {
        Task AddAsync(FlowerDTO flowerDTO);
        Task<IReadOnlyList<Flower>> GetSortByKindAsync();
    }
}
