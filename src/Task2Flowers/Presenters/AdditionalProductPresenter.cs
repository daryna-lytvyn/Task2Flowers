using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class AdditionalProductPresenterIPresenter<AdditionalProduct>
    {
        IServiceAdditionalProduct _additionalProductServise;
        IServiceAdditionalProductType _additionalProductTypeServise;

        public AdditionalProductPresenter(IServiceAdditionalProduct additionalProductServise, IServiceAdditionalProductType additionalProductTypeServise)
        {
            _additionalProductServise = additionalProductServise ?? throw new ArgumentNullException(nameof(additionalProductServise));
            _additionalProductTypeServise = additionalProductTypeServise ?? throw new ArgumentNullException(nameof(additionalProductTypeServise));
        }

        public AdditionalProduct Input()
        {
            this.PrintAPT();

            Console.WriteLine("Введите id вида дополнительного товара :  ");

            int additionalProductTypeId;
            bool additionalProductTypeIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                additionalProductTypeIdParseResult = Int32.TryParse(textValue, out additionalProductTypeId);

            } while (additionalProductTypeIdParseResult == false
                        || 0 > additionalProductTypeId
                        || additionalProductTypeId >_additionalProductServise.GetAll().Count);

            var choseAPType = _additionalProductTypeServise.Get(additionalProductTypeId);

            Console.WriteLine("Введите название дополнительного товара :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите цвет дополнительного товара :  ");
            var colorTextValue = Console.ReadLine();

            Console.WriteLine("Введите описание дополнительного товара :  ");
            var description = Console.ReadLine();

            var aPDTO = new AdditionalProductDTO {
                Type = choseAPType,
                Title = title,
                Color = Color.FromName(colorTextValue),
                Desctiption = description
            };

            var newAP = this._additionalProductServise.Add(aPDTO);
            return newAP;
        }

        public void Print()
        {
            Console.WriteLine("Дополнительные товары: ");

            foreach (var additionalProduct in this._additionalProductServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
            }
        }

        public void PrintSortByType()
        {
            foreach (var additionalProduct in this._additionalProductServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
            }
        }

        public void Print(AdditionalProduct additionalProduct)
        {
            Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Name}, {additionalProduct.Desctiption}");
        }

        private void PrintAPT()
        {
            foreach (var additionalProduct in _additionalProductTypeServise.GetAll())
            {
                Console.WriteLine($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
