using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public  class Storage<T>
    {
        public List<T> Elements { get; }

        public IntIdGenerator IdGenerator { get; }

        public Storage  ()
        { 
            this.Elements = new List<T>(); 
        
        }
       
        public Storage ( List<T> elements, IntIdGenerator idGenerator)
        {
            this.Elements = elements;
            this.IdGenerator = idGenerator;

        }

  
        public void Add (T element)
        {
            this.Elements.Add(element);
        }

       /* public void AddPackageToSupplayById (Package package, int id)
        {
            var neededId = this.Supplays.FindIndex(x => x.Id == id);
            this.Supplays[neededId].FlowerPackeges.Add(package);

        }*/
    }
}
