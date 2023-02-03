using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class Bundle
    {
        public int Id { get; }

        public int IdOfSupplay { get; }

        public Product Product { get; }

        public int Count { get; }


        public Bundle(int id, int idOfSupplay, Product product, int count)
        {
            this.Id = id;
            this.IdOfSupplay = idOfSupplay;
            this.Product = product;
            this.Count = count;

        }
    }
}
