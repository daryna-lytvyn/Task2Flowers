using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public abstract class Service<T>: IService<T>
    {
        protected readonly Storage<T> _storage;

        public Service(Storage<T> storage)
        {
            _storage = storage ?? throw new ArgumentNullException(nameof(storage));
        }

        public  void Add(T element)
        {
            if (element is null)
            {
                throw new ArgumentNullException(nameof(element));
            }
            _storage.Add(element);
        }

        public T Get(int id)
        {
            if (id <= _storage.Elements.Count || id < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(id));
            }
            return _storage.Elements[id];
        }

        public IReadOnlyList<T> GetAll()
        {
            return _storage.Elements;
        }
    }
}
