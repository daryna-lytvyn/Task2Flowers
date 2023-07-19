using System;
using System.Collections.Generic;
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

        public void Input()
        {
            var marker = true;
            var bundles = new List<Bundle>();

            do
            {
                this.InputBundle(bundles);
                marker = this.MarkerQuestion();

            } while (marker);

            var newSDTO = new SupplayDTO
            {
                Bundles = bundles.AsReadOnly(), 
                FinishDate = DateTime.Now
            };

            _supplayService.Add(newSDTO);
        }

        public void Print()
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in _supplayService.GetAll())
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.FinishDate}, свертки:");

                foreach (var bundle in supplay.GetBundles())
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

        private void InputBundle(ICollection<Bundle> bundles)
        {
            Console.WriteLine("Что вы хотите добавить ?\n\t\t - Цветы(нажмите 1)." +
                   "\n\t\t - Упаковку (нажмите 2).\n\t\t - Дополнительний товар (нажмите 3).");

            var value = IntPresenter.Input(1, 3);

            Product chosenProduct = value switch
            {
                1 => this.ChoseFlowerBundle(),
                2 => this.ChoseAdditionalProduct(),
                3 => this.ChoseFlowerPackage(),
                _ => null
            };

            Console.WriteLine("Введите количество :  ");
            
            int count = IntPresenter.Input(1, int.MaxValue);

            var bundle = new Bundle(chosenProduct, count);

            bundles.Add(bundle);
        }

        private FlowerBundle ChoseFlowerBundle()
        {
            Console.WriteLine("Введите id цветочного свертка :  ");
            this.PrintFlowerBundles();

            var flowerBundleId = IntPresenter.InputId(_flowerBundleServise.GetCurrentIdGeneratorValue());

            return _flowerBundleServise.Get(flowerBundleId);
        }

        private FlowerPackage ChoseFlowerPackage()
        {
            Console.WriteLine("Введите id упаковки :  ");
            this.PrintFlowerPackages();

            var flowerPackageId = IntPresenter.InputId(_flowerPackageServise.GetCurrentIdGeneratorValue());

            return _flowerPackageServise.Get(flowerPackageId);
        }

        private AdditionalProduct ChoseAdditionalProduct()
        {
            Console.WriteLine("Введите id дополнительного товара :  ");
            this.PrintAdditionalProducts();

            var additionalProductId = IntPresenter.InputId(_additionalProductServise.GetCurrentIdGeneratorValue());

            return _additionalProductServise.Get(additionalProductId);
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

        private void PrintFlowerBundles()
        {
            foreach (FlowerBundle flowerBundle in _flowerBundleServise.GetAll())
            {
                this.PrintFlowerBundle(flowerBundle);
            }
        }

        private void PrintFlowerPackages()
        {
            foreach (var flowerPackage in _flowerPackageServise.GetAll())
            {
                this.PrintFlowerPackege(flowerPackage);
            }
        }

        private void PrintAdditionalProducts()
        {
            foreach (var additionalProduct in this._additionalProductServise.GetAll())
            {
                this.PrintAdditionalProduct(additionalProduct);
            }
        }

        
    }
}
