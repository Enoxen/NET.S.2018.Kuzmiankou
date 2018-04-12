using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDecimal
{
    public static class StringExtension
    {
        public static int ToDecimalConverter(this string number, Notation notation)
        {
            int radix = notation.Radix;
            string alphabet = notation.Alphabet;
            int result = 0;
            
            for(int i = 0; i < number.Length; i++)
            {
                int temp = GetAlphabetValue(alphabet, number[i], radix);

                checked
                {
                    result += temp * (int)Math.Pow(radix, number.Length - 1 - i);
                }
            }
            return result;
        }

        private static int GetAlphabetValue(string alphabet, char numString, int radix)
        {
            int intValue = alphabet.IndexOf(numString.ToString().ToUpper()[0]);

            if (intValue > radix || intValue == -1 )
            {
                throw new ArgumentException($"{nameof(numString)} input string contains wrong data");
            }

            return intValue;
        }
    }

    public class Notation
    {
        private readonly string alphabet = "0123456789ABCDEF";
        private int radix;

        public Notation(int radix)
        {
            this.radix = radix;
        }
        public Notation()
        {
            radix = 2;
        }

        public string Alphabet { get => alphabet; }

        public int Radix
        {
            get => radix;
            set
            {
                if (value < 2 || value > 16)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(value)} is out of the range [2 , 16]");
                }
            }
        }
    }
}
