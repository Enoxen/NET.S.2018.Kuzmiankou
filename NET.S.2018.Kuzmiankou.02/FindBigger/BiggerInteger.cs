using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBigger
{
    public class BiggerInteger
    {
        #region Public methods
        /// <summary>
        /// Takes a positive number and returns the closest bigger integer value if it's possible.
        /// </summary>
        /// <param name="number">Input number.</param>
        /// <returns>The closest bigger integer.</returns>
        public static int FindNextBiggerNumber(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }

            if(number == int.MaxValue)
            {
                return -1;
            }

            int[] digits = NumberToReversedArray(number);
            var partOfNumberList = new List<int>();
            
            int fallDigitId = 0;
            int biggerDigitId = 0;

            ParticipateNumberArray(digits, partOfNumberList, ref fallDigitId, ref biggerDigitId);

            int[] partOfNumber = partOfNumberList.ToArray();

            (digits[fallDigitId], partOfNumber[biggerDigitId]) = (partOfNumber[biggerDigitId], digits[fallDigitId]);

            MakeNewNumberFromArrayParts(digits, partOfNumber, fallDigitId);

            int result = Convert.ToInt32(string.Join("",digits),10);

            return result == number ? -1 : result;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Participates reversed digit array in two parts.
        /// Right part starts from the first digit that was lower than the previous one.
        /// Left part contains other digits before the low one.
        /// </summary>
        /// <param name="digits">Array of digits.</param>
        /// <param name="partOfNumberList">Left part of array.</param>
        /// <param name="fallDigitId">Index of the first lower digit</param>
        /// <param name="biggerDigitId">Index of a digit that is bigger than lower one, but it is minimal from the right part of array</param>
        private static void ParticipateNumberArray(int[] digits, List<int> partOfNumberList, ref int fallDigitId, ref int biggerDigitId)
        {
            for (int i = 0; i < digits.Length - 1; i++)
            {
                partOfNumberList.Add(digits[i]);

                if (digits[i + 1] < digits[i])
                {
                    fallDigitId = i + 1;
                    biggerDigitId = FindMinimalElementBiggerThanFallDigitId(digits[fallDigitId], partOfNumberList.ToArray());
                    break;
                }
            }
        }
        /// <summary>
        /// Converts input integer number
        /// to array that contains number's digits.
        /// </summary>
        /// <param name="number">Number to be converted</param>
        /// <returns>Reversed array of digits.</returns>
        private static int[] NumberToReversedArray(int number)
        {
            var digits = new List<int>();

            while(number > 0)
            {
                digits.Add(number % 10);
                number /= 10;
            }

            return digits.ToArray();
        }
        /// <summary>
        /// Changes values in digit array on values from partOfNumber. Starts on 0 until fallDigitId.
        /// Reverses digit array to achieve right number notation.
        /// </summary>
        /// <param name="digits">Reversed array of digits.</param>
        /// <param name="partOfNumber">Left part of reversed digits array.</param>
        /// <param name="fallDigitId">Index of the first digit that is lower than the previous one.</param>
        private static void  MakeNewNumberFromArrayParts(int[] digits, int[] partOfNumber, int fallDigitId)
        {
            Array.Sort(partOfNumber);
            Array.Reverse(partOfNumber);

            for (int i = 0; i < fallDigitId; i++)
            {
                digits[i] = partOfNumber[i];
            }

            Array.Reverse(digits);
        }
        /// <summary>
        /// Finds minimal value from array which is bigger than 
        /// input digit.
        /// </summary>
        /// <param name="fallDigit">Input digit.</param>
        /// <param name="digits">Array with digits.</param>
        /// <returns>Returns value of the smallest element of array 
        /// which is bigger rhan input digit.</returns>
        private static int FindMinimalElementBiggerThanFallDigitId(int fallDigit, int[] digits)
        {
            int biggerNumberId = 0;
            Array.Sort(digits);

            for (int i = 0; i < digits.Length; i++)
            {
                if( digits[i] > fallDigit)
                {
                    biggerNumberId = i;
                    break;
                }
            }

            return biggerNumberId;
        }
        #endregion
    }
}
