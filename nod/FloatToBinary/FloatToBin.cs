using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloatToBinary
{
    public static class FloatToBin
    {
        #region Public methods
        public static string ConvertToBinary(this double num)
        {
            double number = num;
            var result = new List<int>();
            if(number < 0)
            {
                result.Add(1);
                number *= -1;
            }
            else
            {
                result.Add(0);
            }
    
            var intPart = ConvertWholeNumber((long)number);
            var fractPart = ConvertFractionPart(number - (long)number);

            int exponent = 1023;

            if((int)number != 0)
            {
                Console.WriteLine((int)number);

                exponent += intPart.Count - 1;
            }
            else
            {
                exponent -= fractPart.IndexOf(1) + 1;
                if(fractPart.IndexOf(1) != -1)
                fractPart.RemoveRange(0, fractPart.IndexOf(1));
            }

            intPart.AddRange(fractPart);
            intPart.RemoveAt(0);

            result.AddRange(ConvertWholeNumber(exponent));
            result.AddRange(intPart);

            return string.Join("", result.ToArray());
        }
        #endregion

        #region Private methods
        private static List<int> ConvertWholeNumber(long number)
        {
            var bits = new List<int>();

            while(number > 0)
            {
                bits.Add((int)(number % 2));
                number /= 2;
            }

            bits.Reverse();
            return bits;
        }

        private static List<int> ConvertFractionPart(double fracPart)
        {
            var fracBits = new List<int>();

            for(int i = 0; i < 52; i++)
            {
                fracPart *= 2;
                fracBits.Add((int)fracPart);
                fracPart = TakeFractionalPart(fracPart);
            }

            return fracBits;
        }

        private  static double TakeFractionalPart(double number)
        {
            int intPart = (int)number;
            return number - intPart;
        }
        #endregion
    }
}
