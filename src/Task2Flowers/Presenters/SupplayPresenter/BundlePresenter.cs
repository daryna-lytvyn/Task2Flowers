using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class BundlePresenter : IPresenter<Bundle>
    {
        IBundleService _bundleService;

        IFlowerBundleService _flowerBundleServise;
        IAdditionalProductService _additionalProductServise;
        IFlowerPackageService _flowerPackageServise;

        public BundlePresenter(IBundleService bundleService, IFlowerBundleService flowerBundleServise,
            IAdditionalProductService additionalProductServise, IFlowerPackageService flowerPackageServise)
        {
            _bundleService = bundleService ?? throw new ArgumentNullException(nameof(bundleService));
            _flowerBundleServise = flowerBundleServise ?? throw new ArgumentNullException(nameof(flowerBundleServise));
            _additionalProductServise = additionalProductServise ?? throw new ArgumentNullException(nameof(additionalProductServise));
            _flowerPackageServise = flowerPackageServise ?? throw new ArgumentNullException(nameof(flowerPackageServise));
        }

        public void Input()
        {
            Console.WriteLine("Что вы хотите добавить ?\n\t\t - Цветы(нажмите 1)." +
                    "\n\t\t - Упаковку (нажмите 2).\n\t\t - Дополнительний товар (нажмите 3).");

            int value;
            bool parseResult;
            do
            {
                var textValue = Console.ReadLine();
                parseResult = Int32.TryParse(textValue, out value);

            } while (parseResult == false);

            Product chosenProduct = value switch
            {
                1 =>  this.ChoseFlowerBundle(),
                2 =>  this.ChoseAdditionalProduct(),
                3 =>  this.ChoseFlowerPackage(),
                _ =>  null
            };
            
            Console.WriteLine("Введите количество :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            var bDTO = new BundleDTO {
                Product = chosenProduct,
                Count = count,
            };

            _bundleService.Add(bDTO);
        }

        public void Print()
        {
            foreach (var bundle in _bundleService.GetAll())
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

        private void PrintFlowerBundle(FlowerBundle flowerBundle)
        {
            Console.WriteLine($"Id: {flowerBundle.Id}, " +
                   $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                   $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Title} ), " +
                   $"Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
        }

        private void PrintFlowerPackege(FlowerPackage flowerPackage)
        {
            Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, " +
                   $"{flowerPackage.Height} на {flowerPackage.Width}, " +
                   $"{flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
        }

        private void PrintAdditionalProduct(AdditionalProduct additionalProduct)
        {
            Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, " +
                    $"{additionalProduct.Title}, {additionalProduct.Color.Title}," +
                    $"{additionalProduct.Desctiption}");
        }

        private void PrintFlowerBundles()
        {
            foreach (FlowerBundle flowerBundle in _flowerBundleServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerBundle.Id}, " +
                    $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                    $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Title} ), " +
                    $"Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
            }
        }
        private FlowerBundle ChoseFlowerBundle()
        {
            Console.WriteLine("Введите id цветочного свертка :  ");
            this.PrintFlowerBundles();

            int flowerBundleId;
            bool flowerBundleIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerBundleIdParseResult = Int32.TryParse(textValue, out flowerBundleId);

            } while (flowerBundleIdParseResult == false
                        || 0 > flowerBundleId
                        || flowerBundleId > _flowerBundleServise.GetAll().Count);

            return _flowerBundleServise.Get(flowerBundleId);
        }

        private void PrintFlowerPackages()
        {
            foreach (var flowerPackage in _flowerPackageServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, " +
                    $"{flowerPackage.Height} на {flowerPackage.Width}, " +
                    $"{flowerPackage.Color.Title}, {flowerPackage.Desctiption}");
            }
        }

        private FlowerPackage ChoseFlowerPackage()
        {
            Console.WriteLine("Введите id упаковки :  ");
            this.PrintFlowerPackages();

            int flowerPackageId;
            bool flowerPackageIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerPackageIdParseResult = Int32.TryParse(textValue, out flowerPackageId);

            } while (flowerPackageIdParseResult == false
                        || 0 > flowerPackageId
                        || flowerPackageId > _flowerPackageServise.GetAll().Count);

            return _flowerPackageServise.Get(flowerPackageId);
        }

        private void PrintAdditionalProducts()
        {
            foreach (var additionalProduct in this._additionalProductServise.GetAll())
            {
                Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, " +
                    $"{additionalProduct.Title}, {additionalProduct.Color.Title}," +
                    $"{additionalProduct.Desctiption}");
            }
        }

        private AdditionalProduct ChoseAdditionalProduct()
        {
            Console.WriteLine("Введите id дополнительного товара :  ");
            this.PrintAdditionalProducts();

            int additionalProductId;
            bool additionalProductIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                additionalProductIdParseResult = Int32.TryParse(textValue, out additionalProductId);

            } while (additionalProductIdParseResult == false
                        || 0 > additionalProductId
                        || additionalProductId > _additionalProductServise.GetAll().Count);

            return _additionalProductServise.Get(additionalProductId);
        }

    }
}
