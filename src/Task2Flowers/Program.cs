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
            var idFlowerBundles = new IntIdGenerator();
            var idBundles = new IntIdGenerator();
            var idSupplays = new IntIdGenerator();

            var kindsOfFlower = new List<FlowerKind>()
            {
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Роза"),
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Гортензия"),
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Ромашка")
            };

            var flowerPackegeTypes = new List<FlowerPackageType>()
            {
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Круглая шляпная коробка"),
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Корейская пленка")
            };

            var additionalProductsTypes = new List<AdditionalProductType>()
            {
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Ваза"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Сладость"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Открытка"),
            };

            var flowers = new List<Flower>()
            {
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Magical Pearl", Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic",Color.DarkRed),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", Color.BlueViolet),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio",Color.LemonChiffon),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса",Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",Color.Honeydew)
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

            var flowerBundles = new List<FlowerBundle>()
            {
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[5], 25, 60),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 35, 90),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 15, 70),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[0], 25, 60),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[3], 45, 40),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[4], 25, 65)
            };

            var bundles = new List<Bundle>()
            {
                new Bundle(idBundles.GetNextValue(), 1,flowerBundles[0],7),
                new Bundle(idBundles.GetNextValue(), 1,flowerBundles[1],4),
                new Bundle(idBundles.GetNextValue(), 1,flowerBundles[2],12),
                new Bundle(idBundles.GetNextValue(), 1,additionalProducts[0],50),
                new Bundle(idBundles.GetNextValue(), 1,flowerPackages[0],5),
                new Bundle(idBundles.GetNextValue(), 2,flowerPackages[1],10),
                new Bundle(idBundles.GetNextValue(), 2,flowerBundles[3],9),
                new Bundle(idBundles.GetNextValue(), 2,flowerBundles[4],5),
                new Bundle(idBundles.GetNextValue(), 2,flowerBundles[5],10)
            };

            var supplays = new List<Supplay>() {
                new Supplay(idSupplays.GetNextValue(), bundles.Where(p=>p.SupplayId == 1).ToList() ,  DateTime.Parse("2022-11-15")),
                new Supplay(idSupplays.GetNextValue(), bundles.Where(p=>p.SupplayId == 2).ToList(),  DateTime.Parse("2022-11-16"))

            };

            var storageKindOfFlower = new Storage<FlowerKind>(kindsOfFlower, idKindsOfFlower);
            var storageFlowerPackegeTypes = new Storage<FlowerPackageType>(flowerPackegeTypes, idFlowerPackegeTypes);
            var storageAdditionalProductTypes = new Storage<AdditionalProductType>(additionalProductsTypes, idAdditionalProductsTypes);
            var storageFlower = new Storage<Flower>(flowers, idFlowers);
            var storageFlowerBundles = new Storage<FlowerBundle>(flowerBundles, idFlowerBundles);
            var storageFlowerPackege = new Storage<FlowerPackage>(flowerPackages, idFlowerPackages);
            var storageAdditionalProduct = new Storage<AdditionalProduct>(additionalProducts, idAdditionalProducts);
            var storageBundle = new Storage<Bundle>(bundles, idBundles);
            var storageSupplay = new Storage<Supplay>(supplays, idSupplays);


            var menu = new MenuItems(storageKindOfFlower, storageFlowerPackegeTypes, storageFlower, 
                storageAdditionalProductTypes, storageFlowerBundles, storageFlowerPackege, storageAdditionalProduct, storageBundle, storageSupplay);

            menu.MainMenu();

            Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить вид цветка (нажмите 1)." +
                   "\n\t\t - Добавить цветок (нажмите 2).\n\t\t - Добавить тип доп.товара (нажмите 3)." +
                   "\n\t\t - Добавить доп.товар (нажмите 4).\n\t\t - Добавить тип цветочной упаковки (нажмите 5)." +
                   "\n\t\t - Добавить цветочную упаковку (нажмите 6).\n\t\t - Добавить поставку (нажмите 7)." +
                   "\n\t\t - Просмотреть виды цветов (нажмите 8).\n\t\t - Просмотреть цветы (нажмите 9)." +
                   "\n\t\t- Просмотреть сгрупированные по виду цветы(нажмите 10)\n\t\t - Просмотреть тип доп.товара (нажмите 11)." +
                   "\n\t\t - Просмотреть доп.товар (нажмите 12).\n\t\t - Просмотреть тип цветочной упаковки (нажмите 13)." +
                   "\n\t\t - Просмотреть цветочную упаковку (нажмите 14).\n\t\t - Просмотреть поставки (нажмите 15)." +
                   "\n\t\t - Завершить работу(любое другое число)");

        }
    }
}
