using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class IntIdGenerator
    {
        private int value = 1;

        public int GetNextValue()
        {
            return value++;
        } 
    }
}
