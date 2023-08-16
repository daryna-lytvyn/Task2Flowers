using System.Text.Json.Serialization;
using Task2Flowers.Entities.Types;

namespace Task2Flowers.Entities.Products
{
    public class FlowerPackage : Product
    {
        public FlowerPackageType Type { get; }

        public int Height { get; }

        public int Width { get; }

        public MyColor Color { get; }

        public string Description { get; }

        [JsonConstructor]
        public FlowerPackage(int id, FlowerPackageType type, int height, int width, MyColor color, string description) : base(id)
        {
            this.Type = type;
            this.Height = height;
            this.Width = width;
            this.Color = color;
            this.Description = description;
        }
    }
}
