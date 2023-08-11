using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.Generators;

namespace Task2Flowers.Interfeses
{
    public interface IStorage<T>
    {
        Task CopyFileAsync(string filename);

        Task<IReadOnlyCollection<T>> GetAllAsynс();
        Task AddAsynс(T element);
        Task<T> GetAsynс(int id);
        Task<IntIdGenerator> IdGenerator();
    }
}
