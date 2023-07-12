using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerBundlePresenter : IPresenter<FlowerBundle>
    {
        IServiceFlowerBundle _flowerBundleServise;
        IServiceFlower _flowerServise;
        public FlowerBundlePresenter(IServiceFlowerBundle flowerBundleServise, IServiceFlower flowerServise)
        {
            _flowerBundleServise = flowerBundleServise ?? throw new ArgumentNullException(nameof(flowerBundleServise));
            _flowerServise = flowerServise ?? throw new ArgumentNullException(nameof(flowerServise));
        }
        public FlowerBundle Input()
        {
            Console.WriteLine("Введите id цветка :  ");
            this.PrintFlowers();

            int flowerId;
            bool flowerIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerIdParseResult = Int32.TryParse(textValue, out flowerId);

            } while (flowerIdParseResult == false
                        || 0 > flowerId
                        || flowerId > _flowerServise.GetAll().Count);

            var chosenFlower = _flowerServise.Get(flowerId);

            Console.WriteLine("Введите количество в пачке :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            Console.WriteLine("Введите высоту в пачке :  ");
            int height;
            bool heightParseResult;
            do
            {
                var textValue = Console.ReadLine();
                heightParseResult = Int32.TryParse(textValue, out height);

            } while (heightParseResult == false || 0 > height);

            var fBDTO = new FlowerBundleDTO
            {
                Flower = chosenFlower,
                CountOfFlower = count,
                Height = height
            };


            var newFlowerBundle = _flowerBundleServise.Add(fBDTO);

            return newFlowerBundle;
        }

        public void Print()
        {
            foreach(FlowerBundle flowerBundle in _flowerBundleServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerBundle.Id}, " +
                    $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                    $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Name} ), " +
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
            Console.Write($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
        }

        private void PrintFlowers()
        {
            foreach (var flower in _flowerServise.GetSortByKind())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }

            Console.WriteLine();
        }
    }
}
