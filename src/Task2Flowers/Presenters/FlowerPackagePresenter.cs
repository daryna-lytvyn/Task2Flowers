using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class FlowerPackagePresenter : IPresenter<FlowerPackage>
    {
        IServiceFlowerPackage _flowerPackageServise;
        IServiceFlowerPackageType _flowerPackageTypeServise;


        public FlowerPackagePresenter(IServiceFlowerPackage flowerPackageServise, IServiceFlowerPackageType flowerPackageTypeServise)
        {
            _flowerPackageServise = flowerPackageServise ?? throw new ArgumentNullException(nameof(flowerPackageServise));
            _flowerPackageTypeServise = flowerPackageTypeServise ?? throw new ArgumentNullException(nameof(flowerPackageTypeServise));
        }

        public FlowerPackage Input()
        {
            Console.WriteLine("Введите id вида упаковки :  ");
            
            this.PrintFPT();

            int flowerPackageTypeId;
            bool flowerPackageTypeIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerPackageTypeIdParseResult = Int32.TryParse(textValue, out flowerPackageTypeId);

            } while (flowerPackageTypeIdParseResult == false 
                        || 0 > flowerPackageTypeId 
                        || flowerPackageTypeId > _flowerPackageTypeServise.GetAll().Count);

            var chosenFPT = _flowerPackageTypeServise.Get(flowerPackageTypeId);
            
            Console.WriteLine("Введите название упаковки :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите высоту :  ");
            int height;
            bool heightParseResult;
            do
            {
                var textValue = Console.ReadLine();
                heightParseResult = Int32.TryParse(textValue, out height);

            } while (heightParseResult == false || 0 > height);

            Console.WriteLine("Введите длинну/диаметр/ширину :  ");
            int width;
            bool widthParseResult;
            do
            {
                var textValue = Console.ReadLine();
                widthParseResult = Int32.TryParse(textValue, out width);

            } while (widthParseResult == false || 0 > width);

            Console.WriteLine("Введите цвет упаковки :  ");
            var colorTextValue = Console.ReadLine();

            Console.WriteLine("Введите описание упаковки :  ");
            var description = Console.ReadLine();

            var fPDTO = new FlowerPackageDTO
            {
                Type = chosenFPT,
                Height = height,
                Width = width,
                Color = Color.FromName(colorTextValue),
                Desctiption = description
            };

            var newFP = _flowerPackageServise.Add(fPDTO);

            return newFP;
        }

        public void Print()
        {
            Console.WriteLine("Упаковки: ");

            foreach (var flowerPackage in _flowerPackageServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
            }
        }

        public void PrintSortByType()
        {
            
            foreach (var flowerPackage in _flowerPackageServise.GetSortByType())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type.Title},  {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
            }
        }

        private void PrintFPT()
        {
            foreach (var flowerPackageType in _flowerPackageTypeServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerPackageType.Id}, {flowerPackageType.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
