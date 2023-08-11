using System;
using System.Threading.Tasks;
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

        public async Task InputAsync()
        {
            Console.WriteLine("Введите id вида упаковки :  ");
            await this.PrintFlowerPackageTypesAsync();

            var currentIdGeneratorValueFlowerPackageType = await _flowerPackageTypeServise.GetCurrentIdGeneratorValueAsync();
            var flowerPackageTypeId = IntPresenter.InputId(currentIdGeneratorValueFlowerPackageType);
            var chosenFlowerPackageType =  await _flowerPackageTypeServise.GetAsynс(flowerPackageTypeId);

            Console.WriteLine("Введите название упаковки :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите высоту :  ");
            var height = IntPresenter.Input(0, 500);

            Console.WriteLine("Введите длинну/диаметр/ширину :  ");
            var width = IntPresenter.Input(0, 500);

            Console.WriteLine("Введите id цвета :  ");
            await this.PrintColorsAsync();

            var currentIdGeneratorValueColor = await _myColorService.GetCurrentIdGeneratorValueAsync();
            var colorId = IntPresenter.InputId(currentIdGeneratorValueColor); 
            var choseColor = await _myColorService.GetAsynс(colorId);

            Console.WriteLine("Введите описание упаковки :  ");
            var description = Console.ReadLine();

            var fPDTO = new FlowerPackageDTO
            {
                Type = chosenFlowerPackageType,
                Height = height,
                Width = width,
                Color = choseColor,
                Desctiption = description
            };

            await _flowerPackageServise.AddAsync(fPDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Упаковки: ");
            
            var flowerPackages = await _flowerPackageServise.GetAllAsynс();
            foreach (var flowerPackage in flowerPackages)
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title}, {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        public async Task PrintSortByTypeAsync()
        {
            var sortByType = await _flowerPackageServise.GetSortByTypeAsync();
            foreach (var flowerPackage in sortByType)
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title},  {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        private async Task PrintFlowerPackageTypesAsync()
        {
            var flowerPackageTypes = await _flowerPackageTypeServise.GetAllAsynс();
            foreach (var flowerPackageType in flowerPackageTypes)
            {
                Console.WriteLine($"Id: {flowerPackageType.Id}, {flowerPackageType.Title}, ");
            }

            Console.WriteLine();
        }

        private async Task PrintColorsAsync()
        {
            var colors = await _myColorService.GetAllAsynс();
            foreach (var color in colors)
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
