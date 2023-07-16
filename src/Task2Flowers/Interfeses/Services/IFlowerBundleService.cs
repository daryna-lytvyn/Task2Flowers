﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers.Interfeses
{
    public interface IFlowerBundleService : IService<FlowerBundle>
    {
        void Add(FlowerBundleDTO fBDTO);
        IReadOnlyList<FlowerBundle> GetSortByFlower();
        IReadOnlyList<FlowerBundle> GetSortByKindOfFlower();
    }
}