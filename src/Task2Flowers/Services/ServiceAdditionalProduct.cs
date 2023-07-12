using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Task2Flowers.Generators;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Services
{
    public class ServiceAdditionalProduct : Service<AdditionalProduct>, IServiceAdditionalProduct
    {
        public ServiceAdditionalProduct(Storage<AdditionalProduct> storage) : base(storage) { }

        public AdditionalProduct Add(AdditionalProductDTO aPDTO)
        {
            if (aPDTO is null)
            {
                throw new ArgumentNullException(nameof(aPDTO));
            }
            else
            {
                if (aPDTO.Type is null)
                {
                    throw new ArgumentNullException(nameof(aPDTO.Type));
                }
                if (aPDTO.Title is null)
                {
                    throw new ArgumentNullException(nameof(aPDTO.Title));
                }
                if (aPDTO.Desctiption is null)
                {
                    throw new ArgumentNullException(nameof(aPDTO.Desctiption));
                }
            }

            var newAP = new AdditionalProduct(_storage.IdGenerator.GetNextValue(), aPDTO.Type, aPDTO.Title, aPDTO.Color, aPDTO.Desctiption);
            this.Add(newAP);

            return newAP;
        }

        public IReadOnlyList<AdditionalProduct> GetSortByType()
        {
            var sortAdditionalProductsByType = _storage.Elements.OrderBy(aP => aP.Type.Title).ToList();

            return sortAdditionalProductsByType.AsReadOnly();
        }
    }
}
