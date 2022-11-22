using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class MyStorage
    {
        public List<KindOfFlower> KindOfFlowers { get; }

        public List<Flower> Flowers { get; }

        public List<Supplay> Supplays { get; }

        public IntIdGenerator IdKindsOfFlower { get; }

        public IntIdGenerator IdFlowers { get; }

        public IntIdGenerator IdPackeges { get; }

        public IntIdGenerator IdSupplays { get; }

        public MyStorage()
        {
            this.KindOfFlowers = new List<KindOfFlower>();
            this.Flowers = new List<Flower>();
            this.Supplays = new List<Supplay>();

            this.IdKindsOfFlower = new IntIdGenerator();
            this.IdFlowers = new IntIdGenerator();
            this.IdPackeges = new IntIdGenerator();
            this.IdSupplays = new IntIdGenerator();
        }

        public MyStorage( List<KindOfFlower> kindOfFlowers, List<Flower> flowers, List<Supplay> supplays,
                          IntIdGenerator idKindsOfFlower, IntIdGenerator idFlowers, IntIdGenerator idPackeges, IntIdGenerator idSupplays )
        {
            this.KindOfFlowers = kindOfFlowers;
            this.Flowers = flowers;
            this.Supplays = supplays;

            this.IdKindsOfFlower = idKindsOfFlower;
            this.IdFlowers = idFlowers;
            this.IdPackeges = idPackeges;
            this.IdSupplays = idSupplays;
        }

        public void AddKindOfFlower(KindOfFlower kindOfFlower)
        {
            this.KindOfFlowers.Add(kindOfFlower);
        }

        public void AddFlower(Flower flower)
        {
            this.Flowers.Add(flower);
        }

        public void AddSuplay(Supplay supplay)
        {
            this.Supplays.Add(supplay);
        }

        public void AddPackageToSupplayById (Package package, int id)
        {
            var neededId = this.Supplays.FindIndex(x => x.Id == id);
            this.Supplays[neededId].FlowerPackeges.Add(package);

        }
    }
}
