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
    public class AdditionalProductTypeService: Service<AdditionalProductType>, IAdditionalProductTypeService
    {
        public AdditionalProductTypeService(Storage<AdditionalProductType> storage) : base(storage) { }

        public void Add(AdditionalProductTypeDTO additionalProductTypeDTO)
        {
            base.Validation(additionalProductTypeDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new AdditionalProductType(id, additionalProductTypeDTO.Title);
            this.Add(newAPType);
        }
    }
}
