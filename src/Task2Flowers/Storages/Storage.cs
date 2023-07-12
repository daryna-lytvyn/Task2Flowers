using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{

    public class Storage<T>: IStorage<T>
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
            _elements = elements;
            this.IdGenerator = idGenerator;
        }


        public void Add(T element)
        {
            _elements.Add(element);
        }

        public T Get(int id)
        {
            return  _elements.ElementAt(id);
        }


        /* public void AddPackageToSupplayById (FlowerPakege package, int id)
         {
             var neededId = this.Supplays.FindIndex(x => x.Id == id);
             this.Supplays[neededId].FlowerPackeges.Add(package);

         }*/
    }
}
