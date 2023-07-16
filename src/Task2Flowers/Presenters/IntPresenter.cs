using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2Flowers.Interfeses.Services;

namespace Task2Flowers.Presenters
{
    public static class IntPresenter
    {
        public static int InputId(int count)
        {
            int id;
            bool parseResult;
            do
            {
                var textValue = Console.ReadLine();
                parseResult = Int32.TryParse(textValue, out id);

            } while (parseResult == false
                        || 0 > id
                        || id > count);

            return id;
        }

        public static int Input(int min, int max)
        {
            int number;
            bool parseResult;
            do
            {
                var textValue = Console.ReadLine();
                parseResult = Int32.TryParse(textValue, out number);

            } while (parseResult == false 
                        || min > number 
                        || number > max);

            return number;
        }
    }
}
