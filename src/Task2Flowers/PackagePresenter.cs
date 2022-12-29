using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class PackagePresenter
    {
        public (Package, bool) InputForMany(IntIdGenerator idPackage, List<Flower> flowers, int idSupplay)
        {
            var package = this.Input(idPackage, flowers, idSupplay);

            Console.WriteLine("\t\t - Добавить еще сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");
            int value;
            Int32.TryParse(Console.ReadLine(), out value);

            var marker = true;

            if (value != 1)
            {
                marker = false;

            }

            return (package, marker);
        }


        public Package Input(IntIdGenerator idPackage, List<Flower> flowers, int idSupplay)
        {
            var flowerPresenter = new FlowerPresenter();

            Console.WriteLine("Введите номер цветка :  ");
            flowerPresenter.Print(flowers);
            int flowerId;
            Int32.TryParse(Console.ReadLine(), out flowerId);

            Console.WriteLine("Введите количество :  ");
            int count;
            Int32.TryParse(Console.ReadLine(), out count);

            Console.WriteLine("Введите высоту :  ");
            int height;
            Int32.TryParse(Console.ReadLine(), out height);

            return new Package(idPackage.GetNextValue(), idSupplay, flowers[flowerId - 1], count, height);
        }

        public void Print(List<Package> packages)
        {
            foreach (var package in packages)
            {
                Console.WriteLine($"\t\t\t\tId: {package.Id}, Id поставки: {package.Id}," +
                    $" цветок:( id{package.Flower.Id}, {package.Flower.Kind.Title}, {package.Flower.Variety}," +
                    $" {package.Flower.Color.Name})," + " количество: {packege.CountOfFlower}шт.," +
                    " высота: {packege.FlowersHeight}см.");
            }
        }
    }
}
