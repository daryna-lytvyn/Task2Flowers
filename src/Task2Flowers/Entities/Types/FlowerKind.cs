namespace Task2Flowers.Entities.Types
{
    public class FlowerKind
    {
        public int Id { get; }

        public string Title { get; }

        public FlowerKind(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
