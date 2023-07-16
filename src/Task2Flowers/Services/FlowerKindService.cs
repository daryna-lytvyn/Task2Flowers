using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Services
{
    public class FlowerKindService: Service<FlowerKind>, IFlowerKindService
    {
        public FlowerKindService(Storage<FlowerKind> storage): base(storage) { }

        public void Add(FlowerKindDTO flowerKindDTO)
        {
            base.Validation(flowerKindDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAPType = new FlowerKind(id, flowerKindDTO.Title);
            this.Add(newAPType);
        }

    }
}
