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
    public class ServiceFlowerPackageType: Service<FlowerPackageType>, IServiceFlowerPackageType
    {
        public ServiceFlowerPackageType(Storage<FlowerPackageType> storage): base(storage) { }

        public FlowerPackageType Add(FlowerPackageTypeDTO fPTDTO)
        {
            if (fPTDTO is null)
            {
                throw new ArgumentNullException(nameof(fPTDTO));
            }
            if (fPTDTO.Title is null)
            {
                throw new ArgumentNullException(nameof(fPTDTO.Title));
            }

            var newAPType = new FlowerPackageType(_storage.IdGenerator.GetNextValue(), fPTDTO.Title);
            this.Add(newAPType);

            return newAPType;
        }
    }
}
