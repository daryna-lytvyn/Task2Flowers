using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Entities;

namespace Task2Flowers
{
    public class AdditionalProduct : Product
    {
        public AdditionalProductType Type { get; }
        public string Title { get; }
        public MyColor Color { get; }
        public string Desctiption { get; }

        public AdditionalProduct(int id, AdditionalProductType type, string title, MyColor color, string description ): base(id)
        {
            this.Title = title;
            this.Type = type;
            this.Color = color;
            this.Desctiption = description;
        }
    }
}
