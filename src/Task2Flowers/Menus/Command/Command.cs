using System.Windows.Input;

namespace Task2Flowers.Commands
{
    public class abstract Command : ICommand
    {
        public string CommandName { get; } = "Добавить вид цветка.";

        public void Execute()
        {
            
        }
    }
}