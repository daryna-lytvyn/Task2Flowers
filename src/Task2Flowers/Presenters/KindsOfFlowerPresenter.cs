using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class KindsOfFlowerPresenter
    {
        public void Input(Storage<KindOfFlower> storageKindsOfFlowers)
        {
            Console.WriteLine("Введите название вида цветка :  ");
            var title = Console.ReadLine();

            var newId = storageKindsOfFlowers.IdGenerator.GetNextValue();

            storageKindsOfFlowers.Add(new KindOfFlower(newId, title));
        }

        public void Print(Storage<KindOfFlower> storageKindsOfFlowers)
        {
            Console.WriteLine("Виды цветов: ");

            foreach (var kind in storageKindsOfFlowers.Elements)
            {
                Console.Write($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
