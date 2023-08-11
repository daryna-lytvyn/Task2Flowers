using System;
using System.Threading.Tasks;
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

        public async Task InputAsync()
        {
            Console.WriteLine("Введите id вида дополнительного товара :  ");
            await this.PrintAdditionalProductTypesAsync();
            var additionalProductTypeServises = await _additionalProductTypeServise.GetAllAsynс();
            var additionalProductTypeId = IntPresenter.InputId(additionalProductTypeServises.Count);
            var choseAdditionalProductType = await _additionalProductTypeServise.GetAsynс(additionalProductTypeId);

            Console.WriteLine("Введите название дополнительного товара :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите описание дополнительного товара :  ");
            var description = Console.ReadLine();

            Console.WriteLine("Введите id цвета :  ");
            await this.PrintColorsAsync();
            var currentIdGeneratorValueColor = await _myColorService.GetCurrentIdGeneratorValueAsync();
            var colorId = IntPresenter.InputId(currentIdGeneratorValueColor);
            var choseColor = await _myColorService.GetAsynс(colorId);

            var additionalProductDTO = new AdditionalProductDTO
            {
                Type = choseAdditionalProductType,
                Title = title,
                Color = choseColor,
                Desctiption = description
            };

            await _additionalProductServise.AddAsync(additionalProductDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Дополнительные товары: ");

            var sortByType = await this._additionalProductServise.GetAllAsynс();
            foreach (var additionalProduct in sortByType)
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public async Task PrintSortByTypeAsync()
        {
            var sortByType = await this._additionalProductServise.GetSortByTypeAsync();

            foreach (var additionalProduct in sortByType)
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
            }
        }

        public void Print(AdditionalProduct additionalProduct)
        {
            Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Type.Title}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
        }

        private async Task PrintAdditionalProductTypesAsync()
        {
            var additionalProducts = await _additionalProductTypeServise.GetAllAsynс();
            
            foreach (var additionalProduct in additionalProducts)
            {
                Console.WriteLine($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }

        private async Task PrintColorsAsync()
        {
            var colors = await _myColorService.GetAllAsynс();

            foreach (var color in colors)
            {
                Console.WriteLine($"Id: {color.Id}, {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
