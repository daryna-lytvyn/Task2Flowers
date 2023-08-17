using System.Collections.Generic;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses.Services
{
    public interface IService<T>
    {
        Task AddAsync(T element);
        Task<T> GetAsynс(int id);
        Task<IReadOnlyCollection<T>> GetAllAsynс();
        Task<int> GetCurrentIdGeneratorValueAsync();
    }
}
