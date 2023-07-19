using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerPackageTypeService : IService<FlowerPackageType>
    {
        void Add(FlowerPackageTypeDTO fPTDTO);
    }
}
