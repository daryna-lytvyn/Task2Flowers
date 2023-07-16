using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Presenters;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerBundlePresenter : IPresenter<FlowerBundle>
    {
        IFlowerBundleService _flowerBundleServise;
        IFlowerService _flowerServise;
        public FlowerBundlePresenter(IFlowerBundleService flowerBundleServise, IFlowerService flowerServise)
        {
            _flowerBundleServise = flowerBundleServise ?? throw new ArgumentNullException(nameof(flowerBundleServise));
            _flowerServise = flowerServise ?? throw new ArgumentNullException(nameof(flowerServise));
        }
        public void Input()
        {
            Console.WriteLine("Введите id цветка :  ");
            this.PrintFlowers();
            var flowerId = IntPresenter.InputId(_flowerServise.GetCurrentIdGeneratorValue());
            var chosenFlower = _flowerServise.Get(flowerId);

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

            _flowerBundleServise.Add(fBDTO);
        }

        public void Print()
        {
            foreach(FlowerBundle flowerBundle in _flowerBundleServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerBundle.Id}, " +
                    $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                    $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Title} ), " +
                    $"Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
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

        private void PrintFlowers()
        {
            foreach (var flower in _flowerServise.GetSortByKind())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Title}");
            }

            Console.WriteLine();
        }
    }
}
