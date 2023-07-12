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
    public class ServiceFlower: Service<Flower>, IServiceFlower
    {
        public ServiceFlower(Storage<Flower> storage): base(storage) { }

        public Flower Add (FlowerDTO flowerDTO)
        {
            if (flowerDTO is null)
            {
                throw new ArgumentNullException(nameof(flowerDTO));
            }
            else
            {
                if (flowerDTO.Kind is null)
                {
                    throw new ArgumentNullException(nameof(flowerDTO.Kind));
                }
                if (flowerDTO.Variety is null)
                {
                    throw new ArgumentNullException(nameof(flowerDTO.Variety));
                }
            }

            var newFlower = new Flower(_storage.IdGenerator.GetNextValue(), flowerDTO.Kind, flowerDTO.Variety, flowerDTO.Color);
            this.Add(newFlower);

            return newFlower;
        }

        public IReadOnlyList<Flower> GetSortByKind()
        {
            var sortFlowerBundlesByFlower = _storage.Elements.OrderBy(f => f.Kind).ToList();

            return sortFlowerBundlesByFlower.AsReadOnly();
        }
    }

}
