using System.Collections.Generic;
using System.Linq;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerService : Service<Flower>, IFlowerService
    {
        public FlowerService(IStorage<Flower> storage) : base(storage) { }

        public void Add(FlowerDTO flowerDTO)
        {
            base.Validation(flowerDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newFlower = new Flower(id, flowerDTO.Kind, flowerDTO.Variety, flowerDTO.Color);
            this.Add(newFlower);
        }

        public IReadOnlyList<Flower> GetSortByKind()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(f => f.Kind.Id).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }

}
