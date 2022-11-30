using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class SupplayPresenter
    {

        public Supplay Input(List<Package> packeges, IntIdGenerator idSupplay)
        {
            return (new Supplay(idSupplay.GetNextValue(), packeges, DateTime.Now));
        }

        public void Print(List<Supplay> supplays)
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in supplays)
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
    }
}
