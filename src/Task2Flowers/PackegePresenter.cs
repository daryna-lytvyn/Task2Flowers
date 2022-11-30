using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class PackegePresenter
    {
        public (Package, bool) InputForMany(IntIdGenerator idPackege, List<Flower> flowers, int idSupplay)
        {
            var packege = this.Input(idPackege, flowers, idSupplay);
          
            Console.WriteLine("\t\t - Добавить еще сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");
            int value;
            Int32.TryParse(Console.ReadLine(), out value);

            var marker = true;

            if (value != 1)
            {
                marker = false;
                
            }

            return (packege, marker);
        }


        public Package Input(IntIdGenerator idPackege, List<Flower> flowers, int idSupplay)
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

            return new Package(idPackege.GetNextValue(), idSupplay, flowers[flowerId - 1], count, height);
        }

        public void Print(List<Package> packeges)
        {
            foreach (var packege in packeges)
            {
                Console.WriteLine($"\t\t\t\tId: {packege.Id}, Id поставки: {packege.Id}," +
                    $" цветок:( id{packege.Flower.Id}, {packege.Flower.Kind.Title}, {packege.Flower.Variety}," +
                    $" {packege.Flower.Color.Name})," + " количество: {packege.CountOfFlower}шт.," +
                    " высота: {packege.FlowersHeight}см.");
            }
        }
    }
}
