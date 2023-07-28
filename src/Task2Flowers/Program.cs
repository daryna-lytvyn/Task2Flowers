using System;
using System.Collections.Generic;

namespace Task2Flowers
{
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using Task2Flowers.Entities;
    using Task2Flowers.Entities.Products;
    using Task2Flowers.Entities.Supplay;
    using Task2Flowers.Entities.Types;
    using Task2Flowers.Generators;
    using Task2Flowers.Interfeses;
    using Task2Flowers.Interfeses.Services;
    using Task2Flowers.Interfeses.Services.ISupplayService;
    using Task2Flowers.Menus;
    using Task2Flowers.Menus.Commands;
    using Task2Flowers.Presenters;
    using Task2Flowers.Presenters.SupplayPresenter;
    using Task2Flowers.Services;
    using Task2Flowers.Services.SupplayServise;
    using Task2Flowers.Storages;

    class Program
    {
        static void Main(string[] args)
        {
            //var idKindsOfFlower = new IntIdGenerator();
            //var kindsOfFlower = new List<FlowerKind>()
            //{
            //    new FlowerKind(idKindsOfFlower.GetNextValue(), "Роза"),
            //    new FlowerKind(idKindsOfFlower.GetNextValue(), "Гортензия"),
            //    new FlowerKind(idKindsOfFlower.GetNextValue(), "Ромашка")
            //};

            //var storageKindOfFlower = new Storage<FlowerKind>(kindsOfFlower, idKindsOfFlower);

            //var idFlowerPackegeTypes = new IntIdGenerator();
            //var flowerPackegeTypes = new List<FlowerPackageType>()
            //{
            //    new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Круглая шляпная коробка"),
            //    new FlowerPackageType(idFlowerPackegeTypes.GetNextValue(), "Корейская пленка")
            //};

            //var storageFlowerPackegeTypes = new Storage<FlowerPackageType>(flowerPackegeTypes, idFlowerPackegeTypes);

            //var idAdditionalProductsTypes = new IntIdGenerator();
            //var additionalProductsTypes = new List<AdditionalProductType>()
            //{
            //    new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Ваза"),
            //    new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Сладость"),
            //    new AdditionalProductType(idAdditionalProductsTypes.GetNextValue(), "Открытка"),
            //};

            //var storageAdditionalProductTypes = new Storage<AdditionalProductType>(additionalProductsTypes, idAdditionalProductsTypes);


            //var idColors = new IntIdGenerator();
            //var colors = new List<MyColor>()
            //{
            //    new MyColor("Жемчужный", 235, 245, 240),
            //    new MyColor("Темно-бордовый", 107, 3, 21),
            //    new MyColor("Голубо-фиалковый", 152, 147, 219),
            //    new MyColor("Нежно-лимонный", 224, 252, 182),
            //    new MyColor("Бело-зеленый", 235, 255, 230),
            //    new MyColor("Пудровый", 232, 216, 223),
            //    new MyColor("Оливковый", 145, 171, 125),
            //};

            //var storage = new Storage<MyColor>(colors, idColors);

            //var idFlowers = new IntIdGenerator();
            //var flowers = new List<Flower>()
            //{
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Magical Pearl", colors[0]),
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic", colors[1]),
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", colors[2]),
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio", colors[3]),
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса", MyColor.White),
            //    new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",colors[4])
            //};

            //var storageFlower = new Storage<Flower>(flowers, idFlowers);


            //var idFlowerPackages = new IntIdGenerator();
            //var flowerPackages = new List<FlowerPackage>()
            //{
            //    new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[1], 60, 1000, colors[5], "бла бла бла"),
            //    new FlowerPackage (idFlowerPackages.GetNextValue(), flowerPackegeTypes[0], 40, 50, colors[6], "бла бла бла")
            //};

            //var storageFlowerPackege = new Storage<FlowerPackage>(flowerPackages, idFlowerPackages);


            //var idAdditionalProducts = new IntIdGenerator();
            //var additionalProducts = new List<AdditionalProduct>()
            //{
            //    new AdditionalProduct(idAdditionalProducts.GetNextValue(), additionalProductsTypes[1], "Raffaello", MyColor.White, "Упаковка конфет весом 400 гр")
            //};

            //var storageAdditionalProduct = new Storage<AdditionalProduct>(additionalProducts, idAdditionalProducts);


            //var idFlowerBundles = new IntIdGenerator();
            //var flowerBundles = new List<FlowerBundle>()
            //{
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[5], 25, 60),
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 35, 90),
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[1], 15, 70),
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[0], 25, 60),
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[3], 45, 40),
            //        new FlowerBundle(idFlowerBundles.GetNextValue(), flowers[4], 25, 65)
            //};

            //var storageFlowerBundles = new Storage<FlowerBundle>(flowerBundles, idFlowerBundles);

            //var bundles1 = new List<Bundle>()
            //{
            //    new Bundle(flowerBundles[0],7),
            //    new Bundle(flowerBundles[1],4),
            //    new Bundle(flowerBundles[2],12),
            //    new Bundle(additionalProducts[0],50),
            //    new Bundle(flowerPackages[0],5)

            //};

            //var bundles2 = new List<Bundle>()
            //{
            //    new Bundle(flowerPackages[1],10),
            //    new Bundle(flowerBundles[3],9),
            //    new Bundle(flowerBundles[4],5),
            //    new Bundle(flowerBundles[5],10)
            //};



            //var idSupplays = new IntIdGenerator();
            //var supplays = new List<Supplay>() {
            //    new Supplay(idSupplays.GetNextValue(), bundles1.AsReadOnly(),  DateTime.Parse("2022-11-15")),
            //    new Supplay(idSupplays.GetNextValue(), bundles2.AsReadOnly(),  DateTime.Parse("2022-11-16"))

            //};

            //var storageSupplays = new Storage<Supplay>(supplays, idSupplays);

            var services = new ServiceCollection();

            services.AddTransient<IntIdGenerator>();

            services.AddSingleton(typeof(IStorage<>), typeof(Storage<>));

            services.AddSingleton<IMyColorService, MyColorService>();
            services.AddSingleton<IFlowerKindService, FlowerKindService>();
            services.AddSingleton<IFlowerService, FlowerService>();
            services.AddSingleton<IFlowerBundleService, FlowerBundleService>();
            services.AddSingleton<IAdditionalProductTypeService, AdditionalProductTypeService>();
            services.AddSingleton<IAdditionalProductService, AdditionalProductService>();
            services.AddSingleton<IFlowerPackageTypeService, FlowerPackageTypeService>();
            services.AddSingleton<IFlowerPackageService, FlowerPackageService>();
            services.AddSingleton<ISupplayService, SupplayService>();

            services.AddSingleton<IPresenter<MyColor>, MyColorPresenter>();
            services.AddSingleton<IPresenter<AdditionalProductType>, AdditionalProductTypePresenter>();
            services.AddSingleton<IPresenter<AdditionalProduct>, AdditionalProductPresenter>();
            services.AddSingleton<IPresenter<FlowerPackageType>, FlowerPackageTypePresenter>();
            services.AddSingleton<IPresenter<FlowerPackage>, FlowerPackagePresenter>();
            services.AddSingleton<IPresenter<FlowerKind>, FlowerKindPresenter>();
            services.AddSingleton<IPresenter<Flower>, FlowerPresenter>();
            services.AddSingleton<IPresenter<FlowerBundle>, FlowerBundlePresenter>();
            services.AddSingleton<IPresenter<Supplay>, SupplayPresenter>();


            services.AddSingleton<ICommand>(provider =>
            {
                var storage = provider.GetRequiredService<IStorage<MyColor>>();
                var servise = provider.GetRequiredService<IMyColorService>();
                var presenter = provider.GetRequiredService<IPresenter<MyColor>>();
                return new InputCommand<MyColor>("Добавить цвет", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<MyColor>>();
                return new PrintCommand<MyColor>("Просмотреть цвета", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerKind>>();
                return new InputCommand<FlowerKind>("Добавить вид цветка", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerKind>>();
                return new PrintCommand<FlowerKind>("Просмотреть виды цветов", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<Flower>>();
                return new InputCommand<Flower>("Добавить цветок", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<Flower>>();
                return new PrintCommand<Flower>("Просмотреть цветы", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerBundle>>();
                return new InputCommand<FlowerBundle>("Добавить пачку цветов", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerBundle>>();
                return new PrintCommand<FlowerBundle>("Просмотреть пачки с цветами", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerPackageType>>();
                return new InputCommand<FlowerPackageType>("Добавить тип цветочной упаковки ", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerPackageType>>();
                return new PrintCommand<FlowerPackageType>("Просмотреть типы цветочной упаковки", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerPackage>>();
                return new InputCommand<FlowerPackage>("Добавить цветочную упаковку ", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<FlowerPackage>>();
                return new PrintCommand<FlowerPackage>("Просмотреть цветочную упаковку", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<AdditionalProductType>>();
                return new InputCommand<AdditionalProductType>("Добавить тип доп.товара ", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<AdditionalProductType>>();
                return new PrintCommand<AdditionalProductType>("Просмотреть типы доп.товара", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<AdditionalProduct>>();
                return new InputCommand<AdditionalProduct>("Добавить доп.товар", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<AdditionalProduct>>();
                return new PrintCommand<AdditionalProduct>("Просмотреть весь доп.товар", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<Supplay>>();
                return new InputCommand<Supplay>("Добавить поставку", presenter);
            });

            services.AddSingleton<ICommand>(provider =>
            {
                var presenter = provider.GetRequiredService<IPresenter<Supplay>>();
                return new PrintCommand<Supplay>("Просмотреть поставки", presenter);
            });

            services.AddSingleton<MenuItems>(provider =>
            {
                var intIdGenerator = provider.GetRequiredService<IntIdGenerator>();
                var commands = provider.GetServices<ICommand>();
                var commandsDictionary = commands.ToDictionary(command => intIdGenerator.GetNextValue(), command => command);

                return new MenuItems(commandsDictionary, intIdGenerator);
            });

            var provider = services.BuildServiceProvider();

            var menu = provider.GetService<MenuItems>();

            menu.MainMenu();

            //var serviseSupplay = new SupplayService(storageSupplays);
            //services.AddSingleton<SupplayService>(serviseSupplay);

            //services.AddSingleton<SupplayPresenter>(_ => new SupplayPresenter(serviseSupplay));




            //var menu = new MenuItems();

            //menu.MainMenu();

            //Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить вид цветка (нажмите 1)." +
            //       "\n\t\t - Добавить цветок (нажмите 2).\n\t\t - Добавить тип доп.товара (нажмите 3)." +
            //       "\n\t\t - Добавить доп.товар (нажмите 4).\n\t\t - Добавить тип цветочной упаковки (нажмите 5)." +
            //       "\n\t\t - Добавить цветочную упаковку (нажмите 6).\n\t\t - Добавить поставку (нажмите 7)." +
            //       "\n\t\t - Просмотреть виды цветов (нажмите 8).\n\t\t - Просмотреть цветы (нажмите 9)." +
            //       "\n\t\t- Просмотреть сгрупированные по виду цветы(нажмите 10)\n\t\t - Просмотреть тип доп.товара (нажмите 11)." +
            //       "\n\t\t - Просмотреть доп.товар (нажмите 12).\n\t\t - Просмотреть тип цветочной упаковки (нажмите 13)." +
            //       "\n\t\t - Просмотреть цветочную упаковку (нажмите 14).\n\t\t - Просмотреть поставки (нажмите 15)." +
            //       "\n\t\t - Завершить работу(любое другое число)");

        }
    }
}
