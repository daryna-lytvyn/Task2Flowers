using System.Collections.Generic;
using System.Linq;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerBundleService : Service<FlowerBundle>, IFlowerBundleService
    {
        public FlowerBundleService(IStorage<FlowerBundle> storage) : base(storage) { }

        public void Add(FlowerBundleDTO flowerBundleDTO)
        {
            base.Validation(flowerBundleDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newFB = new FlowerBundle(id, flowerBundleDTO.Flower, flowerBundleDTO.CountOfFlower, flowerBundleDTO.Height);
            this.Add(newFB);
        }

        public IReadOnlyList<FlowerBundle> GetSortByFlower()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(fB => fB.Flower.Kind.Id)
                                                             .ThenBy(fB => fB.Flower.Id)
                                                             .ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }

        public IReadOnlyList<FlowerBundle> GetSortByKindOfFlower()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(fB => fB.Flower.Kind.Title).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }
}
