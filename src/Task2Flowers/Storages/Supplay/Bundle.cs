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

        public int SupplayId { get; }

        public Product Product { get; }

        public int Count { get; }


        public Bundle(int id, int supplayId, Product product, int count)
        {
            this.Id = id;
            this.SupplayId = supplayId;
            this.Product = product;
            this.Count = count;

        }
    }
}
