using System;

namespace Task2Flowers.Interfeses
{
    public interface ICommand
    {
        public String CommandName { get; }
        void Execute();
    }
}
