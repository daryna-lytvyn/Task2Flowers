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
    public class FlowerPackagePresenter : IPresenter<FlowerPackage>
    {
        IFlowerPackageService _flowerPackageServise;
        IFlowerPackageTypeService _flowerPackageTypeServise;
        IMyColorService _myColorService;

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
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, " +
                    $"{flowerPackage.Height} на {flowerPackage.Width}, " +
                    $"{flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        public void PrintSortByType()
        {
            
            foreach (var flowerPackage in _flowerPackageServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title},  " +
                    $"{flowerPackage.Height} на {flowerPackage.Width}, " +
                    $"{flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
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
