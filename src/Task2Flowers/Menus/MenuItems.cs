using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Menus.Command;
using Task2Flowers.Presenters;

namespace Task2Flowers
{
    public class MenuItems
    {
        readonly Dictionary<int, Command> _options;

        public MenuItems()
        {
            _options = new Dictionary<int, Command>();
        }

        public MenuItems(Dictionary<int, Command> options)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        public void AddOption(int commandNumber, Command command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _options.Add(commandNumber, command);
        }

        public void RemoveOption(int commandNumber)
        {
            
            _options.Remove(commandNumber);
        }
        public void PrintOption()
        {
            foreach (var option in _options)
            {
                Console.WriteLine($"\t\t{option.Key}. {option.Value.CommandName}.");
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("Что вы хотите сделать?");

            this.PrintOption();

            var marker = true;
            do
            {
                int value = IntPresenter.Input();
                
                if (_options.TryGetValue(value, out var command))
                {
                    command.Execute();
                }
                else
                {
                    marker = false;
                }

            } while (marker);
        }
    }
}


