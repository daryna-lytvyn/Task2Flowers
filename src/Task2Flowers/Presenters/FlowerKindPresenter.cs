using System;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class FlowerKindPresenter : IPresenter<FlowerKind>
    {
        private readonly IFlowerKindService _flowerKindServise;

        public FlowerKindPresenter(IFlowerKindService flowerKindServise)
        {
            this._flowerKindServise = flowerKindServise ?? throw new ArgumentNullException(nameof(flowerKindServise));
        }

        public async Task InputAsync()
        {
            Console.WriteLine("Введите название вида цветка :  ");
            var title = Console.ReadLine();
            var fKDTO = new FlowerKindDTO { Title = title };

            await _flowerKindServise.AddAsync(fKDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Виды цветов: ");

            var kinds = await _flowerKindServise.GetAllAsynс();
            foreach (var kind in kinds)
            {
                Console.WriteLine($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
