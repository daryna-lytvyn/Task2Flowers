using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerBundlePresenter
    {
        public FlowerBundle Input(Storage<FlowerBundle> storageFlowerBundles, Storage<Flower> storageFlowers)
        {
            var flowerPresenter = new FlowerPresenter();

            Console.WriteLine("Введите id цветка :  ");
            flowerPresenter.Print(storageFlowers);
            int flowerId;
            bool flowerIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerIdParseResult = Int32.TryParse(textValue, out flowerId);

            } while (flowerIdParseResult == false || 0 > flowerId || flowerId > storageFlowers.Elements.Count);

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

            var newFlowerBundle = new FlowerBundle(storageFlowerBundles.IdGenerator.GetNextValue(), storageFlowers.Elements[flowerId - 1], count, height);

            storageFlowerBundles.Add(newFlowerBundle);

            return newFlowerBundle;
        }

        public void Print(FlowerBundle flowerBundle)
        {
            Console.Write($"Id: {flowerBundle.Id}, Цветок: ( ");

            var flowerPresenter = new FlowerPresenter();
            flowerPresenter.Print(flowerBundle.Flower);

            Console.Write($" ), Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
        }
    }
}
