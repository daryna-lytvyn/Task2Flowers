using System;
using System.Collections.Generic;
using Task2Flowers.Generators;
using Task2Flowers.Menus.Commands;
using Task2Flowers.Presenters;

namespace Task2Flowers.Menus
{
    public class MenuItems
    {
        private readonly Dictionary<int, Command> _options;
        private readonly IntIdGenerator _intIdGenerator;

        public MenuItems()
        {
            _options = new Dictionary<int, Command>();
            _intIdGenerator = new IntIdGenerator();
        }

        public MenuItems(Dictionary<int, Command> options, IntIdGenerator intIdGenerator)
        {
            _options = options ?? throw new ArgumentNullException(nameof(options));
            _intIdGenerator = intIdGenerator ?? throw new ArgumentNullException(nameof(intIdGenerator));
        }

        public void AddOption(Command command)
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

        public void MainMenu()
        {
            Console.WriteLine("Что вы хотите сделать? (Что бы вийти из меню нажмите 0)");

            this.PrintOption();

            var marker = true;
            do
            {
                int value = IntPresenter.Input(0, _intIdGenerator.GetCurrentValue());

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


