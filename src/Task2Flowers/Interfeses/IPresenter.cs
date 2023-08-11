using System.Threading.Tasks;

namespace Task2Flowers.Interfeses
{
    public interface IPresenter<T>
    {
        Task InputAsync();
        Task PrintAsync();
    }
}
