using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Storages;

namespace Task2Flowers.Services
{
    public class FlowerKindService : Service<FlowerKind>, IFlowerKindService
    {
        public FlowerKindService(Storage<FlowerKind> storage) : base(storage) { }

        public void Add(FlowerKindDTO flowerKindDTO)
        {
            base.Validation(flowerKindDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new FlowerKind(id, flowerKindDTO.Title);
            this.Add(newAPType);
        }

    }
}
