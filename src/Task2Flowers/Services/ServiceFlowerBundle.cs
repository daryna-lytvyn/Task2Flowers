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
    public class ServiceFlowerBundle: Service<FlowerBundle>, IServiceFlowerBundle
    {
        public ServiceFlowerBundle(Storage<FlowerBundle> storage): base(storage) { }

        public FlowerBundle Add(FlowerBundleDTO fBDTO)
        {
            if (fBDTO == null)
            {
                throw new ArgumentNullException(nameof(fBDTO));
            }
            else
            {
                if (fBDTO.Flower == null)
                {
                    throw new ArgumentNullException(nameof(fBDTO.Flower));
                }
            }

            var newFB = new FlowerBundle(_storage.IdGenerator.GetNextValue(), fBDTO.Flower, fBDTO.CountOfFlower, fBDTO.Height);
            this.Add(newFB);

            return newFB;
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
