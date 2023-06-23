using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class FlowerPackageTypePresenter
    {

        public void Input(Storage<FlowerPackageType> storageFlowerPackageTypes)
        {
            Console.WriteLine("Введите название вида упаковки :  ");
            var title = Console.ReadLine();

            var newId = storageFlowerPackageTypes.IdGenerator.GetNextValue();

            storageFlowerPackageTypes.Add(new FlowerPackageType(newId, title));
        }

        public void Print(Storage<FlowerPackageType> storageFlowerPackageTypes)
        {
            Console.WriteLine("Виды упаковки: ");

            foreach (var flowerPackageType in storageFlowerPackageTypes.Elements)
            {
                Console.Write($"Id: {flowerPackageType.Id}, {flowerPackageType.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
