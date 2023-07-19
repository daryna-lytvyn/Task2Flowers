using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public class FlowerPackageTypePresenter : IPresenter<FlowerPackageType>
    {
        private readonly IFlowerPackageTypeService _flowerPackageTypeServise;
        public FlowerPackageTypePresenter(IFlowerPackageTypeService flowerPackageTypeServise)
        {
            _flowerPackageTypeServise = flowerPackageTypeServise ?? throw new ArgumentNullException(nameof(flowerPackageTypeServise));
        }

        public void Input()
        {
            Console.WriteLine("Введите название вида упаковки :  ");
            var title = Console.ReadLine();

            var fPTDTO = new DataTransferObdjects.FlowerPackageTypeDTO { Title = title };

            _flowerPackageTypeServise.Add(fPTDTO);
        }

        public void Print()
        {
            Console.WriteLine("Виды упаковки: ");

            foreach (var flowerPackageType in _flowerPackageTypeServise.GetAll())
            {
                Console.Write($"Id: {flowerPackageType.Id}, {flowerPackageType.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
