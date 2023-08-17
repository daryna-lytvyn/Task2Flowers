using System;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class AdditionalProductTypePresenter : IPresenter<AdditionalProductType>
    {
        private readonly IAdditionalProductTypeService _additionalProductTypeServise;

        public AdditionalProductTypePresenter(IAdditionalProductTypeService additionalProductTypeServise)
        {
            _additionalProductTypeServise = additionalProductTypeServise ?? throw new ArgumentNullException(nameof(additionalProductTypeServise));
        }

        public async Task InputAsync()
        {
            Console.WriteLine("Введите название вида дополнительного товара :  ");
            var title = Console.ReadLine();
            var aPTDTO = new AdditionalProductTypeDTO { Title = title };

            await _additionalProductTypeServise.AddAsync(aPTDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Виды дополнительного товара: ");

            var additionalProducts = await _additionalProductTypeServise.GetAllAsynс();
            foreach (var additionalProduct in additionalProducts)
            {
                Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }
    }
}

