using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Menus.Command
{
    class PrintCommand<T> : Command
    {
        readonly IPresenter<T> _presenter;

        public PrintCommand(String commandName, IPresenter<T> presenter) : base(commandName)
        {
            _presenter = presenter;
        }
        public void Print()
        {
            _presenter.Print();
        }

        public override void Execute()
        {
            this.Print();
        }
    }
    
}
