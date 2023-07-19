using System.Collections.Generic;
using Task2Flowers.Generators;

namespace Task2Flowers.Interfeses
{
    public interface IStorage<T>
    {

        IReadOnlyCollection<T> Elements { get; }
        void Add(T element);
        IReadOnlyCollection<T> GetAll();
        T Get(int id);
        IntIdGenerator IdGenerator();
    }
}
