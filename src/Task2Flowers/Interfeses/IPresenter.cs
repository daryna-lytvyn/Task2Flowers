using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses
{
    public interface IPresenter<T>
    {
        void Input();
        void Print();
    }
}
