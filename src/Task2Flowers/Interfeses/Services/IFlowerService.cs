using System.Collections.Generic;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerService : IService<Flower>
    {
        void Add(FlowerDTO flowerDTO);
        IReadOnlyList<Flower> GetSortByKind();
    }
}
