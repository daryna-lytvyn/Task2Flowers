using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class MenuItems
    {
        private readonly Storage<KindOfFlower> storageKindsOfFlower;

        private readonly KindsOfFlowerPresenter kindsOfFlowerPresenter;

        private readonly Storage<Flower> storageFlowers;

        private readonly FlowerPresenter flowerPresenter;

        private readonly Storage<Package> storagePackages;

        private readonly PackagePresenter packegePresenter;

        private readonly Storage<Supplay> storageSupplays;

        private readonly SupplayPresenter supplayPresenter;

        public MenuItems(Storage<KindOfFlower> storageKindsOfFlower, Storage<Flower> storageFlowers, Storage<Package> storagePackages, Storage<Supplay> storageSupplays)
        {
            this.storageKindsOfFlower = storageKindsOfFlower;
            this.kindsOfFlowerPresenter = new KindsOfFlowerPresenter();

            this.storageFlowers = storageFlowers;
            this.flowerPresenter = new FlowerPresenter();

            this.storagePackages = storagePackages;
            this.packegePresenter = new PackagePresenter();

            this.storageSupplays = storageSupplays;
            this.supplayPresenter = new SupplayPresenter();
        }
        public KindOfFlower AddKindOfFlower()
        {
            var kindOfFlower = this.kindsOfFlowerPresenter.Input(this.storageKindsOfFlower.IdGenerator);

            this.storageKindsOfFlower.Add(kindOfFlower);

            return kindOfFlower;
        }

        public Flower AddFlower()
        {
            var flower = flowerPresenter.Input(this.storageFlowers.IdGenerator, this.storageKindsOfFlower.Elements);

            this.storageFlowers.Add(flower);

            return flower;
        }

        public Package AddPackage(int idOfSupplay)
        {
            var package = packegePresenter.Input(this.storagePackages.IdGenerator, this.storageFlowers.Elements, idOfSupplay);

            this.storagePackages.Add(package);

            return package;
        }

        public Supplay AddSupplay()
        {
            List<Package> packages = new List<Package>();
            var marker = true;
            var supplay = new Supplay(this.storageSupplays.IdGenerator.GetNextValue());
            var idOfSupplay = supplay.Id;

            do
            {
                var packageInput2 = packegePresenter.InputForMany(this.storagePackages.IdGenerator, this.storageFlowers.Elements, idOfSupplay);
                packages.Add(packageInput2.Item1);
                this.storagePackages.Add(packageInput2.Item1);
                marker = packageInput2.Item2;

            } while (marker);

            supplay.AddPackeges(packages);
            supplay.AddFinishDate(DateTime.Now);

            this.storageSupplays.Add(supplay);

            return supplay;
        }

        public void ShowKindsOfFlower()
        {
            this.kindsOfFlowerPresenter.Print(this.storageKindsOfFlower.Elements);
        }

        public void ShowFlowers()
        {
            this.flowerPresenter.Print(storageFlowers.Elements);
        }

        public void ShowFlowersSortByKind()
        {
            this.flowerPresenter.PrintSortByKind(storageFlowers.Elements);
        }
        public void ShowPackages()
        {
            this.packegePresenter.Print(this.storagePackages.Elements);
        }

        public void ShowSupplays()
        {
            this.supplayPresenter.Print(this.storageSupplays.Elements);
        }
    }
}
