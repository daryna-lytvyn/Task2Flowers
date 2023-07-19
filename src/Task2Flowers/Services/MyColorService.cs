using Task2Flowers.Entities;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class MyColorService : Service<MyColor>, IMyColorService
    {
        public MyColorService(Storage<MyColor> storage) : base(storage) { }

        public void Add(MyColor myColor)
        {
            this.Add(myColor);
        }
    }
}
