using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class IdGenerator
    {
        private int value = 1;

        public int GetNextValue()
        {
            return value++;
        } 
    }
}
