using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Task2Flowers
{
    class Program
    {
        static void Main(string[] args)
        {
            var idKindsOfFlower = new IntIdGenerator();
            var idFlowers = new IntIdGenerator();
            var idPackeges = new IntIdGenerator();
            var idSupplays = new IntIdGenerator();

            var kindsOfFlower = new List<KindOfFlower>() 
            { 
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Роза"), 
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Гортензия"), 
                new KindOfFlower(idKindsOfFlower.GetNextValue(), "Ромашка") 
            };
            var flowers = new List<Flower>()
            {
                new Flower(idFlowers.GetNextValue(),kindsOfFlower[1], "Magical Pearl", Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic",Color.DarkRed),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", Color.BlueViolet),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio",Color.LemonChiffon),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса",Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",Color.Honeydew)
            };
            var supplays = new List<Supplay>() { 
                new Supplay(idSupplays.GetNextValue(),new List<Package>
                    { 
                    new Package(idPackeges.GetNextValue(),flowers[5],120,60), 
                    new Package(idPackeges.GetNextValue(),flowers[1],105,90),
                    new Package(idPackeges.GetNextValue(),flowers[1],225,70),
                    new Package(idPackeges.GetNextValue(),flowers[0],25,60)
                    }
                ,  DateTime.Parse("2022-11-15")),
                new Supplay(idSupplays.GetNextValue(),new List<Package>
                    {
                    new Package(idPackeges.GetNextValue(),flowers[3],170,40),
                    new Package(idPackeges.GetNextValue(),flowers[4],235,65)
                    }
                ,  DateTime.Parse("2022-11-16"))

            };

            var storage = new MyStorage(kindsOfFlower, flowers, supplays, idKindsOfFlower, idFlowers, idPackeges, idSupplays);

            var marker = true;

            do
            {              
                Console.WriteLine("Что вы хотите сделать?\n\t\t - Добавить вид цветка (нажмите 1)." +
                    "\n\t\t - Добавить цветок (нажмите 2).\n\t\t - Добавить поставку (нажмите 3)." +
                    "\n\t\t - Просмотреть виды цветов (нажмите 4).\n\t\t - Просмотреть цветы (нажмите 5)." +
                    "\n\t\t- Просмотреть сгрупированные по виду цветы(нажмите 6)" +
                    "\n\t\t - Просмотреть поставки (нажмите 7).\n\t\t - Завершить работу(любое другое число)");

                int value;
                Int32.TryParse(Console.ReadLine(), out value);
                var menu = new MenuItems();

                switch (value)
                {
                    case 1:
                        menu.AddKindOfFlower(storage);
                        break;
                    case 2:
                        menu.AddFlower(storage);
                        break;
                    case 3:
                        menu.AddSupplay(storage);
                        break;
                    case 4:
                        menu.ShowKindOfFlowers(storage);
                        break;
                    case 5:
                        menu.ShowFlowers(storage);
                        break;
                    case 6:
                        menu.ShowFlowersSortByKind(storage);
                        break;
                    case 7:
                        menu.ShowSupplays(storage);
                        break;

                    default:
                        marker = false;
                        break;
                }

            } while (marker);
        }
    }   
}
