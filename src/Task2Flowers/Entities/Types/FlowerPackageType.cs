namespace Task2Flowers.Entities.Types
{
    public class FlowerPackageType : Entity
    {

        public string Title { get; }

        public FlowerPackageType(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
