using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects.Supplay;
using Task2Flowers.Entities.Supplay;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services.ISupplayService;

namespace Task2Flowers.Services.SupplayServise
{
    public class SupplayService : Service<Supplay>, ISupplayService
    {
        public SupplayService(IStorage<Supplay> storage) : base(storage) { }

        public async Task AddAsync(SupplayDTO supplayDTO)
        {
            base.Validation(supplayDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newAP = new Supplay(id, supplayDTO.Bundles, supplayDTO.FinishDate);
            await this.AddAsync(newAP);
        }

    }
}


