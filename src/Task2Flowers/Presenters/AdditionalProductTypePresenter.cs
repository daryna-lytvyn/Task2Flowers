using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class AdditionalProductTypePresenter: IPresenter<AdditionalProductType>
    {
        IServiceAdditionalProductType _additionalProductTypeServise;

        public AdditionalProductTypePresenter(IServiceAdditionalProductType additionalProductTypeServise)
        {
            _additionalProductTypeServise = additionalProductTypeServise ?? throw new ArgumentNullException(nameof(additionalProductTypeServise));
        }

        public AdditionalProductType Input()
        {
            Console.WriteLine("Введите название вида дополнительного товара :  ");
            var title = Console.ReadLine();
            var aPTDTO = new AdditionalProductTypeDTO { Title = title };

            var newAPT =_additionalProductTypeServise.Add(aPTDTO);
            return newAPT;
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

