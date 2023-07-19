using System;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Menus.Commands
{
    public class PrintCommand<T> : Command
    {
        private readonly IPresenter<T> _presenter;

        public PrintCommand(String commandName, IPresenter<T> presenter) : base(commandName)
        {
            _presenter = presenter;
        }

        public override void Execute()
        {
            _presenter.Print();
        }
    }

}
