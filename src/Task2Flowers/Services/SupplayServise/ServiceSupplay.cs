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
    public class ServiceSupplay : Service<Supplay>, IServiceSupplay
    {
        public ServiceSupplay(Storage<Supplay> storage) : base(storage) { }

        public Supplay Add(SupplayDTO sDTO)
        {
            if (sDTO is null)
            {
                throw new ArgumentNullException(nameof(sDTO));
            }
            else
            {
                if (sDTO.Bundles is null)
                {
                    throw new ArgumentNullException(nameof(sDTO.Bundles));
                }
            }

            var newAP = new Supplay(_storage.IdGenerator.GetNextValue(), sDTO.Bundles, sDTO.FinishDate);
            this.Add(newAP);

            return newAP;
        }

        public Supplay AddEmpty()
        {
            var newAP = new Supplay(_storage.IdGenerator.GetNextValue());
            this.Add(newAP);

            return newAP;
        }

        // добавляем свертки и финишную дату по ид, только если до этого они не определены (до этого был использован AddEmpty)
        public Supplay AddWithoutId(int id, SupplayDTO sDTO)
        {
            var thisSupplay = _storage.Get(id);

            if (thisSupplay.GetBundles() is not null)
            {
                throw new ValidationException($"{thisSupplay.GetBundles()} is not null!");
            }
            else if (thisSupplay.GetFinishDate() is not null)
            {
                throw new ValidationException($"{thisSupplay.GetFinishDate()} is not null!");
            }
            else if (sDTO is null)
            {
                throw new ArgumentNullException(nameof(sDTO));
            }
            else
            {
                if (sDTO.Bundles is null)
                {
                    throw new ArgumentNullException(nameof(sDTO.Bundles));
                }
            }

            thisSupplay.Add(sDTO.Bundles);
            thisSupplay.Add(sDTO.FinishDate);

            return thisSupplay;
        }
    }
}


