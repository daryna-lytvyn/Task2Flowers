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

        Storage<Bundle> _bundles;

        DateTime? _finishDate;

        public Supplay(int id)
        {
            this.Id = id;
        }

        public Supplay(int id, Storage<Bundle> bundles, DateTime date)
        {
            this.Id = id;
            _bundles = bundles;
            _finishDate = date;
        }

        public bool Add(Storage<Bundle> bundles)
        {
            if (_bundles == null)
            {
                _bundles = bundles;
                return true;
            }
            else
            {
                return false;
            }
        }
        
        public Storage<Bundle> GetBundles()
        {
            return _bundles;
        }

        public bool Add(DateTime date)
        {
            if (_finishDate == null)
            {
                _finishDate = date;
                return true;
            }
            else
            {
                return false;
            }
        }

        public DateTime? GetFinishDate()
        {
            return _finishDate;
        }

    }
}
