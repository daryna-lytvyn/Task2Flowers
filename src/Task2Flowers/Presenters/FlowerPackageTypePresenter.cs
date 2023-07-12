using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerPackageTypePresenter : IPresenter<FlowerPackageType>
    {
        IServiceFlowerPackageType _flowerPackageTypeServise;
        public FlowerPackageTypePresenter(IServiceFlowerPackageType flowerPackageTypeServise)
        {
            _flowerPackageTypeServise = flowerPackageTypeServise ?? throw new ArgumentNullException(nameof(flowerPackageTypeServise));
        }

        public FlowerPackageType Input()
        {
            Console.WriteLine("Введите название вида упаковки :  ");
            var title = Console.ReadLine();

            var fPTDTO = new FlowerPackageTypeDTO { Title = title };

            var newFPT = _flowerPackageTypeServise.Add(fPTDTO);
            return newFPT;
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
