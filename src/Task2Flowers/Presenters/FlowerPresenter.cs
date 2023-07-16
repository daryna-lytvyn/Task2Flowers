using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Presenters;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerPresenter : IPresenter<Flower>
    {
        IFlowerService _flowerServise;
        IFlowerKindService _flowerKindServise;
        IMyColorService _myColorService;

        public FlowerPresenter(IFlowerService flowerServise, IFlowerKindService flowerKindServise, IMyColorService myColorService)
        {
            _flowerServise = flowerServise ?? throw new ArgumentNullException(nameof(flowerServise));
            _flowerKindServise = flowerKindServise ?? throw new ArgumentNullException(nameof(flowerKindServise));
            _myColorService = myColorService ?? throw new ArgumentNullException(nameof(myColorService));
        }

        public void Input()
        {
            Console.WriteLine("Введите id вида цветка :  ");
            this.PrintFlowerKinds();
            var kingOfFlowerId = IntPresenter.InputId(_flowerKindServise.GetCurrentIdGeneratorValue());
            var choseFlowerKind = _flowerKindServise.Get(kingOfFlowerId);

            Console.WriteLine("Введите сорт цветка :  ");
            var variety = Console.ReadLine();

            Console.WriteLine("Введите id цвета :  ");
            this.PrintColors();
            var colorId = IntPresenter.InputId(_myColorService.GetCurrentIdGeneratorValue());
            var choseColor = _myColorService.Get(colorId);

            var aPDTO = new FlowerDTO
            {
                Kind = choseFlowerKind,
                Variety = variety,
                Color = choseColor
            };

            _flowerServise.Add(aPDTO);
        }

        public void Print()
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in _flowerServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, " +
                    $"{flower.Variety}, {flower.Color.Title}");
            }
        }

        public void PrintSortByKind()
        {
            foreach (var flower in _flowerServise.GetSortByKind())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, " +
                    $"{flower.Variety}, {flower.Color.Title}");
            }
        }

        private void PrintFlowerKinds()
        {
            foreach (var kind in this._flowerKindServise.GetAll())
            {
                Console.WriteLine($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }

        private void PrintColors()
        {
            foreach (var color in this._myColorService.GetAll())
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title}, " +
                    $"({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
