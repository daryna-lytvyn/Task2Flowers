using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerPackageService : Service<FlowerPackage>, IFlowerPackageService
    {
        public FlowerPackageService(IStorage<FlowerPackage> storage) : base(storage) { }

        public async Task AddAsync(FlowerPackageDTO flowerPackageDTO)
        {
            base.Validation(flowerPackageDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAP = new FlowerPackage(id, flowerPackageDTO.Type, flowerPackageDTO.Width,
                                            flowerPackageDTO.Height, flowerPackageDTO.Color, flowerPackageDTO.Desctiption);

            await this.AddAsync(newAP);
        }

        public async Task<IReadOnlyList<FlowerPackage>> GetSortByTypeAsync()
        {
            var elements = await _storage.GetAllAsynс();
            var sortFlowerPackagesByType = elements.OrderBy(fP => fP.Type.Id).ToList();

            return sortFlowerPackagesByType.AsReadOnly();
        }
    }
}
