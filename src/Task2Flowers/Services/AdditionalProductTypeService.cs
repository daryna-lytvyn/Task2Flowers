using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Storages;

namespace Task2Flowers.Services
{
    public class AdditionalProductTypeService : Service<AdditionalProductType>, IAdditionalProductTypeService
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
