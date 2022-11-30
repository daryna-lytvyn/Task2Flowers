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
        public void Add(Storage<KindOfFlower> storageKindsOfFlower)
        {
            KindsOfFlowerPresenter kindsOfFlowerPresenter = new KindsOfFlowerPresenter();

            var kindOfFlower = kindsOfFlowerPresenter.Input(storageKindsOfFlower.IdGenerator);

            storageKindsOfFlower.Add(kindOfFlower);
        }

        public void Add(Storage<Flower> storageFlowers, Storage<KindOfFlower> storageKindsOfFlowers)
        {
            FlowerPresenter flowerPresenter = new FlowerPresenter();

            var flower = flowerPresenter.Input(storageFlowers.IdGenerator, storageKindsOfFlowers.Elements);

            storageFlowers.Add(flower);
        }


        public void Add(Storage<Supplay> storageSupplays, Storage<Package> storagePackages, Storage<Flower> storageFlowers)
        {
            PackegePresenter packegePresenter = new PackegePresenter();
            List<Package> packages = new List<Package>();
            var marker = true;
            var supplay = new Supplay(storageSupplays.IdGenerator.GetNextValue());
            var idOfSupplay = supplay.Id;


            do
            {
                var packegeInput2 = packegePresenter.InputForMany(storagePackages.IdGenerator, storageFlowers.Elements, idOfSupplay);
                packages.Add(packegeInput2.Item1);
                storagePackages.Add(packegeInput2.Item1);
                marker = packegeInput2.Item2;

            } while (marker);

            supplay.AddPackeges(packages);
            supplay.AddFinishDate(DateTime.Now);

            storageSupplays.Add(supplay);
        }

        public void Show(Storage<KindOfFlower> storageKindsOfFlower)
        {
            KindsOfFlowerPresenter kindsOfFlowerPresenter = new KindsOfFlowerPresenter();

            kindsOfFlowerPresenter.Print(storageKindsOfFlower.Elements);
        }

        public void Show(Storage<Flower> storageFlowers)
        {
            FlowerPresenter flowerPresenter = new FlowerPresenter();

            flowerPresenter.Print(storageFlowers.Elements);
        }

        public void ShowFlowersSortByKind(Storage<Flower> storageFlowers)
        {
            FlowerPresenter flowerPresenter = new FlowerPresenter();

            flowerPresenter.PrintSortByKind(storageFlowers.Elements);
        
        }
        public void Show(Storage<Package> storagePackage)
        {
            PackegePresenter packagePresenter = new PackegePresenter();

            packagePresenter.Print(storagePackage.Elements);
        }

        public void Show(Storage<Supplay> storageSupplays)
        {
            SupplayPresenter supplayPresenter = new SupplayPresenter();

            supplayPresenter.Print(storageSupplays.Elements);
        }
    }
}
