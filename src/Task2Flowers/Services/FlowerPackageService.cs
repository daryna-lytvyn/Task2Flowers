using System.Collections.Generic;
using System.Linq;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Storages;

namespace Task2Flowers.Services
{
    public class FlowerPackageService : Service<FlowerPackage>, IFlowerPackageService
    {
        public FlowerPackageService(Storage<FlowerPackage> storage) : base(storage) { }

        public void Add(FlowerPackageDTO flowerPackageDTO)
        {
            base.Validation(flowerPackageDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new FlowerPackage(id, flowerPackageDTO.Type, flowerPackageDTO.Width,
                                            flowerPackageDTO.Height, flowerPackageDTO.Color, flowerPackageDTO.Desctiption);

            this.Add(newAP);
        }

        public IReadOnlyList<FlowerPackage> GetSortByType()
        {
            var sortFlowerPackagesByType = _storage.Elements.OrderBy(fP => fP.Type.Title).ToList();

            return sortFlowerPackagesByType.AsReadOnly();
        }
    }
}
