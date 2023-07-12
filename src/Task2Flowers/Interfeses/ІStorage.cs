using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public interface IStorage <T>
    {
        public void Add(T element);
        public T Get(int id);
    }
}
