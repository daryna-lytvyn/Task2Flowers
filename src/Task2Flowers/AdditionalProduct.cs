using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    class AdditionalProduct : Product
    {
        public AdditionalProductType Type { get; }
        public string Title { get; }


        public AdditionalProduct(int id, AdditionalProductType type, string title, Color color, string description ): base(id, color, description)
        {
            this.Title = title;
            this.Type = type;
        }
    }
}
