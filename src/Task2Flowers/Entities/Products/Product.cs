using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public abstract class Product
    {
        public int Id { get; }

        public Product (int id)
        {
            this.Id = id;     
        }
    }
}
