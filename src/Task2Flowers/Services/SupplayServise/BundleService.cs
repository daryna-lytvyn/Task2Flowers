using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Services
{
    public class BundleService : Service<Bundle>, IBundleService
    {
        public BundleService(IStorage<Bundle> storage): base(storage) { }

        public void Add(BundleDTO bundle)
        {
            base.Validation(bundle);

            var id = _storage.IdGenerator().GetNextValue();
            var newB = new Bundle(id, bundle.Product, bundle.Count);
            this.Add(newB);
        }
    }
}
