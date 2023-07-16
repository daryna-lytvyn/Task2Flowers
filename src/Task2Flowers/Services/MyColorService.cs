using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.DataTransferObdjects;
using Task2Flowers.Entities;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Services
{
    public class MyColorService : Service<MyColor>, IMyColorService
    {
        public MyColorService(Storage<MyColor> storage) : base(storage) { }

        public void Add(MyColorDTO myColorDTO)
        {
            base.Validation(myColorDTO);

            var id = _storage.IdGenerator().GetNextValue();
            var newAP = new MyColor(id, myColorDTO.Title, myColorDTO.R,
                                        myColorDTO.G, myColorDTO.B);
            this.Add(newAP);
        }
    }
}
