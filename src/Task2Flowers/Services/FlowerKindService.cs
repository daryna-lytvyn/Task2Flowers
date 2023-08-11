using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class FlowerKindService : Service<FlowerKind>, IFlowerKindService
    {
        public FlowerKindService(IStorage<FlowerKind> storage) : base(storage) { }

        public async Task AddAsync(FlowerKindDTO flowerKindDTO)
        {
            base.Validation(flowerKindDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAPType = new FlowerKind(id, flowerKindDTO.Title);

            await this.AddAsync(newAPType);
        }

    }
}
