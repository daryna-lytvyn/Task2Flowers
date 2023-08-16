using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Task2Flowers.Entities;
using Task2Flowers.Entities.Products;
using Task2Flowers.Entities.Supplay;
using Task2Flowers.Entities.Types;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Interfeses.Services.ISupplayService;
using Task2Flowers.Menus.Commands;
using Task2Flowers.Presenters;
using Task2Flowers.Presenters.SupplayPresenter;
using Task2Flowers.Services;
using Task2Flowers.Services.SupplayServise;
using Task2Flowers.Storages;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddStorages(this IServiceCollection services)
    {
        var entitySubclasses = EntitySubclasses();

        foreach (var type in entitySubclasses)
        {
            var iStorageType = typeof(IStorage<>).MakeGenericType(type);
            var storageType = typeof(JSONFileStorage<>).MakeGenericType(type);
            var loggerType = typeof(ILogger<>).MakeGenericType(storageType);

            services.AddSingleton(iStorageType, provider =>
            {
                var typeName = type.Name;
                var filename = typeName + "Storage";
                var logger = provider.GetRequiredService(loggerType);

                return Activator.CreateInstance(storageType, filename, logger);
            });
        }

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection service)
    {
        service.AddSingleton<IMyColorService, MyColorService>();
        service.AddSingleton<IFlowerKindService, FlowerKindService>();
        service.AddSingleton<IFlowerService, FlowerService>();
        service.AddSingleton<IFlowerBundleService, FlowerBundleService>();
        service.AddSingleton<IAdditionalProductTypeService, AdditionalProductTypeService>();
        service.AddSingleton<IAdditionalProductService, AdditionalProductService>();
        service.AddSingleton<IFlowerPackageTypeService, FlowerPackageTypeService>();
        service.AddSingleton<IFlowerPackageService, FlowerPackageService>();
        service.AddSingleton<ISupplayService, SupplayService>();

        return service;
    }

    public static IServiceCollection AddPresenters(this IServiceCollection service)
    {
        service.AddSingleton<IPresenter<MyColor>, MyColorPresenter>();
        service.AddSingleton<IPresenter<AdditionalProductType>, AdditionalProductTypePresenter>();
        service.AddSingleton<IPresenter<AdditionalProduct>, AdditionalProductPresenter>();
        service.AddSingleton<IPresenter<FlowerPackageType>, FlowerPackageTypePresenter>();
        service.AddSingleton<IPresenter<FlowerPackage>, FlowerPackagePresenter>();
        service.AddSingleton<IPresenter<FlowerKind>, FlowerKindPresenter>();
        service.AddSingleton<IPresenter<Flower>, FlowerPresenter>();
        service.AddSingleton<IPresenter<FlowerBundle>, FlowerBundlePresenter>();
        service.AddSingleton<IPresenter<Supplay>, SupplayPresenter>();

        return service;
    }

    public static IServiceCollection AddCommands(this IServiceCollection service, 
        IDictionary<Type, (string, string)> descriptionDictionary)
    {

        foreach (var type in descriptionDictionary)
        {
            var iPresenterType = typeof(IPresenter<>).MakeGenericType(type.Key);
            var description = descriptionDictionary[type.Key];

            var inputCommandType = typeof(InputCommand<>).MakeGenericType(type.Key);
            RegisterCommand(service, inputCommandType, type.Key, description.Item1);

            var printCommandType = typeof(PrintCommand<>).MakeGenericType(type.Key);
            RegisterCommand(service, printCommandType, type.Key, description.Item2);
        }

        return service;
    }

    private static void RegisterCommand(IServiceCollection services, Type commandType, Type type, string description)
    {
        var iPresenterType = typeof(IPresenter<>).MakeGenericType(type);

        services.AddSingleton<ICommand>(provider =>
        {
            var presenter = provider.GetRequiredService(iPresenterType);

            return (ICommand)Activator.CreateInstance(commandType, description, presenter);
        });
    }

    private static IList<Type> EntitySubclasses()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();
        var entitySubclasses = types.Where(t => t.IsSubclassOf(typeof(Entity)) && !t.IsAbstract);

        return entitySubclasses.ToList();
    }
}