using System;
using System.Text;

namespace insert
{
    public class Insert
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
        public static int InsertNumber(int firstNumber, int secondNumber, int i, int j)
        {
            if (i < 0 || i > 31)
            {
                throw new ArgumentOutOfRangeException(nameof(i));
            }

            if (j < 0 || j > 31 || j < i)
            {
                throw new ArgumentOutOfRangeException(nameof(j));
            }

            if (j - i + 1 == 32)
            {
                return secondNumber;
            }

            int maskSecondNumber = (int)(Math.Pow(2, j + 1) - 1);

            secondNumber >>= i;
            secondNumber <<= i;
            secondNumber = (secondNumber & maskSecondNumber);

            int maskFirstNumberLeft = -1 << (j + 1);
            int firstNumberLeft = firstNumber & maskFirstNumberLeft;

            int maskFirstNumberRight = (int)Math.Pow(2, i) - 1;
            int firstNumberRight = firstNumber & maskFirstNumberRight;

            int newNumber = 0;

            return secondNumber | newNumber | firstNumberLeft | firstNumberRight;
        }

        #endregion

    }
}
