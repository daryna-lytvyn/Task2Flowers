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
    public class ServiceFlowerKind: Service<FlowerKind>, IServiceFlowerKind
    {
        public ServiceFlowerKind(Storage<FlowerKind> storage): base(storage) { }

        public FlowerKind Add(FlowerKindDTO fKDTO)
        {
            if (fKDTO == null)
            {
                throw new ArgumentNullException(nameof(fKDTO));
            }
            if (fKDTO.Title == null)
            {
                throw new ArgumentNullException(nameof(fKDTO.Title));
            }

            var newAPType = new FlowerKind(_storage.IdGenerator.GetNextValue(), fKDTO.Title);
            this.Add(newAPType);

            return newAPType;
        }
    }
}
