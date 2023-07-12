using System.Collections.Generic;
using Task2Flowers.Interfeses.Services;
using Task2Flowers.Services.DataTransferObdjects;

namespace Task2Flowers
{
    public interface IServiceBundle : IService<Bundle>
    {
        public Bundle Add(BundleDTO fBDTO);
    }
}