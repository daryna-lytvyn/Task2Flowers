using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public interface IStorage <T>
    {

        IReadOnlyCollection<T> Elements { get; }
        void Add(T element);
        IReadOnlyCollection<T> GetAll();
        T Get(int id);
        IntIdGenerator IdGenerator();
    }
}
