using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Menus.Commands
{
    public class InputCommand<T>: Command
    {
        private readonly IPresenter<T> _presenter;

        public InputCommand(String commandName, IPresenter<T> presenter) : base(commandName)
        {
            _presenter = presenter;
        }

        public override void Execute()
        {
            _presenter.Input();
        }
    }
}
