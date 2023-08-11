using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerBundleService : Service<FlowerBundle>, IFlowerBundleService
    {
        public FlowerBundleService(IStorage<FlowerBundle> storage) : base(storage) { }

        public async Task AddAsync(FlowerBundleDTO flowerBundleDTO)
        {
            base.Validation(flowerBundleDTO);
            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newFB = new FlowerBundle(id, flowerBundleDTO.Flower, flowerBundleDTO.CountOfFlower, flowerBundleDTO.Height);
            
            this.AddAsync(newFB);
        }

        public async Task<IReadOnlyList<FlowerBundle>> GetSortByFlowerAsync()
        {
            var elements = await _storage.GetAllAsynс();
            var sortFlowerBundlesByFlower = elements.OrderBy(fB => fB.Flower.Kind.Id)
                                                             .ThenBy(fB => fB.Flower.Id)
                                                             .ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }

        public async Task<IReadOnlyList<FlowerBundle>> GetSortByKindOfFlowerAsync()
        {
            var elements = await _storage.GetAllAsynс();
            var sortFlowerBundlesByFlower =elements.OrderBy(fB => fB.Flower.Kind.Title).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }
}
