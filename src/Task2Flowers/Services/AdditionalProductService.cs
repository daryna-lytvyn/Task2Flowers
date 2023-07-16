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
    public class AdditionalProductService : Service<AdditionalProduct>, IAdditionalProductService
    {
        public AdditionalProductService(Storage<AdditionalProduct> storage) : base(storage) { }

        public void Add(AdditionalProductDTO additionalProductDTO)
        {
            base.Validation(additionalProductDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new AdditionalProduct(id, additionalProductDTO.Type, additionalProductDTO.Title,
                                                additionalProductDTO.Color, additionalProductDTO.Desctiption);
            this.Add(newAP);
        }

        public IReadOnlyList<AdditionalProduct> GetSortByType()
        {
            var sortAdditionalProductsByType = _storage.Elements.OrderBy(aP => aP.Type.Title).ToList();

            return sortAdditionalProductsByType.AsReadOnly();
        }
    }
}
