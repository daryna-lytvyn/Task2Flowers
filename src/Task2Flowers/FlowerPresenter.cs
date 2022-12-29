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
        public Flower Input(IntIdGenerator idFlowers, List<KindOfFlower> kindsOfFlower)
        {
            var kindsOfFlowerPresenter = new KindsOfFlowerPresenter();
            kindsOfFlowerPresenter.Print(kindsOfFlower);

            Console.WriteLine("Введите номер вида цветка :  ");

            int numderKingOfFlower;
            Int32.TryParse(Console.ReadLine(), out numderKingOfFlower);

            Console.WriteLine("Введите сорт цветка :  ");
            var title = Console.ReadLine();

            //Console.WriteLine("Введите цвет цветка :  ");
            var сolor = Color.White;//Color.FromName(Console.ReadLine());

            return (new Flower(idFlowers.GetNextValue(), kindsOfFlower[numderKingOfFlower - 1], title, сolor));
        }

        public void Print(List<Flower> flowers)
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        public void PrintSortByKind(List<Flower> flowers)
        {
            var sortFlowersByKind = flowers.Select(f => f).OrderBy(f => f.Kind.Title);
            Console.WriteLine("Цветы: ");

            foreach (var flower in sortFlowersByKind)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }
    }
}
