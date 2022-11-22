using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class MyInputOutput
    {
        public KindOfFlower InputKindOfFlower(IntIdGenerator idKindsOfFlower)
        {
            Console.WriteLine("Введите название вида цветка :  ");
            string title = Console.ReadLine();

            return (new KindOfFlower(idKindsOfFlower.GetNextValue(), title));
        }

        public Flower InputFlower(List<KindOfFlower> kindsOfFlower, IntIdGenerator idFlowers)
        {
            this.PrintKindOfFlowers(kindsOfFlower);

            Console.WriteLine("Введите номер вида цветка :  ");

            int numderKingOfFlower;
            Int32.TryParse(Console.ReadLine(), out numderKingOfFlower);

            Console.WriteLine("Введите сорт цветка :  ");
            var title = Console.ReadLine();

            //Console.WriteLine("Введите цвет цветка :  ");
            var сolor = Color.White;//Color.FromName(Console.ReadLine());

            return (new Flower(idFlowers.GetNextValue(), kindsOfFlower[numderKingOfFlower - 1], title, сolor));
        }

        public Supplay InputSupplay(List<Flower> flowers, IntIdGenerator idPackege, IntIdGenerator idSupplay)
        {
            var marker = true;
            var packeges = new List<Package>();

            do
            {
                Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");
                int value;
                Int32.TryParse(Console.ReadLine(), out value);

                if (value != 1)
                {
                    marker = false;
                }

                Console.WriteLine("Введите номер цветка :  ");
                this.PrintFlowers(flowers);
                int flowerId;
                Int32.TryParse(Console.ReadLine(), out flowerId);

                Console.WriteLine("Введите количество :  ");
                int count;
                Int32.TryParse(Console.ReadLine(), out count);

                Console.WriteLine("Введите высоту :  ");
                int height;
                Int32.TryParse(Console.ReadLine(), out height);

                var packege = new Package(idPackege.GetNextValue(), flowers[flowerId-1], count, height);
                packeges.Add(packege);

            } while (marker);

            return (new Supplay(idSupplay.GetNextValue(), packeges, DateTime.Now));
        }

        public void PrintKindOfFlowers(List<KindOfFlower> kindsOfFlower)
        {
            Console.WriteLine("Виды цветов: ");

            foreach (var kind in kindsOfFlower)
            {
                Console.Write($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }

        public void PrintFlowers(List<Flower> flowers)
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        public void PrintFlowersSortByKind(List<Flower> flowers)
        {
            var sortFlowersByKind = flowers.Select(f => f).OrderBy(f => f.Kind.Title);
            Console.WriteLine("Цветы: ");

            foreach (var flower in sortFlowersByKind)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }

        }
        public void PrintSupplays(List<Supplay> supplays)
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in supplays)
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.Date}, свертки: ");

                foreach (var packege in supplay.FlowerPackeges)
                {
                    Console.WriteLine($"\t\t\t\tId{packege.Id}," +
                        $" цветок:( id{packege.Flower.Id}, {packege.Flower.Kind.Title}, {packege.Flower.Variety}, {packege.Flower.Color.Name})," +
                        $" количество: {packege.CountOfFlower}шт., высота: {packege.FlowersHeight}см.");
                }
            }
        }
    }
}
