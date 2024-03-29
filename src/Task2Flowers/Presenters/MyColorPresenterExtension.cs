﻿using System;

namespace Task2Flowers.Presenters
{
    public static class MyColorPresenterExtension
    {
        public static Byte InputByte(this MyColorPresenter colorPresenter)
        {
            Byte byteNumber;
            bool parseResult;
            do
            {
                var textValue = Console.ReadLine();
                parseResult = Byte.TryParse(textValue, out byteNumber);

            } while (parseResult == false
                        || 0 > byteNumber
                        || byteNumber > 255);

            return byteNumber;
        }
    }
}
