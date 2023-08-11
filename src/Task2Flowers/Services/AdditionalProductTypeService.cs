using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class AdditionalProductTypeService : Service<AdditionalProductType>, IAdditionalProductTypeService
    {
        public AdditionalProductTypeService(IStorage<AdditionalProductType> storage) : base(storage) { }

        public async Task AddAsync(AdditionalProductTypeDTO additionalProductTypeDTO)
        {
            base.Validation(additionalProductTypeDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAPType = new AdditionalProductType(id, additionalProductTypeDTO.Title);
            await this.AddAsync(newAPType);
        }
    }
}
