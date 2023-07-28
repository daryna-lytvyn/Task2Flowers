using System;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class FlowerPackagePresenter : IPresenter<FlowerPackage>
    {
        private readonly IFlowerPackageService _flowerPackageServise;
        private readonly IFlowerPackageTypeService _flowerPackageTypeServise;
        private readonly IMyColorService _myColorService;

        public FlowerPackagePresenter(IFlowerPackageService flowerPackageServise, IFlowerPackageTypeService flowerPackageTypeServise,
                                        IMyColorService myColorService)
        {
            _flowerPackageServise = flowerPackageServise ?? throw new ArgumentNullException(nameof(flowerPackageServise));
            _flowerPackageTypeServise = flowerPackageTypeServise ?? throw new ArgumentNullException(nameof(flowerPackageTypeServise));
            _myColorService = myColorService ?? throw new ArgumentNullException(nameof(myColorService));
        }

        public void Input()
        {
            Console.WriteLine("Введите id вида упаковки :  ");

            this.PrintFlowerPackageTypes();

            var flowerPackageTypeId = IntPresenter.InputId(_flowerPackageTypeServise.GetCurrentIdGeneratorValue());
            var chosenFPT = _flowerPackageTypeServise.Get(flowerPackageTypeId);

            Console.WriteLine("Введите название упаковки :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите высоту :  ");
            var height = IntPresenter.Input(0, 500);

            Console.WriteLine("Введите длинну/диаметр/ширину :  ");
            var width = IntPresenter.Input(0, 500);

            Console.WriteLine("Введите id цвета :  ");
            this.PrintColors();
            var colorId = IntPresenter.InputId(_myColorService.GetCurrentIdGeneratorValue());
            var choseColor = _myColorService.Get(colorId);

            Console.WriteLine("Введите описание упаковки :  ");
            var description = Console.ReadLine();

            var fPDTO = new FlowerPackageDTO
            {
                Type = chosenFPT,
                Height = height,
                Width = width,
                Color = choseColor,
                Desctiption = description
            };

            _flowerPackageServise.Add(fPDTO);
        }

        public void Print()
        {
            Console.WriteLine("Упаковки: ");

            foreach (var flowerPackage in _flowerPackageServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title}, {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        public void PrintSortByType()
        {

            foreach (var flowerPackage in _flowerPackageServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title},  {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        private void PrintFlowerPackageTypes()
        {
            foreach (var flowerPackageType in _flowerPackageTypeServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerPackageType.Id}, {flowerPackageType.Title}, ");
            }

            Console.WriteLine();
        }

        private void PrintColors()
        {
            foreach (var color in this._myColorService.GetAll())
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
