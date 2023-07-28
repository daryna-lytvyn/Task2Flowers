using Task2Flowers.DataTransferObdjects.Supplay;
using Task2Flowers.Entities.Supplay;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services.ISupplayService;

namespace Task2Flowers.Services.SupplayServise
{
    public class SupplayService : Service<Supplay>, ISupplayService
    {
        public SupplayService(IStorage<Supplay> storage) : base(storage) { }

        public void Add(SupplayDTO supplayDTO)
        {
            base.Validation(supplayDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new Supplay(id, supplayDTO.Bundles, supplayDTO.FinishDate);
            this.Add(newAP);
        }
    }
}


