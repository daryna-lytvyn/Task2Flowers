namespace Task2Flowers.Entities.Types
{

    public class Flower
    {
        public int Id { get; }
        public FlowerKind Kind { get; }
        public string Variety { get; }
        public MyColor Color { get; }


        public Flower(int id, FlowerKind kind, string variety, MyColor color)
        {
            this.Id = id;
            this.Kind = kind;
            this.Variety = variety;
            this.Color = color;
        }

    }
}