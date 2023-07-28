using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerPackageTypeService : Service<FlowerPackageType>, IFlowerPackageTypeService
    {
        public FlowerPackageTypeService(IStorage<FlowerPackageType> storage) : base(storage) { }

        public void Add(FlowerPackageTypeDTO flowerPackageTypeDTO)
        {
            base.Validation(flowerPackageTypeDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new FlowerPackageType(id, flowerPackageTypeDTO.Title);
            this.Add(newAPType);
        }
    }
}
