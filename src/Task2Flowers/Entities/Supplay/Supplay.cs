using System;
using System.Collections.Generic;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Entities.Supplay
{
    public class Supplay : Entity
    {

        public IReadOnlyCollection<Bundle> Bundles { get; }

        public DateTime? FinishDate { get; }

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, IReadOnlyCollection<Bundle> bundles, DateTime date)
        {
            this.Id = id;
            this.Bundles = bundles;
            this.FinishDate = date;
        }

    }
}
