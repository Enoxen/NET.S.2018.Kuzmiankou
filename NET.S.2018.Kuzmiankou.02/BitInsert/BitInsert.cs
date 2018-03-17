using System;
using System.Text;

namespace insert
{
    public class BitInsert
    {
        #region Public methods
        /// <summary>
        /// Inserts bits of the secondNumber into bits of the firstNumber from i 
        /// position to j position.
        /// </summary>
        /// <param name="firstNumber">Number which bits are to be changed. Reference parameter. </param>
        /// <param name="secondNumber">Number which bits a re to be inserted into another number.</param>
        /// <param name="i">Start position of insertion from 0 to 31, but i must be less or equal j.</param>
        /// <param name="j">End position of insertion from 0 to 31.</param>
        public static int InsertNumber(ref int firstNumber, int secondNumber, int i, int j)
        {
            if( i < 0 || i > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if(j < 0 || j > 31 || j < i)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }

            var firstBits = new StringBuilder(32);

            firstBits.Append(ReversedStringBits(firstNumber));
            string secondBits = ReversedStringBits(secondNumber);
            firstBits.Remove(i, j - i + 1);
            firstBits.Insert(i, secondBits.Substring(0, j - i + 1));
            Console.WriteLine(ReverseString(firstBits.ToString()));

            return Convert.ToInt32(ReverseString(firstBits.ToString()), 2);

        }
        #endregion

        #region Private methods
        /// <summary>
        /// Converts integer number to string in binary system and reverses it.
        /// </summary>
        /// <param name="number">Number to be converted and reversed</param>
        /// <returns>Reversed sdtring bit instance of a number.</returns>
        private static string ReversedStringBits(int number)
        {
            string bits = Convert.ToString(number, 2);
            Console.WriteLine("kek " + bits);

            if (bits.Length < 32)
            {
                char[] array = new char[32 - bits.Length];

                for (int i = 0; i < array.Length; i++)
                {
                    array[i] = '0';
                }

                return string.Concat(ReverseString(bits), new string(array));
            }
            else
            {
                return ReverseString(bits);
            }  
        }
        /// <summary>
        /// Reverses input string.
        /// </summary>
        /// <param name="stringToBeReversed">String to be reversed.</param>
        /// <returns>Reversed string.</returns>
        private static string ReverseString(string stringToBeReversed)
        {
            char[] bitsArray = stringToBeReversed.ToCharArray();
            Array.Reverse(bitsArray);
            return new string(bitsArray);
        }
        #endregion

    }
}
