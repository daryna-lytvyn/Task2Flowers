using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class PackagePresenter
    {


        public Package Input(Storage<Package> storagePackages, Storage<Flower> storageFlowers, int idSupplay)
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

            Console.WriteLine("Введите количество :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            Console.WriteLine("Введите высоту :  ");
            int height;
            bool heightParseResult;
            do
            {
                var textValue = Console.ReadLine();
                heightParseResult = Int32.TryParse(textValue, out height);

            } while (heightParseResult == false || 0 > height);

            var newPackage = new Package(storagePackages.IdGenerator.GetNextValue(), idSupplay, storageFlowers.Elements[flowerId - 1], count, height);

            storagePackages.Add(newPackage);

            return newPackage;
        }

        public void Print(Storage<Package> storagePackages)
        {
            foreach (var package in storagePackages.Elements)
            {
                Console.WriteLine($"\t\t\t\tId: {package.Id}, Id поставки: {package.IdOfSupplay}," +
                    $" цветок:( id{package.Flower.Id}, {package.Flower.Kind.Title}, {package.Flower.Variety}," +
                    $" {package.Flower.Color.Name})," + " количество: {packege.CountOfFlower}шт.," +
                    " высота: {packege.FlowersHeight}см.");
            }
        }
    }
}
