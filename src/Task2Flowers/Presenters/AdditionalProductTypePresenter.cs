using System;
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

        public void Input()
        {
            Console.WriteLine("Введите название вида дополнительного товара :  ");
            var title = Console.ReadLine();
            var aPTDTO = new AdditionalProductTypeDTO { Title = title };

            _additionalProductTypeServise.Add(aPTDTO);
        }

        public void Print()
        {
            Console.WriteLine("Виды дополнительного товара: ");

            foreach (var additionalProduct in _additionalProductTypeServise.GetAll())
            {
                Console.Write($"Id: {additionalProduct.Id}, {additionalProduct.Title}, ");
            }

            Console.WriteLine();
        }
    }
}

