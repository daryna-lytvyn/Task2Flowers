using System;
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

        public void Input()
        {
            Console.WriteLine("Введите название вида цветка :  ");
            var title = Console.ReadLine();
            var fKDTO = new FlowerKindDTO { Title = title };

            _flowerKindServise.Add(fKDTO);
        }

        public void Print()
        {
            Console.WriteLine("Виды цветов: ");

            foreach (var kind in this._flowerKindServise.GetAll())
            {
                Console.WriteLine($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
