using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.Json.Serialization;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Entities.Supplay
{
    public class Supplay : Entity
    {
        public List<Bundle> Bundles { get; }
        
        public DateTime FinishDate { get; }


        public Supplay(int id)
        {
            this.Id = id;
        }

        
        /*public Supplay(int id, IReadOnlyCollection<Bundle> bundles, DateTime finishDate)
        {
            this.Id = id;
            this.Bundles = bundles;
            this.FinishDate = finishDate;
        }*/

        [JsonConstructor]
        public Supplay(int id, List<Bundle> bundles, DateTime finishDate)
        {
            this.Id = id;
            this.Bundles = bundles;
            this.FinishDate = finishDate;
        }
    }
}
