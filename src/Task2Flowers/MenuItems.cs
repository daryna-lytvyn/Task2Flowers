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
        private readonly Storage<KindOfFlower> storageKindsOfFlower;

        private readonly KindsOfFlowerPresenter kindsOfFlowerPresenter;

        private readonly Storage<Flower> storageFlowers;

        private readonly FlowerPresenter flowerPresenter;

        private readonly Storage<Bundle> storageBundles;

        private readonly PackagePresenter packegePresenter;

        private readonly Storage<Supplay> storageSupplays;

        private readonly SupplayPresenter supplayPresenter;

        public MenuItems(Storage<KindOfFlower> storageKindsOfFlower, Storage<Flower> storageFlowers, Storage<Bundle> storageBundles, Storage<Supplay> storageSupplays)
        {
            this.storageKindsOfFlower = storageKindsOfFlower;
            this.kindsOfFlowerPresenter = new KindsOfFlowerPresenter();

            this.storageFlowers = storageFlowers;
            this.flowerPresenter = new FlowerPresenter();

            this.storageBundles = storageBundles;
            this.packegePresenter = new PackagePresenter();

            this.storageSupplays = storageSupplays;
            this.supplayPresenter = new SupplayPresenter();
        }

        public void MainMenu()
        {
            var marker = true;
            do
            {
                Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить вид цветка (нажмите 1)." +
                    "\n\t\t - Добавить цветок (нажмите 2).\n\t\t - Добавить поставку (нажмите 3)." +
                    "\n\t\t - Просмотреть виды цветов (нажмите 4).\n\t\t - Просмотреть цветы (нажмите 5)." +
                    "\n\t\t- Просмотреть сгрупированные по виду цветы(нажмите 6)" +
                    "\n\t\t - Просмотреть свертки (нажмите 7).\n\t\t - Просмотреть поставки (нажмите 8).\n\t\t - Завершить работу(любое другое число)");

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
                        this.AddSupplay();
                        break;
                    case 4:
                        this.ShowKindsOfFlower();
                        break;
                    case 5:
                        this.ShowFlowers();
                        break;
                    case 6:
                        this.ShowFlowersSortByKind();
                        break;
                    case 7:
                        this.ShowPackages();
                        break;
                    case 8:
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

        private void AddFlower()
        {
            this.flowerPresenter.Input(this.storageFlowers, this.storageKindsOfFlower);
        }

        private void AddPackage(int idOfSupplay)
        {
            if (0 > idOfSupplay || idOfSupplay > this.storageSupplays.Elements.Count)
            {
                throw new ArgumentException();
            }

            this.packegePresenter.Input(this.storageBundles, this.storageFlowers, idOfSupplay);
        }

        private void AddSupplay()
        {
            this.supplayPresenter.Input(this.storageSupplays, this.storageBundles, this.storageFlowers);

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
        private void ShowPackages()
        {
            this.packegePresenter.Print(this.storageBundles);
        }

        private void ShowSupplays()
        {
            this.supplayPresenter.Print(this.storageSupplays);
        }
    }
}


