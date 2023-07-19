namespace Task2Flowers.Entities.Types
{
    public class AdditionalProductType
    {
        public int Id { get; }

        public string Title { get; }

        public AdditionalProductType(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
