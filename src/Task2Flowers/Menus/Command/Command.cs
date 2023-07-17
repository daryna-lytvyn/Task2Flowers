using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Menus.Command
{
    public abstract class Command : ICommand
    {
        public String CommandName { get; }

        public Command(String commandName)
        {
            CommandName = commandName;
        }

        virtual public void Execute()
        {

        }

    }
}
