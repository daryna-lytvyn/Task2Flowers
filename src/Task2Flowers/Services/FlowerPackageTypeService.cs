using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerPackageTypeService : Service<FlowerPackageType>, IFlowerPackageTypeService
    {
        public FlowerPackageTypeService(IStorage<FlowerPackageType> storage) : base(storage) { }

        public async Task AddAsync(FlowerPackageTypeDTO flowerPackageTypeDTO)
        {
            base.Validation(flowerPackageTypeDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAPType = new FlowerPackageType(id, flowerPackageTypeDTO.Title);
            await this.AddAsync(newAPType);
        }
    }
}
