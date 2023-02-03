using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Task2Flowers
{
    using System.Drawing;
    class Program
    {
        static void Main(string[] args)
        {
            var idKindsOfFlower = new IntIdGenerator();
            var idFlowerPackegeTypes = new IntIdGenerator();
            var idAdditionalProductsTypes = new IntIdGenerator();
            var idFlowers = new IntIdGenerator();
            var idFlowerPackages = new IntIdGenerator();
            var idAdditionalProducts = new IntIdGenerator();
            var idBundles = new IntIdGenerator();
            var idSupplays = new IntIdGenerator();

            var kindsOfFlower = new List<KindOfFlower>()
            {
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Роза"),
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Гортензия"),
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Ромашка")
            };

            var flowerPackegeTypes = new List<FlowerPackageType>()
            {
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Круглая шляпная коробка"),
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Корейская пленка")
            };

            var additionalProductsTypes = new List<AdditionalProductType>()
            {
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Ваза"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Сладкое"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Открытка"),
            };

            var flowers = new List<Flower>()
            {
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Magical Pearl", Color.White,"описание к Magical Pearl"),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic",Color.DarkRed,"описание к Black Magic"),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", Color.BlueViolet,"описание к Anabell"),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio",Color.LemonChiffon,"описание к Kerio"),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса",Color.White,"описание к Северная принцесса"),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",Color.Honeydew,"описание к LaPerla")
            };

            var flowerPackages = new List<FlowerPackage>()
            {
                new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[1], 60, 1000, Color.LightPink, "бла бла бла"),
                new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[0], 40, 50, Color.Olive, "бла бла бла")
            };

            var additionalProducts = new List<AdditionalProduct>()
            {
                new AdditionalProduct(idAdditionalProducts.GetNextValue(), additionalProductsTypes[1], "Raffaello", Color.White, "Упаковка конфет весом 400 гр")
            };

            var bundles = new List<Bundle>()
            {
                    new FlowerBundle(idBundles.GetNextValue(), 1, flowers[5], 120, 60),
                    new FlowerBundle(idBundles.GetNextValue(), 1, flowers[1], 105, 90),
                    new FlowerBundle(idBundles.GetNextValue(), 1, flowers[1], 225, 70),
                    new FlowerBundle(idBundles.GetNextValue(), 1, flowers[0], 25, 60),
                    new FlowerBundle(idBundles.GetNextValue(), 2, flowers[3], 170, 40),
                    new FlowerBundle(idBundles.GetNextValue(), 2, flowers[4], 235, 65)
            };



            var supplays = new List<Supplay>() {
                new Supplay(idSupplays.GetNextValue(), bundles.Select(p =>p).Where(p=>p.IdOfSupplay == 1).ToList() ,  DateTime.Parse("2022-11-15")),
                new Supplay(idSupplays.GetNextValue(), bundles.Select(p =>p).Where(p=>p.IdOfSupplay == 2).ToList(),  DateTime.Parse("2022-11-16"))

            };

            var storageKindOfFlower = new Storage<KindOfFlower>(kindsOfFlower, idKindsOfFlower);
            var storageFlowerPackegeType = new Storage<FlowerPackageType>(flowerPackegeTypes, idFlowerPackegeTypes);
            var storageAdditionalProductsType = new Storage<AdditionalProductType>(additionalProductsTypes, idAdditionalProductsTypes);
            var storageFlower = new Storage<Flower>(flowers, idFlowers);
            var storageFlowerPackege = new Storage<FlowerPackage>(flowerPackages, idFlowerPackages);
            var storageAdditionalProduct = new Storage<AdditionalProduct>(additionalProducts, idAdditionalProducts);
            var storageBundle = new Storage<Bundle>(bundles, idBundles);
            var storageSupplay = new Storage<Supplay>(supplays, idSupplays);


            var menu = new MenuItems(storageKindOfFlower, storageFlower, storageBundle, storageSupplay);

            menu.MainMenu();

        }
    }
}
