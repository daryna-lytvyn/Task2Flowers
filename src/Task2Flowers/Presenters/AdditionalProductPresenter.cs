using System;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class AdditionalProductPresenter : IPresenter<AdditionalProduct>
    {
        private readonly IAdditionalProductService _additionalProductServise;
        private readonly IAdditionalProductTypeService _additionalProductTypeServise;
        private readonly IMyColorService _myColorService;

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

            var additionalProductDTO = new AdditionalProductDTO
            {
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
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public void PrintSortByType()
        {
            foreach (var additionalProduct in this._additionalProductServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public void Print(AdditionalProduct additionalProduct)
        {
            Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
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
                Console.WriteLine($"Id: {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
