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
        private readonly Storage<FlowerKind> storageKindsOfFlower;

        private readonly FlowerKindPresenter kindsOfFlowerPresenter;


        private readonly Storage<FlowerPackageType> storageFlowerPackageTypes;

        private readonly FlowerPackageTypePresenter flowerPackageTypePresenter;


        private readonly Storage<Flower> storageFlowers;

        private readonly FlowerPresenter flowerPresenter;


        private readonly Storage<AdditionalProductType> storageAdditionalProductTypes;

        private readonly AdditionalProductTypePresenter additionalProductTypePresenter;


        private readonly Storage<FlowerBundle> storageFlowerBundles;

        private readonly FlowerBundlePresenter flowerBundlePresenter;


        private readonly Storage<FlowerPackage> storageFlowerPackage;

        private readonly FlowerPackagePresenter flowerPackagePresenter;


        private readonly Storage<AdditionalProduct> storageAdditionalProducts;

        private readonly AdditionalProductPresenter additionalProductPresenter;


        private readonly Storage<Bundle> storageBundles;

        private readonly BundlePresenter bundlePresenter;


        private readonly Storage<Supplay> storageSupplays;

        private readonly SupplayPresenter supplayPresenter;

        public MenuItems(Storage<FlowerKind> storageKindsOfFlower, Storage<FlowerPackageType> storageFlowerPackageTypes,
            Storage<Flower> storageFlowers, Storage<AdditionalProductType> storageAdditionalProductTypes, 
            Storage<FlowerBundle> storageFlowerBundles, Storage<FlowerPackage> storageFlowerPackage, 
            Storage<AdditionalProduct> storageAdditionalProduct, Storage<Bundle> storageBundles, 
            Storage<Supplay> storageSupplays)
        {
            this.storageKindsOfFlower = storageKindsOfFlower;
            this.kindsOfFlowerPresenter = new FlowerKindPresenter();

            this.storageFlowerPackageTypes = storageFlowerPackageTypes;
            this.flowerPackageTypePresenter = new FlowerPackageTypePresenter();

            this.storageFlowers = storageFlowers;
            this.flowerPresenter = new FlowerPresenter();

            this.storageAdditionalProductTypes = storageAdditionalProductTypes;
            this.additionalProductTypePresenter = new AdditionalProductTypePresenter();

            this.storageAdditionalProductTypes = storageAdditionalProductTypes;
            this.additionalProductTypePresenter = new AdditionalProductTypePresenter();

            this.storageFlowerBundles = storageFlowerBundles;
            this.flowerBundlePresenter = new FlowerBundlePresenter();

            this.storageFlowerPackage = storageFlowerPackage;
            this.flowerPackagePresenter = new FlowerPackagePresenter();

            this.storageAdditionalProducts = storageAdditionalProduct;
            this.additionalProductPresenter = new AdditionalProductPresenter();

            this.storageBundles = storageBundles;
            this.bundlePresenter = new BundlePresenter();

            this.storageSupplays = storageSupplays;
            this.supplayPresenter = new SupplayPresenter();
        }

        public void MainMenu()
        {
            var marker = true;
            do
            {
                Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить вид цветка (нажмите 1)." +
                    "\n\t\t - Добавить цветок (нажмите 2).\n\t\t - Добавить тип доп.товара (нажмите 3)." +
                    "\n\t\t - Добавить доп.товар (нажмите 4).\n\t\t - Добавить тип цветочной упаковки (нажмите 5)." +
                    "\n\t\t - Добавить цветочную упаковку (нажмите 6).\n\t\t - Добавить поставку (нажмите 7)." +
                    "\n\t\t - Просмотреть виды цветов (нажмите 8).\n\t\t - Просмотреть цветы (нажмите 9)." +
                    "\n\t\t- Просмотреть сгрупированные по виду цветы(нажмите 10)\n\t\t - Просмотреть тип доп.товара (нажмите 11)." +
                    "\n\t\t - Просмотреть доп.товар (нажмите 12).\n\t\t - Просмотреть тип цветочной упаковки (нажмите 13)." +
                    "\n\t\t - Просмотреть цветочную упаковку (нажмите 14).\n\t\t - Просмотреть поставки (нажмите 15)." +
                    "\n\t\t - Завершить работу(любое другое число)");

                int value;
                bool parseResult;

                do
                {
                    var textValue = Console.ReadLine();
                    parseResult = Int32.TryParse(textValue, out value);

                } while (parseResult == false);

                switch (value)
                {
                    case 1:
                        this.AddKindOfFlower();
                        break;
                    case 2:
                        this.AddFlower();
                        break;
                    case 3:
                        this.AddAdditionalProductType();
                        break;
                    case 4:
                        this.AddAdditionalProduct();
                        break;
                    case 5:
                        this.AddFlowerPackageType();
                        break;
                    case 6:
                        this.AddFlowerPackage();
                        break;
                    case 7:
                        this.AddSupplay();
                        break;
                    case 8:
                        this.ShowKindsOfFlower();
                        break;
                    case 9:
                        this.ShowFlowers();
                        break;
                    case 10:
                        this.ShowFlowersSortByKind();
                        break;
                    case 11:
                        this.ShowAdditionalProductType();
                        break;
                    case 12:
                        this.ShowAdditionalProduct();
                        break;
                    case 13:
                        this.ShowFlowerPackageType();
                        break;
                    case 14:
                        this.ShowFlowerPackage();
                        break;
                    case 15:
                        this.ShowSupplays();
                        break;

                    default:
                        marker = false;
                        break;
                }

            } while (marker);
        }

        private void AddKindOfFlower()
        {
            this.kindsOfFlowerPresenter.Input(this.storageKindsOfFlower);
        }

        private void AddAdditionalProductType()
        {
            this.additionalProductTypePresenter.Input(this.storageAdditionalProductTypes);
        }

        private void AddFlowerPackageType()
        {
            this.flowerPackageTypePresenter.Input(this.storageFlowerPackageTypes);
        }

        private void AddFlower()
        {
            this.flowerPresenter.Input(this.storageFlowers, this.storageKindsOfFlower);
        }
        private void AddAdditionalProduct()
        {
            this.additionalProductPresenter.Input(this.storageAdditionalProducts, this.storageAdditionalProductTypes);
        }
        private void AddFlowerPackage()
        {
            this.flowerPackagePresenter.Input(this.storageFlowerPackage, this.storageFlowerPackageTypes);
        }

        private void AddSupplay()
        {
            this.supplayPresenter.Input(this.storageSupplays, this.storageBundles, this.storageFlowerBundles,
                this.storageFlowers, this.storageFlowerPackage, this.storageAdditionalProducts);
        }

        private void ShowKindsOfFlower()
        {
            this.kindsOfFlowerPresenter.Print(this.storageKindsOfFlower);
        }

        private void ShowFlowers()
        {
            this.flowerPresenter.Print(this.storageFlowers);
        }

        private void ShowFlowersSortByKind()
        {
            this.flowerPresenter.PrintSortByKind(this.storageFlowers);
        }

        private void ShowAdditionalProductType()
        {
            this.additionalProductTypePresenter.Print(this.storageAdditionalProductTypes);
        }
        private void ShowAdditionalProduct()
        {
            this.additionalProductPresenter.Print(this.storageAdditionalProducts);
        }

        private void ShowFlowerPackageType()
        {
            this.flowerPackageTypePresenter.Print(this.storageFlowerPackageTypes);
        }

        private void ShowFlowerPackage()
        {
            this.flowerPackagePresenter.Print(this.storageFlowerPackage);
        }

        private void ShowSupplays()
        {
            this.supplayPresenter.Print(this.storageSupplays);
        }
    }
}


