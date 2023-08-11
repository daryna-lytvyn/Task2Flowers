using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects.Supplay;
using Task2Flowers.Entities.Products;
using Task2Flowers.Entities.Supplay;
using Task2Flowers.Interfeses;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Interfeses.Services.ISupplayService;
using Task2Flowers.Services.SupplayServise;
using Task2Flowers.Storages;

namespace Task2Flowers.Presenters.SupplayPresenter
{
    public class SupplayPresenter : IPresenter<Supplay>
    {
        private readonly ISupplayService _supplayService;

        private readonly IFlowerBundleService _flowerBundleServise;
        private readonly IAdditionalProductService _additionalProductServise;
        private readonly IFlowerPackageService _flowerPackageServise;

        public SupplayPresenter(ISupplayService supplayService, IFlowerBundleService flowerBundleServise,
                                    IAdditionalProductService additionalProductServise, IFlowerPackageService flowerPackageServise)
        {
            _supplayService = supplayService ?? throw new ArgumentNullException(nameof(flowerBundleServise));

            _flowerBundleServise = flowerBundleServise ?? throw new ArgumentNullException(nameof(flowerBundleServise));
            _additionalProductServise = additionalProductServise ?? throw new ArgumentNullException(nameof(additionalProductServise));
            _flowerPackageServise = flowerPackageServise ?? throw new ArgumentNullException(nameof(flowerPackageServise));

        }

        public async Task InputAsync()
        {
            var marker = true;
            var bundles = new List<Bundle>();

            do
            {
                await this.InputBundle(bundles);
                marker = this.MarkerQuestion();

            } while (marker);

            var newSDTO = new SupplayDTO
            {
                Bundles = bundles.AsReadOnly(), 
                FinishDate = DateTime.Now
            };

            await _supplayService.AddAsync(newSDTO);
        }

        public async Task PrintAsync()
        {
            Console.WriteLine("Поставки: ");

            var supplays = await _supplayService.GetAllAsynс();

            foreach (var supplay in supplays)
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.FinishDate}, свертки:");

                foreach (var bundle in supplay.Bundles)
                {
                    var productType = bundle.Product;

                    switch (productType)
                    {
                        case FlowerBundle fB:
                            this.PrintFlowerBundle(fB);
                            break;
                        case FlowerPackage fP:
                            this.PrintFlowerPackege(fP);
                            break;
                        case AdditionalProduct aP:
                            this.PrintAdditionalProduct(aP);
                            break;
                        default:
                            throw new NotSupportedException("Unsupported product type");
                    }

                    Console.Write($", Общее количество: {bundle.Count}\n");
                }
                Console.WriteLine();
            }
        }

        private bool MarkerQuestion()
        {
            Console.WriteLine("\t\t - Добавить еще сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");

            var value = IntPresenter.Input();

            var marker = true;

            if (value != 1)
            {
                marker = false;
            }

            return marker;
        }

        private async Task InputBundle(ICollection<Bundle> bundles)
        {
            Console.WriteLine("Что вы хотите добавить ?\n\t\t - Цветы(нажмите 1)." +
                   "\n\t\t - Упаковку (нажмите 2).\n\t\t - Дополнительний товар (нажмите 3).");

            var value = IntPresenter.Input(1, 3);

            Product chosenProduct = value switch
            {
                1 => await this.ChoseFlowerBundle(),
                2 => await this.ChoseAdditionalProduct(),
                3 => await this.ChoseFlowerPackage(),
                _ => null
            };

            Console.WriteLine("Введите количество :  ");
            
            int count = IntPresenter.Input(1, int.MaxValue);

            var bundle = new Bundle(chosenProduct, count);

            bundles.Add(bundle);
        }

        private async Task<FlowerBundle> ChoseFlowerBundle()
        {
            Console.WriteLine("Введите id цветочного свертка :  ");
            await this.PrintFlowerBundles();

            var currentIdGeneratorValueFlowerBundle = await _flowerBundleServise.GetCurrentIdGeneratorValueAsync();
            var flowerBundleId = IntPresenter.InputId(currentIdGeneratorValueFlowerBundle);

            return await _flowerBundleServise.GetAsynс(flowerBundleId);
        }

        private async Task<FlowerPackage> ChoseFlowerPackage()
        {
            Console.WriteLine("Введите id упаковки :  ");
            await this.PrintFlowerPackages();

            var currentIdGeneratorValueFlowerPackage = await _flowerPackageServise.GetCurrentIdGeneratorValueAsync();
            var flowerPackageId = IntPresenter.InputId(currentIdGeneratorValueFlowerPackage);

            return await _flowerPackageServise.GetAsynс(flowerPackageId);
        }

        private async Task<AdditionalProduct> ChoseAdditionalProduct()
        {
            Console.WriteLine("Введите id дополнительного товара :  ");
            await this.PrintAdditionalProducts();

            var currentIdGeneratorValueFlowerPackage = await _additionalProductServise.GetCurrentIdGeneratorValueAsync();
            var additionalProductId = IntPresenter.InputId(currentIdGeneratorValueFlowerPackage);

            return await _additionalProductServise.GetAsynс(additionalProductId);
        }

        private void PrintFlowerBundle(FlowerBundle flowerBundle)
        {
            Console.WriteLine($"Id: {flowerBundle.Id}, Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, {flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Title} ), Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
        }

        private void PrintFlowerPackege(FlowerPackage flowerPackage)
        {
            Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, {flowerPackage.Height} на {flowerPackage.Width}, {flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
        }

        private void PrintAdditionalProduct(AdditionalProduct additionalProduct)
        {
            Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, {additionalProduct.Title}, {additionalProduct.Color.Title}, {additionalProduct.Desctiption}");
        }

        private async Task PrintFlowerBundles()
        {
            var flowerBundles = await _flowerBundleServise.GetAllAsynс();
            foreach (var flowerBundle in flowerBundles)
            {
                this.PrintFlowerBundle(flowerBundle);
            }
        }

        private async Task PrintFlowerPackages()
        {
            var flowerBundles = await _flowerPackageServise.GetAllAsynс();

            foreach (var flowerPackage in flowerBundles)
            {
                this.PrintFlowerPackege(flowerPackage);
            }
        }

        private async Task PrintAdditionalProducts()
        {
            var additionalProducts = await _additionalProductServise.GetAllAsynс();
            foreach (var additionalProduct in additionalProducts)
            {
                this.PrintAdditionalProduct(additionalProduct);
            }
        }
    }
}
