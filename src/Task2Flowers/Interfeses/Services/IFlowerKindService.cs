using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerKindService : IService<FlowerKind>
    {
        void Add(FlowerKindDTO fKDTO);
    }
}
