using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class AdditionalProductPresenter
    {
        public void Input(Storage<AdditionalProduct> storageAdditionalProducts, Storage<AdditionalProductType> storageAdditionalProductTypes)
        {
            var additionalProductTypesPresenter = new AdditionalProductTypePresenter();
            additionalProductTypesPresenter.Print(storageAdditionalProductTypes);

            Console.WriteLine("Введите id вида дополнительного товара :  ");

            int additionalProductTypeId;
            bool additionalProductTypeIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                additionalProductTypeIdParseResult = Int32.TryParse(textValue, out additionalProductTypeId);

            } while (additionalProductTypeIdParseResult == false 
                        || 0 > additionalProductTypeId
                        || additionalProductTypeId > storageAdditionalProductTypes.Elements.Count);


            Console.WriteLine("Введите название дополнительного товара :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите цвет дополнительного товара :  ");
            var colorTextValue = Console.ReadLine();

            Console.WriteLine("Введите описание дополнительного товара :  ");
            var description = Console.ReadLine();

            var newAdditionalProduct = new AdditionalProduct(storageAdditionalProducts.IdGenerator.GetNextValue(), storageAdditionalProductTypes.Elements[additionalProductTypeId - 1], title, Color.FromName(colorTextValue), description);

            storageAdditionalProducts.Add(newAdditionalProduct);
        }

        public void Print(Storage<AdditionalProduct> storageAdditionalProducts)
        {
            Console.WriteLine("Дополнительные товары: ");

            foreach (var additionalProduct in storageAdditionalProducts.Elements)
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
            }
        }

        public void PrintSortByType(Storage<AdditionalProduct> storageAdditionalProducts)
        {
            var sortAdditionalProductsByType = storageAdditionalProducts.Elements.Select(p => p).OrderBy(p => p.Type.Title);
            foreach (var additionalProduct in sortAdditionalProductsByType)
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
            }
        }

        public void Print(AdditionalProduct additionalProduct)
        {
            Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
        }
    }
}
