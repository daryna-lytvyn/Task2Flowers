using Task2Flowers.DataTransferObdjects.Supplay;
using Task2Flowers.Entities.Supplay;

namespace Task2Flowers.Interfeses.Services.ISupplayService
{
    public interface ISupplayService : IService<Supplay>
    {
        void Add(SupplayDTO sDTO);
    }
}
