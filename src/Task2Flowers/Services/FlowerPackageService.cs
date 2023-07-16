using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Services
{
    public class FlowerPackageService: Service<FlowerPackage>, IFlowerPackageService
    {
        public FlowerPackageService(Storage<FlowerPackage> storage): base(storage) { }

        public void Add(FlowerPackageDTO flowerPackageDTO)
        {
            base.Validation(flowerPackageDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new FlowerPackage(id, flowerPackageDTO.Type,  flowerPackageDTO.Width, 
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
