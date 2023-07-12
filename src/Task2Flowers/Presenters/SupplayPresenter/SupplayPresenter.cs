﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Generators;
using Task2Flowers.Interfeses;
using Task2Flowers.Services;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public class SupplayPresenter : IPresenter<Supplay>
    {
        IServiceSupplay _supplayService;

        IServiceFlowerBundle _flowerBundleServise;
        IServiceAdditionalProduct _additionalProductServise;
        IServiceFlowerPackage _flowerPackageServise;

        public Supplay Input()
        {
            var newSupplay = _supplayService.AddEmpty();
            
            var newSupplayId = newSupplay.Id;

            var bundleStorage = new Storage<Bundle>();
            var bundleService = new ServiceBundle(bundleStorage);
            var bundlePresenter = new BundlePresenter(bundleService, _flowerBundleServise, _additionalProductServise, _flowerPackageServise, newSupplayId);

            var marker = true;

            do
            {
                bundlePresenter.Input();
                marker = this.MarkerQuestion();

            } while (marker);

            var newSDTO = new SupplayDTO
            {
                Bundles = bundleStorage,
                FinishDate = DateTime.Now

            };
            var newS = _supplayService.AddWithoutId(newSupplayId, newSDTO);

            return newS;
        }

        

        public void Print()
        {
            Console.WriteLine("Поставки: ");

            foreach (var supplay in _supplayService.GetAll())
            {
                Console.WriteLine($"\t\tId: {supplay.Id}, дата: {supplay.GetFinishDate()}, свертки:");

                foreach (var bundle in supplay.GetBundles().Elements)
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

                    /*productType switch
                    {
                        FlowerBundle fB =>  this.PrintFlowerBundle(fB),

                        FlowerPackage fP=> this.PrintFlowerPackege(fP),

                        AdditionalProduct aP => this.PrintAdditionalProduct(aP)
                    };*/

                    Console.Write($", Общее количество: {bundle.Count}\n");
                }
                Console.WriteLine();
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

        private void PrintFlowerBundle(FlowerBundle flowerBundle)
        {
            Console.WriteLine($"Id: {flowerBundle.Id}, " +
                   $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                   $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Name} ), " +
                   $"Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
        }

        private void PrintFlowerPackege(FlowerPackage flowerPackage)
        {
            Console.WriteLine($"\t\tId: {flowerPackage.Id}, {flowerPackage.Type}, " +
                   $"{flowerPackage.Height} на {flowerPackage.Width}, " +
                   $"{flowerPackage.Color.Name}, {flowerPackage.Desctiption}");
        }

        private void PrintAdditionalProduct(AdditionalProduct additionalProduct)
        {
            Console.WriteLine($"\t\tId: {additionalProduct.Id}, {additionalProduct.Type}, " +
                    $"{additionalProduct.Title}, {additionalProduct.Color.Name}," +
                    $"{additionalProduct.Desctiption}");
        }

        private void PrintFlowerBundles()
        {
            foreach (FlowerBundle flowerBundle in _flowerBundleServise.GetAll())
            {
                Console.WriteLine($"Id: {flowerBundle.Id}, " +
                    $"Цветок: ( Id: {flowerBundle.Flower.Id}, {flowerBundle.Flower.Kind.Title}, " +
                    $"{flowerBundle.Flower.Variety}, {flowerBundle.Flower.Color.Name} ), " +
                    $"Количество в пачке: {flowerBundle.CountOfFlower}, Высота: {flowerBundle.Height}");
            }
        }
    }
}