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

        public IList<Bundle> Bundles { get; set; }

        public DateTime? FinishDate { get; set; }

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, IList<Bundle> bundles, DateTime date)
        {
            this.Id = id;
            this.Bundles = bundles;
            this.FinishDate = date;

        }

        public bool AddBundles(IList<Bundle> bundles)
        {
            if (this.Bundles == null)
            {
                this.Bundles = bundles;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AddFinishDate(DateTime date)
        {
            if (this.FinishDate == FinishDate)
            {
                this.FinishDate = date;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
