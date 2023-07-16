using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class Supplay
    {
        public int Id { get; }

        private readonly IStorage<Bundle> _bundles;

        public DateTime? FinishDate { get; }

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, IStorage<Bundle> bundles, DateTime date)
        {
            this.Id = id;
            _bundles = bundles;
            FinishDate = date;
        }

        public IStorage<Bundle> GetBundles()
        {
            return _bundles;
        }
    }
}
