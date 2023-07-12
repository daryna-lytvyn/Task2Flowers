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
    public class ServiceFlowerPackage: Service<FlowerPackage>, IServiceFlowerPackage
    {
        public ServiceFlowerPackage(Storage<FlowerPackage> storage): base(storage) { }

        public FlowerPackage Add(FlowerPackageDTO fPDTO)
        {
            if (fPDTO is null)
            {
                throw new ArgumentNullException(nameof(fPDTO));
            }
            else
            {
                if (fPDTO.Type is null)
                {
                    throw new ArgumentNullException(nameof(fPDTO.Type));
                }
                if (fPDTO.Desctiption is null)
                {
                    throw new ArgumentNullException(nameof(fPDTO.Desctiption));
                }
            }

            var newAP = new FlowerPackage(_storage.IdGenerator.GetNextValue(), fPDTO.Type, 
                                            fPDTO.Width, fPDTO.Height, fPDTO.Color, fPDTO.Desctiption);

            this.Add(newAP);

            return newAP;
        }

        public IReadOnlyList<FlowerPackage> GetSortByType()
        {
            var sortFlowerPackagesByType = _storage.Elements.OrderBy(fP => fP.Type.Title).ToList();

            return sortFlowerPackagesByType.AsReadOnly();
        }
    }
}
