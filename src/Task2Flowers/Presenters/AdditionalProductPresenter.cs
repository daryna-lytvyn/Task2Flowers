using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Presenters;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class AdditionalProductPresenter: IPresenter<AdditionalProduct>
    {
        IAdditionalProductService _additionalProductServise;
        IAdditionalProductTypeService _additionalProductTypeServise;
        IMyColorService _myColorService;

        public AdditionalProductPresenter(IAdditionalProductService additionalProductServise, IAdditionalProductTypeService additionalProductTypeServise, IMyColorService myColorService)
        {
            _additionalProductServise = additionalProductServise ?? throw new ArgumentNullException(nameof(additionalProductServise));
            _additionalProductTypeServise = additionalProductTypeServise ?? throw new ArgumentNullException(nameof(additionalProductTypeServise));
            _myColorService = myColorService ?? throw new ArgumentNullException(nameof(myColorService));
        }

        public void Input()
        {
            Console.WriteLine("Введите id вида дополнительного товара :  ");
            this.PrintAdditionalProductTypes();
            var additionalProductTypeId = IntPresenter.InputId(_additionalProductTypeServise.GetAll().Count);
            var choseAdditionalProductType = _additionalProductTypeServise.Get(additionalProductTypeId);

            Console.WriteLine("Введите название дополнительного товара :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите описание дополнительного товара :  ");
            var description = Console.ReadLine();

            Console.WriteLine("Введите id цвета :  ");
            this.PrintColors();
            var colorId = IntPresenter.InputId(_myColorService.GetCurrentIdGeneratorValue());
            var choseColor = _myColorService.Get(colorId);

            var additionalProductDTO = new AdditionalProductDTO {
                Type = choseAdditionalProductType,
                Title = title,
                Color = choseColor,
                Desctiption = description
            };

            this._additionalProductServise.Add(additionalProductDTO);
        }

        public void Print()
        {
            Console.WriteLine("Дополнительные товары: ");

            foreach (var additionalProduct in this._additionalProductServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, " +
                    $"{additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public void PrintSortByType()
        {
            foreach (var additionalProduct in this._additionalProductServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, " +
                    $"{additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public void Print(AdditionalProduct additionalProduct)
        {
            Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Type.Title}, " +
                $"{additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
        }

        private void PrintAdditionalProductTypes()
        {
            foreach (var additionalProduct in _additionalProductTypeServise.GetAll())
            {
                Console.WriteLine($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }

        private void PrintColors()
        {
            foreach (var color in this._myColorService.GetAll())
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
