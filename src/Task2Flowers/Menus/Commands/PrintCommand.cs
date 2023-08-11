using System;
using System.Threading.Tasks;
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

        public override async Task Execute()
        {
            await _presenter.PrintAsync();
        }
    }

}
