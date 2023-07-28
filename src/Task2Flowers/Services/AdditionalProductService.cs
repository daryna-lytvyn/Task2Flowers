﻿using System.Collections.Generic;
using System.Linq;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class AdditionalProductService : Service<AdditionalProduct>, IAdditionalProductService
    {
        public AdditionalProductService(IStorage<AdditionalProduct> storage) : base(storage) { }

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
            var sortAdditionalProductsByType = _storage.Elements.OrderBy(aP => aP.Type.Id).ToList();

            return sortAdditionalProductsByType.AsReadOnly();
        }
    }
}
