using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;
using Task2Flowers.Menus.Commands;
using Task2Flowers.Presenters;

namespace Task2Flowers.Menus
{
    public class MenuItems
    {
        private readonly Dictionary<int, ICommand> _options;
        private readonly IntIdGenerator _intIdGenerator;

        public MenuItems(IntIdGenerator intIdGenerator)
        {
            _options = new Dictionary<int, ICommand>();
            _intIdGenerator = intIdGenerator;
        }

        public MenuItems(Dictionary<int, ICommand> options, IntIdGenerator intIdGenerator)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _intIdGenerator = intIdGenerator ?? throw new ArgumentNullException(nameof(intIdGenerator));
        }

        public void AddOption(ICommand command)
        {
            if (command is null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _options.Add(_intIdGenerator.GetNextValue(), command);
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

        public async Task MainMenu()
        {
            var marker = true;
            do
            {
                Console.WriteLine("Что вы хотите сделать? (Что бы вийти из меню нажмите 0)");
                this.PrintOption();
                int value = IntPresenter.Input(0, _intIdGenerator.GetCurrentValue());

                if (!_options.TryGetValue(value, out var command))
                {
                    marker = false;
                }
                else
                {
                    await command.Execute();
                }

            } while (marker);
        }
    }
}


