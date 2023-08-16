using System.Text.Json.Serialization;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Entities.Supplay
{
    public class Bundle
    {
        public Product Product { get; }

        public int Count { get; }

        [JsonConstructor]
        public Bundle(Product product, int count)
        {
            this.Product = product;
            this.Count = count;
        }
    }
}
