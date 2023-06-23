using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class BundlePresenter
    {

        public Bundle Input(Storage<Bundle> storageBundles, Storage<FlowerBundle> storageFlowerBundles, Storage<Flower> storageFlowers, int idSupplay)
        {
            var flowerBundlePresenter = new FlowerBundlePresenter();

            var flowerBundle = flowerBundlePresenter.Input(storageFlowerBundles, storageFlowers);

            Console.WriteLine("Введите количество :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            var newBundle = new Bundle(storageBundles.IdGenerator.GetNextValue(), idSupplay, flowerBundle, count);

            storageBundles.Add(newBundle);

            return newBundle;
        }

        public Bundle Input(Storage<Bundle> storageBundles, Storage<FlowerPackage> storageFlowersPackages, int idSupplay)
        {
            var flowerPackagePresenter = new FlowerPackagePresenter();

            Console.WriteLine("Введите id упаковки :  ");
            flowerPackagePresenter.Print(storageFlowersPackages);
            int flowerPackageId;
            bool flowerPackageIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                flowerPackageIdParseResult = Int32.TryParse(textValue, out flowerPackageId);

            } while (flowerPackageIdParseResult == false || 0 > flowerPackageId || flowerPackageId > storageFlowersPackages.Elements.Count);

            Console.WriteLine("Введите количество :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            var newBundle = new Bundle(storageBundles.IdGenerator.GetNextValue(), idSupplay, storageFlowersPackages.Elements[flowerPackageId - 1], count);

            storageBundles.Add(newBundle);

            return newBundle;
        }

        public Bundle Input(Storage<Bundle> storageBundles, Storage<AdditionalProduct> storageAdditionalProducts, int idSupplay)
        {
            var additionalProductPresenter = new AdditionalProductPresenter();

            Console.WriteLine("Введите id дополнительного товара :  ");
            additionalProductPresenter.Print(storageAdditionalProducts);
            int additionalProductId;
            bool additionalProductIdParseResult;
            do
            {
                var textValue = Console.ReadLine();
                additionalProductIdParseResult = Int32.TryParse(textValue, out additionalProductId);

            } while (additionalProductIdParseResult == false || 0 > additionalProductId || additionalProductId > storageAdditionalProducts.Elements.Count);

            Console.WriteLine("Введите количество :  ");
            int count;
            bool countParseResult;
            do
            {
                var textValue = Console.ReadLine();
                countParseResult = Int32.TryParse(textValue, out count);

            } while (countParseResult == false || 0 > count);

            var newBundle = new Bundle(storageBundles.IdGenerator.GetNextValue(), idSupplay, storageAdditionalProducts.Elements[additionalProductId - 1], count);

            storageBundles.Add(newBundle);

            return newBundle;
        }


        public void Print(IList<Bundle> iListBundles)
        {
            foreach (var bundle in iListBundles)
            {
                var productType = bundle.Product.GetType().Name;

                switch (productType)
                {
                    case "FlowerBundle":
                        this.PrintFlowerBundle((FlowerBundle)bundle.Product);
                        break;
                    case "FlowerPackage":
                        this.PrintFlowerPackege((FlowerPackage)bundle.Product);
                        break;
                    case "AdditionalProduct":
                        this.PrintAdditionalProduct((AdditionalProduct)bundle.Product);
                        break;
                    default:
                        break;
                }

                Console.Write($", Общее количество: {bundle.Count}\n");
            }
            Console.WriteLine();
        }

        public void Print(Storage<Bundle> storageBundles)
        {
            foreach (var bundle in storageBundles.Elements)
            {
                var productType = bundle.Product.GetType().Name;

                switch (productType)
                {
                    case "FlowerBundle":
                        this.PrintFlowerBundle((FlowerBundle)bundle.Product);
                        break;
                    case "FlowerPackage":
                        this.PrintFlowerPackege((FlowerPackage)bundle.Product);
                        break;
                    case "AdditionalProduct":
                        this.PrintAdditionalProduct((AdditionalProduct)bundle.Product);
                        break;
                    default:
                        break;
                }

                Console.Write($", Общее количество: {bundle.Count}");
            }
        }

        private void PrintFlowerBundle(FlowerBundle flowerBundle)
        {
            var flowerBundlePresenter = new FlowerBundlePresenter();

            flowerBundlePresenter.Print(flowerBundle);
        }

        private void PrintFlowerPackege(FlowerPackage flowerPackage)
        {
            var flowerPackagePresenter = new FlowerPackagePresenter();

            flowerPackagePresenter.Print(flowerPackage);
        }

        private void PrintAdditionalProduct(AdditionalProduct additionalProduct)
        {
            var additionalProductPresenter = new AdditionalProductPresenter();

            additionalProductPresenter.Print(additionalProduct);
        }
    }
}
