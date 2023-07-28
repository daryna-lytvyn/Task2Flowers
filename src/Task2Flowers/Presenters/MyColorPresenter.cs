using System;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Services;

namespace Task2Flowers.Presenters
{
    public class MyColorPresenter : IPresenter<MyColor>
    {
        private readonly IMyColorService _myColorService;
        public MyColorPresenter(IMyColorService myColorService)
        {
            this._myColorService = myColorService ?? throw new ArgumentNullException(nameof(myColorService));
        }
        public void Input()
        {
            Console.WriteLine("Введите название вида цветка :  ");
            var title = Console.ReadLine();

            Console.WriteLine("Введите значение Red :  ");
            var red = this.InputByte();

            Console.WriteLine("Введите значение Green :  ");
            var green = this.InputByte();

            Console.WriteLine("Введите значение Blue :  ");
            var blue = this.InputByte();

            var mycolor = new MyColorDTO
            {
                Title = title,
                R = red,
                G = green,
                B = blue
            };

            _myColorService.Add(mycolor);
        }

        public void Print()
        {
            Console.WriteLine("Виды цвета: ");

            foreach (var color in this._myColorService.GetAll())
            {
                Console.WriteLine($"Id:{color.Id}, {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
