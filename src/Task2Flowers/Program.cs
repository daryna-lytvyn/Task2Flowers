﻿using System;
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
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Magical Pearl", Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Black Magic",Color.DarkRed),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[1], "Anabell", Color.BlueViolet),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"Kerio",Color.LemonChiffon),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[2],"Северная принцесса",Color.White),
                new Flower(idFlowers.GetNextValue(), kindsOfFlower[0],"LaPerla",Color.Honeydew)
            };

            var packeges = new List<Package>()
            {
                    new Package(idPackeges.GetNextValue(), 1, flowers[5], 120, 60),
                    new Package(idPackeges.GetNextValue(), 1, flowers[1], 105, 90),
                    new Package(idPackeges.GetNextValue(), 1, flowers[1], 225, 70),
                    new Package(idPackeges.GetNextValue(), 1, flowers[0], 25, 60),
                    new Package(idPackeges.GetNextValue(), 2, flowers[3], 170, 40),
                    new Package(idPackeges.GetNextValue(), 2, flowers[4], 235, 65)
            };
            var supplays = new List<Supplay>() {
                new Supplay(idSupplays.GetNextValue(), packeges.Select(p =>p).Where(p=>p.IdOfSupplay == 1).ToList() ,  DateTime.Parse("2022-11-15")),
                new Supplay(idSupplays.GetNextValue(), packeges.Select(p =>p).Where(p=>p.IdOfSupplay == 2).ToList(),  DateTime.Parse("2022-11-16"))

            };

            var storageKindOfFlower = new Storage<KindOfFlower>(kindsOfFlower, idKindsOfFlower);
            var storageFlower = new Storage<Flower>(flowers, idFlowers);
            var storagePackage = new Storage<Package>(packeges, idPackeges);
            var storageSupplay = new Storage<Supplay>(supplays, idSupplays);


            var menu = new MenuItems(storageKindOfFlower, storageFlower, storagePackage, storageSupplay);

            menu.MainMenu();

        }
    }
}
