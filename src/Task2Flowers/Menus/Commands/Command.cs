using System;
using System.Threading.Tasks;
using Task2Flowers.Interfeses;

namespace Task2Flowers.Menus.Commands
{
    public abstract class Command : ICommand
    {
        public String CommandName { get; }

        public Command(String commandName)
        {
            CommandName = commandName;
        }

        public virtual async Task Execute()
        {

        }

    }
}
