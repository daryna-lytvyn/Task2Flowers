using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Storages;

namespace Task2Flowers.Services
{
    public class FlowerPackageTypeService : Service<FlowerPackageType>, IFlowerPackageTypeService
    {
        public FlowerPackageTypeService(Storage<FlowerPackageType> storage) : base(storage) { }

        public void Add(FlowerPackageTypeDTO flowerPackageTypeDTO)
        {
            base.Validation(flowerPackageTypeDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new FlowerPackageType(id, flowerPackageTypeDTO.Title);
            this.Add(newAPType);
        }
    }
}
