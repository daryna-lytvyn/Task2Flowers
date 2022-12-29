using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class KindsOfFlowerPresenter
    {
        public KindOfFlower Input(IntIdGenerator idKindsOfFlower)
        {
            Console.WriteLine("Введите название вида цветка :  ");
            string title = Console.ReadLine();

            return (new KindOfFlower(idKindsOfFlower.GetNextValue(), title));
        }

        public void Print(List<KindOfFlower> kindsOfFlower)
        {
            Console.WriteLine("Виды цветов: ");

            foreach (var kind in kindsOfFlower)
            {
                Console.Write($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
