using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Services
{
    public class ServiceBundle : Service<Bundle>, IServiceBundle
    {
        public ServiceBundle(Storage<Bundle> storage): base(storage) { }

        public Bundle Add(BundleDTO bDTO)
        {
            if (bDTO == null)
            {
                throw new ArgumentNullException(nameof(bDTO));
            }
            else
            {
                if (bDTO.Product == null)
                {
                    throw new ArgumentNullException(nameof(bDTO.Product));
                }
            }

            var newB = new Bundle(_storage.IdGenerator.GetNextValue(), bDTO.SupplayId, bDTO.Product, bDTO.Count);
            this.Add(newB);

            return newB;
        }
    }
}
