using System;
using System.Threading.Tasks;
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

        public async Task InputAsync()
        {
            Console.WriteLine("Введите id вида цветка :  ");
            await this.PrintFlowerKindsAsync();

            var currentIdGeneratorValueFlowerKind = await _flowerKindServise.GetCurrentIdGeneratorValueAsync();
            var flowerKindId = IntPresenter.InputId(currentIdGeneratorValueFlowerKind);
            var choseFlowerKind = await _flowerKindServise.GetAsynс(flowerKindId);

            Console.WriteLine("Введите сорт цветка :  ");
            var variety = Console.ReadLine();

            Console.WriteLine("Введите id цвета :  ");
            await this.PrintColorsAsync();
            
            var currentIdGeneratorValueColor = await _myColorService.GetCurrentIdGeneratorValueAsync();
            var colorId = IntPresenter.InputId(currentIdGeneratorValueColor);
            var choseColor = await _myColorService.GetAsynс(colorId);

            var aPDTO = new FlowerDTO
            {
                Kind = choseFlowerKind,
                Variety = variety,
                Color = choseColor
            };

            await _flowerServise.AddAsync(aPDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Цветы: ");

            var flowers = await _flowerServise.GetAllAsynс(); 
            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
            }
        }

        public async Task PrintSortByKindAsync()
        {
            var flowers = await _flowerServise.GetAllAsynс();
            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
            }
        }

        private async Task PrintFlowerKindsAsync()
        {
            var flowerKinds = await _flowerKindServise.GetAllAsynс();
            foreach (var kind in flowerKinds)
            {
                Console.WriteLine($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }

        private async Task PrintColorsAsync()
        {
            var colors = await _myColorService.GetAllAsynс();
            foreach (var color in colors)
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title}, ({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
