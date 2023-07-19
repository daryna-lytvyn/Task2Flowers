using System;
using System.Collections.ObjectModel;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Entities.Supplay
{
    public class Supplay
    {
        public int Id { get; }

        private readonly ReadOnlyCollection<Bundle> _bundles;

        public DateTime? FinishDate { get; }

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, ReadOnlyCollection<Bundle> bundles, DateTime date)
        {
            this.Id = id;
            _bundles = bundles;
            FinishDate = date;
        }

        public ReadOnlyCollection<Bundle> GetBundles()
        {
            return _bundles;
        }
    }
}
