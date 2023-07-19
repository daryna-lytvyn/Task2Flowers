using System;
using Task2Flowers.Entities;
using Task2Flowers.Interfeses;
using Task2Flowers.Services;

namespace Task2Flowers.Presenters
{
    public class MyColorPresenter : IPresenter<MyColor>
    {
        private readonly MyColorService _myColorService;
        public MyColorPresenter(MyColorService myColorService)
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

            var mycolor = new MyColor(title, red, green, blue);

            _myColorService.Add(mycolor);
        }

        public void Print()
        {
            Console.WriteLine("Виды цвета: ");

            foreach (var color in this._myColorService.GetAll())
            {
                Console.WriteLine($"Id: {color.Title},({color.R},{color.G},{color.B}), ");
            }

            Console.WriteLine();
        }
    }
}
