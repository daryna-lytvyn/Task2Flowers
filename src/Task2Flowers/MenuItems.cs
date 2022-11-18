using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class MenuItems
    {
        public void AddKindOfFlower(List<KindOfFlower> kindsOfFlower, IdGenerator idKindsOfFlower)
        {
            Console.WriteLine("Введите название вида цветка :  ");
            string title = Console.ReadLine();

            kindsOfFlower.Add(new KindOfFlower(idKindsOfFlower.GetNextValue(), title));
        }

        public void AddFlower(List<Flower> flowers, List<KindOfFlower> kindsOfFlower, IdGenerator idFlowers)
        {
            this.ShowKindOfFlowers(kindsOfFlower);

            Console.WriteLine("Введите номер вида цветка :  ");
            var numderKingOfFlower = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Введите сорт цветка :  ");
            var title = Console.ReadLine();

            //Console.WriteLine("Введите цвет цветка :  ");
            var сolor = Color.White;//Color.FromName(Console.ReadLine());

            flowers.Add(new Flower(idFlowers.GetNextValue(), kindsOfFlower[numderKingOfFlower - 1], title, сolor));
        }

        public void AddSupplay(List<Supplay> supplays, List<Flower> flowers, IdGenerator idPackege, IdGenerator idSupplays)
        {
            var marker = true;
            var packeges = new List<FlowerPackege>();

            do
            {
                Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");
                var value = Int32.Parse(Console.ReadLine());
                if (value != 1)
                {
                    marker = false;
                }

                Console.WriteLine("Введите номер цветка :  ");
                this.ShowFlowers(flowers);
                var flowerId = Int32.Parse(Console.ReadLine())-1;

                Console.WriteLine("Введите количество :  ");
                var count = Int32.Parse(Console.ReadLine());

                Console.WriteLine("Введите высоту :  ");
                var height = Int32.Parse(Console.ReadLine());

                var packege = new FlowerPackege(idPackege.GetNextValue(), flowers[flowerId], count, height);
                packeges.Add(packege);
                
            } while (marker);

            supplays.Add(new Supplay(idSupplays.GetNextValue(), packeges, DateTime.Now));
        }

        public void ShowKindOfFlowers(List<KindOfFlower> kindsOfFlower)
        {
            Console.WriteLine("Виды цветов: ");

            foreach (var kind in kindsOfFlower)
            {
                Console.Write($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }

        public void ShowFlowers(List<Flower> flowers)
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in flowers)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        public void ShowFlowersSortByKind(List<Flower> flowers)
        {
            var sortFlowersByKind = flowers.Select(f => f).OrderBy(f => f.Kind.Title);
            Console.WriteLine("Цветы: ");

            foreach (var flower in sortFlowersByKind)
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }

        }
        public void ShowSupplays(List<Supplay> supplays)
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
