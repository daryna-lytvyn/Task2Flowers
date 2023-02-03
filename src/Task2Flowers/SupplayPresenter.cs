using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class SupplayPresenter
    {

        public void Input(Storage<Supplay> storageSupplays, Storage<FlowerBundle> storagePackages, Storage<Flower> storageFlowers)
        {
            var supplay = new Supplay(storageSupplays.IdGenerator.GetNextValue());
            var idOfSupplay = supplay.Id;

            List<FlowerBundle> newPackages = new List<FlowerBundle>();

            var marker = true;

            do
            {
                var packegePresenter = new PackagePresenter();

                Console.WriteLine("Введите сверток:  ");
                var newPackage = packegePresenter.Input(storagePackages, storageFlowers, idOfSupplay);
                newPackages.Add(newPackage);

                marker = this.MarkerQuestion();

            } while (marker);

            supplay.AddPackeges(newPackages);
            supplay.AddFinishDate(DateTime.Now);

            storageSupplays.Add(supplay);
        }

        public void Print(Storage<Supplay> storageSupplays)
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in storageSupplays.Elements)
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.FinishDate}, свертки: ");

                foreach (var packege in supplay.FlowerPackeges)
                {
                    Console.WriteLine($"\t\t\t\tId{packege.Id}," +
                        $" цветок:( id{packege.Flower.Id}, {packege.Flower.Kind.Title}, {packege.Flower.Variety}, {packege.Flower.Color.Name})," +
                        $" количество: {packege.CountOfFlower}шт., высота: {packege.FlowersHeight}см.");
                }
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
