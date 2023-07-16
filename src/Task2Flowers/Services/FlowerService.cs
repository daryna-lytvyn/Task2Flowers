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
    public class FlowerService: Service<Flower>, IFlowerService
    {
        public FlowerService(Storage<Flower> storage): base(storage) { }

        public void Add (FlowerDTO flowerDTO)
        {
            base.Validation(flowerDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newFlower = new Flower(id , flowerDTO.Kind, flowerDTO.Variety, flowerDTO.Color);
            this.Add(newFlower);
        }

        public IReadOnlyList<Flower> GetSortByKind()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(f => f.Kind).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }

}
