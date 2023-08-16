using System.Text.Json.Serialization;

namespace Task2Flowers.Entities.Products
{
    [JsonDerivedType(typeof(AdditionalProduct),0)]
    [JsonDerivedType(typeof(FlowerBundle),1)]
    [JsonDerivedType(typeof(FlowerPackage),2)]

    public abstract class Product: Entity
    {
        [JsonConstructor]
        public Product(int id)
        {
            this.Id = id;
        }
    }
}
