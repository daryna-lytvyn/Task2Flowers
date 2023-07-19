namespace Task2Flowers.Entities.Products
{
    public abstract class Product
    {
        public int Id { get; }

        public Product(int id)
        {
            this.Id = id;
        }
    }
}
