using System.Collections.Generic;
using System.Linq;
using Task2Flowers.Entities;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Storages
{

    public class Storage<T> 
        where T : Entity
    {
        private readonly List<T> _elements = new List<T>();
        public IReadOnlyCollection<T> Elements => _elements.AsReadOnly();

        private readonly IntIdGenerator _idGenerator;

        public Storage(IntIdGenerator idGenerator)
        {
            _elements = new List<T>();
            _idGenerator = idGenerator;
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return _elements.AsReadOnly();
        }


        public void Add(T element)
        {
            _elements.Add(element);
        }

        public T Get(int id)
        {
            return _elements.Find(element => element.Id == id);
        }

        public IntIdGenerator IdGenerator()
        {
            return _idGenerator;
        }
        /* public void AddPackageToSupplayById (FlowerPakege package, int id)
         {
             var neededId = this.Supplays.FindIndex(x => x.Id == id);
             this.Supplays[neededId].FlowerPackeges.Add(package);

         }*/
    }
}
