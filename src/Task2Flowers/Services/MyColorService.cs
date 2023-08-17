using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class MyColorService : Service<MyColor>, IMyColorService
    {
        public MyColorService(IStorage<MyColor> storage) : base(storage) { }

        public async Task AddAsync(MyColorDTO myColorDTO)
        {
            base.Validation(myColorDTO);

            var idGenerator = await _storage.IdGenerator();

            var id = idGenerator.GetNextValue();
            var newMyColor = new MyColor(id, myColorDTO.Title, myColorDTO.R, myColorDTO.G, myColorDTO.B);
            await this.AddAsync(newMyColor);
        }
    }
}
