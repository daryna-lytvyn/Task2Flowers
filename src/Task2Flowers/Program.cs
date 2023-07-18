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
    using Task2Flowers.Entities;

    class Program
    {
        static void Main(string[] args)
        {
            var idKindsOfFlower = new IntIdGenerator();
            var kindsOfFlower = new List<FlowerKind>()
            {
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Роза"),
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Гортензия"),
                new FlowerKind(idKindsOfFlower.GetNextValue(), "Ромашка")
            };

            var storageKindOfFlower = new Storage<FlowerKind>(kindsOfFlower, idKindsOfFlower);

            var idFlowerPackegeTypes = new IntIdGenerator();
            var flowerPackegeTypes = new List<FlowerPackageType>()
            {
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Круглая шляпная коробка"),
                new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Корейская пленка")
            };
            
            var storageFlowerPackegeTypes = new Storage<FlowerPackageType>(flowerPackegeTypes, idFlowerPackegeTypes);

            var idAdditionalProductsTypes = new IntIdGenerator();
            var additionalProductsTypes = new List<AdditionalProductType>()
            {
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Ваза"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Сладость"),
                new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Открытка"),
            };

            var storageAdditionalProductTypes = new Storage<AdditionalProductType>(additionalProductsTypes, idAdditionalProductsTypes);


            var idColors = new IntIdGenerator();
            var colors = new List<MyColor>()
            {
                new MyColor(idColors.GetNextValue(),"Жемчужный", 235, 245, 240),
                new MyColor(idColors.GetNextValue(),"Темно-бордовый", 107, 3, 21),
                new MyColor(idColors.GetNextValue(),"Голубо-фиалковый", 152, 147, 219),
                new MyColor(idColors.GetNextValue(),"Нежно-лимонный", 224, 252, 182),
                new MyColor(idColors.GetNextValue(),"Белый", 255, 255, 255),
                new MyColor(idColors.GetNextValue(),"Бело-зеленый", 235, 255, 230),
                new MyColor(idColors.GetNextValue(),"Пудровый", 232, 216, 223),
                new MyColor(idColors.GetNextValue(),"Оливковый", 145, 171, 125),
            };

            var storage = new Storage<MyColor>(colors, idColors);

            var idFlowers = new IntIdGenerator();
            var flowers = new List<Flower>()
            {
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Magical Pearl", colors[0]),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic", colors[1]),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", colors[2]),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio", colors[3]),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса", colors[4]),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",colors[5])
            };

            var storageFlower = new Storage<Flower>(flowers, idFlowers);


            var idFlowerPackages = new IntIdGenerator();
            var flowerPackages = new List<FlowerPackage>()
            {
                new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[1], 60, 1000, colors[6], "бла бла бла"),
                new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[0], 40, 50, colors[7], "бла бла бла")
            };

            var storageFlowerPackege = new Storage<FlowerPackage>(flowerPackages, idFlowerPackages);


            var idAdditionalProducts = new IntIdGenerator();
            var additionalProducts = new List<AdditionalProduct>()
            {
                new AdditionalProduct(idAdditionalProducts.GetNextValue(), additionalProductsTypes[1], "Raffaello", colors[4], "Упаковка конфет весом 400 гр")
            };
         
            var storageAdditionalProduct = new Storage<AdditionalProduct>(additionalProducts, idAdditionalProducts);


            var idFlowerBundles = new IntIdGenerator();
            var flowerBundles = new List<FlowerBundle>()
            {
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[5], 25, 60),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 35, 90),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 15, 70),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[0], 25, 60),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[3], 45, 40),
                    new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[4], 25, 65)
            };
            
            var storageFlowerBundles = new Storage<FlowerBundle>(flowerBundles, idFlowerBundles);


            var idBundles1 = new IntIdGenerator();
            var bundles1 = new List<Bundle>()
            {
                new Bundle(idBundles1.GetNextValue(), flowerBundles[0],7),
                new Bundle(idBundles1.GetNextValue(), flowerBundles[1],4),
                new Bundle(idBundles1.GetNextValue(), flowerBundles[2],12),
                new Bundle(idBundles1.GetNextValue(), additionalProducts[0],50),
                new Bundle(idBundles1.GetNextValue(), flowerPackages[0],5)
               
            };


            var idBundles2 = new IntIdGenerator();
            var bundles2 = new List<Bundle>()
            {
                new Bundle(idBundles2.GetNextValue(), flowerPackages[1],10),
                new Bundle(idBundles2.GetNextValue(), flowerBundles[3],9),
                new Bundle(idBundles2.GetNextValue(), flowerBundles[4],5),
                new Bundle(idBundles2.GetNextValue(), flowerBundles[5],10)
            };

            var bundle1Storage = new Storage<Bundle>(bundles1, idBundles1);
            var bundle2Storage = new Storage<Bundle>(bundles2, idBundles2);


            var idSupplays = new IntIdGenerator();
            var supplays = new List<Supplay>() {
                new Supplay(idSupplays.GetNextValue(),bundle1Storage,  DateTime.Parse("2022-11-15")),
                new Supplay(idSupplays.GetNextValue(), bundle2Storage,  DateTime.Parse("2022-11-16"))

            };

            var storageSupplay = new Storage<Supplay>(supplays, idSupplays);

            


            var menu = new MenuItems();
            menu.AddOption()

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
