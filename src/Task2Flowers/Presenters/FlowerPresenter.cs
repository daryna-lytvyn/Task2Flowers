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
    public class FlowerPresenter : IPresenter<Flower>
    {
        IServiceFlower _flowerServise;
        IServiceFlowerKind _flowerKindServise;

        public Flower Input()
        {
            this.PrintFlowerKinds();

            Console.WriteLine("Введите id вида цветка :  ");

            int kingOfFlowerId;
            bool kingOfFlowerIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                kingOfFlowerIdParseResult = Int32.TryParse(textValue, out kingOfFlowerId);

            } while (kingOfFlowerIdParseResult == false 
                        || 0 > kingOfFlowerId 
                        || kingOfFlowerId > _flowerKindServise.GetAll().Count);

            var choseFK = _flowerKindServise.Get(kingOfFlowerId);

            Console.WriteLine("Введите сорт цветка :  ");
            var variety = Console.ReadLine();

            Console.WriteLine("Введите цвет цветка :  ");
            var colorTextValue = Console.ReadLine();

            var aPDTO = new FlowerDTO
            {
                Kind = choseFK,
                Variety = variety,
                Color = Color.FromName(colorTextValue)
            };

            var newFlower = _flowerServise.Add(aPDTO);
            return newFlower;
        }

        public void Print()
        {
            Console.WriteLine("Цветы: ");

            foreach (var flower in _flowerServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        public void PrintSortByKind()
        {
            foreach (var flower in _flowerServise.GetSortByKind())
            {
                Console.WriteLine($"\t\tId: {flower.Id}, {flower.Kind.Title}, {flower.Variety}, {flower.Color.Name}");
            }
        }

        private void PrintFlowerKinds()
        {
            foreach (var kind in this._flowerKindServise.GetAll())
            {
                Console.WriteLine($"Id: {kind.Id}, {kind.Title}, ");
            }

            Console.WriteLine();
        }
    }
}
