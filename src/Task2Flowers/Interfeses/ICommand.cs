using System;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses
{
    public interface ICommand
    {
        public String CommandName { get; }
        Task Execute();
    }
}
