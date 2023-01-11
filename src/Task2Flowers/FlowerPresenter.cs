using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerPresenter
    {
        public void Input(Storage<Flower> storageFlowers, Storage<KindOfFlower> storageKindsOfFlower)
        {
            var kindsOfFlowerPresenter = new KindsOfFlowerPresenter();
            kindsOfFlowerPresenter.Print(storageKindsOfFlower);

            Console.WriteLine("Введите id вида цветка :  ");

            int kingOfFlowerId;
            bool kingOfFlowerIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                kingOfFlowerIdParseResult = Int32.TryParse(textValue, out kingOfFlowerId);

            } while (kingOfFlowerIdParseResult == false || 0 > kingOfFlowerId || kingOfFlowerId > storageKindsOfFlower.Elements.Count);


            Console.WriteLine("Введите сорт цветка :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите цвет цветка :  ");
            var colorTextValue = Console.ReadLine();

            var newFlower = new Flower(storageFlowers.IdGenerator.GetNextValue(), storageKindsOfFlower.Elements[kingOfFlowerId - 1], title, Color.FromName(colorTextValue));

            storageFlowers.Add(newFlower);
        }

        public void Print(Storage<Flower> storageFlowers)
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in storageFlowers.Elements)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        public void PrintSortByKind(Storage<Flower> storageFlowers)
        {
            var sortFlowersByKind = storageFlowers.Elements.Select(f => f).OrderBy(f => f.Kind.Title);
            foreach (var flower in sortFlowersByKind)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }
    }
}
