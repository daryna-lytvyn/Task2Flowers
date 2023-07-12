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
    public class ServiceAdditionalProductType: Service<AdditionalProductType>, IServiceAdditionalProductType
    {
        public ServiceAdditionalProductType(Storage<AdditionalProductType> storage) : base(storage) { }

        public AdditionalProductType Add(AdditionalProductTypeDTO aPTDTO)
        {
            if (aPTDTO is null)
            {
                throw new ArgumentNullException(nameof(aPTDTO));
            }
            if (aPTDTO.Title is null)
            {
                throw new ArgumentNullException(nameof(aPTDTO.Title));
            }

            var newAPType = new AdditionalProductType(_storage.IdGenerator.GetNextValue(), aPTDTO.Title);
            this.Add(newAPType);

            return newAPType;
        }
    }
}
