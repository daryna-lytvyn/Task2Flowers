using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class AdditionalProductService : Service<AdditionalProduct>, IAdditionalProductService
    {
        public AdditionalProductService(IStorage<AdditionalProduct> storage) : base(storage) { }

        public async Task AddAsync(AdditionalProductDTO additionalProductDTO)
        {
            base.Validation(additionalProductDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAP = new AdditionalProduct(id, additionalProductDTO.Type, additionalProductDTO.Title,
                                                additionalProductDTO.Color, additionalProductDTO.Description);
            await this.AddAsync(newAP);
        }

        public async Task<IReadOnlyList<AdditionalProduct>> GetSortByTypeAsync()
        {
            var elements = await _storage.GetAllAsynс();
            var sortAdditionalProductsByType = elements.OrderBy(aP => aP.Type.Id).ToList();

            return sortAdditionalProductsByType.AsReadOnly();
        }
    }
}
