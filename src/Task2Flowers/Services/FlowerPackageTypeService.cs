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
    public class FlowerPackageTypeService: Service<FlowerPackageType>, IFlowerPackageTypeService
    {
        public FlowerPackageTypeService(Storage<FlowerPackageType> storage): base(storage) { }

        public void Add(FlowerPackageTypeDTO flowerPackageTypeDTO)
        {
            base.Validation(flowerPackageTypeDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new FlowerPackageType(id, flowerPackageTypeDTO.Title);
            this.Add(newAPType);
        }
    }
}
