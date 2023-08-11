using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerService : Service<Flower>, IFlowerService
    {
        public FlowerService(IStorage<Flower> storage) : base(storage) { }

        public async Task AddAsync(FlowerDTO flowerDTO)
        {
            base.Validation(flowerDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newFlower = new Flower(id, flowerDTO.Kind, flowerDTO.Variety, flowerDTO.Color);
            await this.AddAsync(newFlower);
        }

        public async Task<IReadOnlyList<Flower>> GetSortByKindAsync()
        {
            var elements = await _storage.GetAllAsynс();
            var sortFlowerBundlesByFlower = elements.OrderBy(f => f.Kind.Id).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }

}
