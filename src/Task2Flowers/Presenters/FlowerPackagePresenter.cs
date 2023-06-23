using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerPackagePresenter
    {
        public void Input(Storage<FlowerPackage> storageFlowerPackages, Storage<FlowerPackageType> storageFlowerPackageTypes)
        {
            var flowerPackageTypesPresenter = new FlowerPackageTypePresenter();
            flowerPackageTypesPresenter.Print(storageFlowerPackageTypes);

            Console.WriteLine("Введите id вида упаковки :  ");

            int flowerPackageTypeId;
            bool flowerPackageTypeIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerPackageTypeIdParseResult = Int32.TryParse(textValue, out flowerPackageTypeId);

            } while (flowerPackageTypeIdParseResult == false || 0 > flowerPackageTypeId || flowerPackageTypeId > storageFlowerPackageTypes.Elements.Count);


            Console.WriteLine("Введите высоту упаковки :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите высоту :  ");
            int height;
            bool heightParseResult;
            do
            {
                var textValue = Console.ReadLine();
                heightParseResult = Int32.TryParse(textValue, out height);

            } while (heightParseResult == false || 0 > height);

            Console.WriteLine("Введите длинну/диаметр/ширину :  ");
            int width;
            bool widthParseResult;
            do
            {
                var textValue = Console.ReadLine();
                widthParseResult = Int32.TryParse(textValue, out width);

            } while (widthParseResult == false || 0 > width);

            Console.WriteLine("Введите цвет упаковки :  ");
            var colorTextValue = Console.ReadLine();

            Console.WriteLine("Введите описание упаковки :  ");
            var description = Console.ReadLine();

            var newFlowerPackage = new FlowerPackage(storageFlowerPackages.IdGenerator.GetNextValue(), storageFlowerPackageTypes.Elements[flowerPackageTypeId - 1], height, width, Color.FromName(colorTextValue), description);

            storageFlowerPackages.Add(newFlowerPackage);
        }

        public void Print(Storage<FlowerPackage> storageFlowerPackages)
        {
            Console.WriteLine("Упаковки: ");

            foreach (var flowerPackage in storageFlowerPackages.Elements)
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
            }
        }

        public void PrintSortByType(Storage<FlowerPackage> storageFlowerPackages)
        {
            var sortFlowerPackagesByType = storageFlowerPackages.Elements.Select(p => p).OrderBy(p => p.Type.Title);
            foreach (var flowerPackage in sortFlowerPackagesByType)
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title},  {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
            }
        }

        public void Print(FlowerPackage flowerPackage)
        {
            Console.Write($"Id: {flowerPackage.Id}, {flowerPackage.Type.Title},  {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
        }
    }
}
