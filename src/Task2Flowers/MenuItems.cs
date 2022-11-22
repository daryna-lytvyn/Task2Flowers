using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Flowers
{
    public class MenuItems
    {
        public void AddKindOfFlower(MyStorage storage)
        {
            MyInputOutput myInput = new MyInputOutput();

            var kindOfFlower = myInput.InputKindOfFlower(storage.IdKindsOfFlower);

            storage.AddKindOfFlower(kindOfFlower);
        }

        public void AddFlower(MyStorage storage)
        {
            MyInputOutput myInput = new MyInputOutput();

            var flower = myInput.InputFlower(storage.KindOfFlowers, storage.IdFlowers);

            storage.AddFlower(flower);
        }

        public void AddSupplay(MyStorage storage)
        {
            MyInputOutput myInput = new MyInputOutput();

            var supplay = myInput.InputSupplay(storage.Flowers, storage.IdPackeges, storage.IdSupplays);

            storage.AddSuplay(supplay);
        }

        public void ShowKindOfFlowers(MyStorage storage)
        {
            MyInputOutput myOutput = new MyInputOutput();

            myOutput.PrintKindOfFlowers(storage.KindOfFlowers);
        }

        public void ShowFlowers(MyStorage storage)
        {
            MyInputOutput myOutput = new MyInputOutput();

            myOutput.PrintFlowers(storage.Flowers);
        }

        public void ShowFlowersSortByKind(MyStorage storage)
        {
            MyInputOutput myOutput = new MyInputOutput();

            myOutput.PrintFlowersSortByKind(storage.Flowers);
        }

        public void ShowSupplays(MyStorage storage)
        {
            MyInputOutput myOutput = new MyInputOutput();

            myOutput.PrintSupplays(storage.Supplays);
        }
    }
}
