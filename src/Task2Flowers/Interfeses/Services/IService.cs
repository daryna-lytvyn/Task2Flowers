using System.Collections.Generic;

namespace Task2Flowers.Interfeses.Services
{
    public interface IService<T>
    {
        void Add(T element);
        T Get(int id);
        IReadOnlyCollection<T> GetAll();
        int GetCurrentIdGeneratorValue();
    }
}
