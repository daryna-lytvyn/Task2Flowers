using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{

    public class Storage<T>
    {
        private readonly List<T> _elements = new List<T>();
        public IReadOnlyList<T> Elements => _elements.AsReadOnly(); 


        public IntIdGenerator IdGenerator { get; }


        public Storage()
        {
            this._elements = new List<T>();

        }
        public Storage(List<T> elements, IntIdGenerator idGenerator)
        {
            this._elements = elements;
            this.IdGenerator = idGenerator;
        }


        public void Add(T element)
        {
            this._elements.Add(element);
        }




        /* public void AddPackageToSupplayById (Package package, int id)
         {
             var neededId = this.Supplays.FindIndex(x => x.Id == id);
             this.Supplays[neededId].FlowerPackeges.Add(package);

         }*/
    }
}
