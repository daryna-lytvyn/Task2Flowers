using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Presenters;
namespace Task2Flowers.Presenters
{
    public class FlowerBundlePresenter : IPresenter<FlowerBundle>
    {
        private readonly IFlowerBundleService _flowerBundleServise;
        private readonly IFlowerService _flowerServise;
        public FlowerBundlePresenter(IFlowerBundleService flowerBundleServise, IFlowerService flowerServise)
        {
            _flowerBundleServise = flowerBundleServise ?? throw new ArgumentNullException(nameof(flowerBundleServise));
            _flowerServise = flowerServise ?? throw new ArgumentNullException(nameof(flowerServise));
        }
        public async Task InputAsync()
        {
            Console.WriteLine("Введите id цветка :  ");
            await this.PrintFlowersAsync();
            var currentIdGeneratorValueAsync = await _flowerServise.GetCurrentIdGeneratorValueAsync();
            var flowerId = IntPresenter.InputId(currentIdGeneratorValueAsync);
            var chosenFlower = await _flowerServise.GetAsynс(flowerId);

            Console.WriteLine("Введите количество в пачке :  ");
            var count = IntPresenter.Input(0,100);

            Console.WriteLine("Введите высоту в пачке (см) :  ");
            var height = IntPresenter.Input(0, 200);

            var fBDTO = new FlowerBundleDTO
            {
                Flower = chosenFlower,
                CountOfFlower = count,
                Height = height
            };


            await _flowerBundleServise.AddAsync(fBDTO);
        }

        public async Task PrintAsync()
        {
            var flowerBundles = await _flowerBundleServise.GetAllAsynс();
            foreach (FlowerBundle flowerBundle in flowerBundles)
            {
                Console.WriteLine($"Id: {flowerBundle.Id}, Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, {flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Title} ), Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
            }
        }
        
        public void Print(FlowerBundle flowerBundle)
        {
            Console.Write($"Id: {flowerBundle.Id}, Цветок: ( ");
            this.PrintFlower(flowerBundle.Flower);
            Console.Write($" ), Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
        }

        private void PrintFlower(Flower flower)
        {
            Console.Write($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
        }

        private async Task PrintFlowersAsync()
        {
            var flowers = await _flowerServise.GetSortByKindAsync();
            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
            }

            Console.WriteLine();
        }
    }
}
