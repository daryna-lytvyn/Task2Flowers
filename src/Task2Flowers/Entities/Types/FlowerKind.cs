using System.Text.Json.Serialization;

namespace Task2Flowers.Entities.Types
{
    public class FlowerKind : Entity
    {

        public string Title { get; }

        [JsonConstructor]
        public FlowerKind(int id, string title)
        {
            this.Id = id;
            this.Title = title;
        }
    }
}
