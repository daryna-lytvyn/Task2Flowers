using System;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class FlowerPresenter : IPresenter<Flower>
    {
        private readonly IFlowerService _flowerServise;
        private readonly IFlowerKindService _flowerKindServise;
        private readonly IMyColorService _myColorService;

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
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
            }
        }

        public void PrintSortByKind()
        {
            foreach (var flower in _flowerServise.GetSortByKind())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
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
                Console.WriteLine($"Id: {color.Title}, ({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
