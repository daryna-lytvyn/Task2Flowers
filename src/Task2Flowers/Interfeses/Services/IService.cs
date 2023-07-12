using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses.Services
{
    public interface IService<T>
    {
        public void Add(T element);
        public T Get(int id);
        public IReadOnlyList<T> GetAll();
    }
}
