using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses
{
    interface IPresenter<T>
    {
        public T Input();
        public void Print();
    }
}
