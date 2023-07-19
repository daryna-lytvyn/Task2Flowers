using Task2Flowers.Entities;

namespace Task2Flowers.Interfeses.Services
{
    public interface IMyColorService : IService<MyColor>
    {
        void Add(MyColor myColor);
    }
}
