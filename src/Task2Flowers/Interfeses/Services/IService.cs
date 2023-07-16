﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers.Interfeses.Services
{
    public interface IService<T>
    {
        void Add(T element);
        T Get(int id);
        IReadOnlyCollection<T> GetAll();
        int GetCurrentIdGeneratorValue();
    }
}
