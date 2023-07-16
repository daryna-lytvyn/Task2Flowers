using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities;

namespace Task2Flowers.Interfeses.Services
{
    public interface IMyColorService: IService<MyColor>
    {
        void Add(MyColorDTO aPDTO);
    }
}
