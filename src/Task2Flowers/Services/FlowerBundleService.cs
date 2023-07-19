using System.Collections.Generic;
using System.Linq;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Storages;

namespace Task2Flowers.Services
{
    public class FlowerBundleService : Service<FlowerBundle>, IFlowerBundleService
    {
        public FlowerBundleService(Storage<FlowerBundle> storage) : base(storage) { }

        public void Add(FlowerBundleDTO flowerBundleDTO)
        {
            base.Validation(flowerBundleDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newFB = new FlowerBundle(id, flowerBundleDTO.Flower, flowerBundleDTO.CountOfFlower, flowerBundleDTO.Height);
            this.Add(newFB);
        }

        public IReadOnlyList<FlowerBundle> GetSortByFlower()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(fB => fB.Flower).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }

        public IReadOnlyList<FlowerBundle> GetSortByKindOfFlower()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(fB => fB.Flower.Kind.Title).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }
}
