using System.Text.Json.Serialization;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Entities.Products
{
    public class FlowerBundle : Product
    {
        public Flower Flower { get; }
        public int CountOfFlower { get; }
        public int Height { get; }

        [JsonConstructor]
        public FlowerBundle(int id, Flower flower, int countOfFlower, int height) : base(id)
        {
            this.Flower = flower;
            this.CountOfFlower = countOfFlower;
            this.Height = height;
        }
    }
}
