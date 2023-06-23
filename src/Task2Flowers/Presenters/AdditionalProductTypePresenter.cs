using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class AdditionalProductTypePresenter
    {
        public void Input(Storage<AdditionalProductType> storageAdditionalProductTypes)
        {
            Console.WriteLine("Введите название вида дополнительного товара :  ");
            var title = Console.ReadLine();

            var newId = storageAdditionalProductTypes.IdGenerator.GetNextValue();

            storageAdditionalProductTypes.Add(new AdditionalProductType(newId, title));
        }

        public void Print(Storage<AdditionalProductType> storageAdditionalProductTypes)
        {
            Console.WriteLine("Виды дополнительного товара: ");

            foreach (var additionalProduct in storageAdditionalProductTypes.Elements)
            {
                Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
