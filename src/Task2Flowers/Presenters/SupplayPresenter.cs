using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class SupplayPresenter
    {

        public void Input(Storage<Supplay> storageSupplays, Storage<Bundle> storageBundles,
            Storage<FlowerBundle> storageFlowerBundles, Storage<Flower> storageFlowers, 
            Storage<FlowerPackage> storageFlowerPackage,
            Storage<AdditionalProduct> storageAdditionalProduct)
        {
            var supplay = new Supplay(storageSupplays.IdGenerator.GetNextValue());
            var idOfSupplay = supplay.Id;

            List<Bundle> newBundles = new List<Bundle>();

            var marker = true;

            do
            {
                Console.WriteLine("Что вы хотите добавить ?\n\t\t - Цветы(нажмите 1)." +
                    "\n\t\t - Упаковку (нажмите 2).\n\t\t - Дополнительний товар (нажмите 3)."  );

                int value;
                bool parseResult;

                do
                {
                    var textValue = Console.ReadLine();
                    parseResult = Int32.TryParse(textValue, out value);

                } while (parseResult == false);

                var bundlePresenter = new BundlePresenter();

                switch (value)
                {
                    case 1:
                        newBundles.Add(bundlePresenter.Input(storageBundles, storageFlowerBundles, storageFlowers, idOfSupplay));
                        break;
                    case 2:
                        newBundles.Add(bundlePresenter.Input(storageBundles, storageFlowerPackage, idOfSupplay));
                        break;
                    case 3:
                        newBundles.Add(bundlePresenter.Input(storageBundles, storageAdditionalProduct, idOfSupplay));
                        break;              
                }

                marker = this.MarkerQuestion();

            } while (marker);

            supplay.AddBundles(newBundles);
            supplay.AddFinishDate(DateTime.Now);

            storageSupplays.Add(supplay);
        }

        public void Print(Storage<Supplay> storageSupplays)
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in storageSupplays.Elements)
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.FinishDate}, свертки:");

                var bundlePresenter = new BundlePresenter();
                bundlePresenter.Print(supplay.Bundles);
            }
        }

        private bool MarkerQuestion()
        {
            Console.WriteLine("\t\t - Добавить еще сверток (нажмите 1).\n\t\t - Завершить поставку(любое другое число)");

            bool parseResult;
            int value;

            do
            {
                var textValue = Console.ReadLine();
                parseResult = Int32.TryParse(textValue, out value);
            }
            while (parseResult == false);

            var marker = true;

            if (value != 1)
            {
                marker = false;
            }

            return marker;
        }
    }
}
