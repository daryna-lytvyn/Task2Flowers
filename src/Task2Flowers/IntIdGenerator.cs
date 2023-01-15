using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class IntIdGenerator
    {
        private int value;

        public IntIdGenerator()
        {
            this.value = 1;
        }

        public IntIdGenerator(int initialValue)
        {
            this.value = initialValue;
        }
        public int GetNextValue()
        {
            return value++;
        }
    }
}
