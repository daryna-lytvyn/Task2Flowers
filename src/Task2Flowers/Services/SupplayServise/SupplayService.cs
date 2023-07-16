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
    public class SupplayService : Service<Supplay>, ISupplayService
    {
        public SupplayService(Storage<Supplay> storage) : base(storage) { }

        public void Add(SupplayDTO supplayDTO)
        {
            base.Validation(supplayDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new Supplay(id, supplayDTO.Bundles, supplayDTO.FinishDate);
            this.Add(newAP);
        }
    }
}


