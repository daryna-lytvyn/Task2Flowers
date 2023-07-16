using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerKindPresenter
    {
        IFlowerKindService _flowerKindServise; 

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
