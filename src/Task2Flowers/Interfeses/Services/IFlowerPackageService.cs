﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities.Products;

namespace Task2Flowers.Interfeses.Services
{
    public interface IFlowerPackageService : IService<FlowerPackage>
    {
        Task AddAsync(FlowerPackageDTO fPDTO);
        Task<IReadOnlyList<FlowerPackage>> GetSortByTypeAsync();
    }
}
