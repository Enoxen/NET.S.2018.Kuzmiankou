using System;

namespace nod
{
    /// <summary>
    /// This class provides methods that can find nod of two or many numbers
    /// with Euclid's algorithm and Stein's algorithm
    /// </summary>
    public class Nod
    {
        #region Public methods
        /// <summary>
        /// Public method that takes variable amount of numbers
        /// and find their nod with Euclid's algorithm.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Nod of input numbers.</returns>
        public static int FindNodEuclid(params int[] numbers)
        {
            ValidateInputData(numbers);

            int nod = Gcd(numbers[0], numbers[1]);

            if (numbers.Length > 2)
            {
                for (int i = 2; i < numbers.Length; i++)
                {
                    nod = Gcd(nod, numbers[i]);
                }
            }

            return nod;
        }

        /// <summary>
        /// Public method that takes variable amount of numbers
        /// and find their nod with Stein's algorithm.
        /// </summary>
        /// <param name="numbers">Array of numbers.</param>
        /// <returns>Nod of input numbers.</returns>
        public static int FindSteinsNod(params int[] numbers)
        {
            ValidateInputData(numbers);

            int nod = SteinsNod(numbers[0], numbers[1]);

            if (numbers.Length > 2)
            {
                for (int i = 2; i < numbers.Length; i++)
                {
                    nod = SteinsNod(nod, numbers[i]);
                }
            }

            return nod;
        }
        #endregion

        #region Private methods

        private static void ValidateInputData(int[] numbers)
        {
            if (numbers.Length < 2)
            {
                throw new ArgumentOutOfRangeException(nameof(numbers));
            }

            if (numbers == null)
            {
                throw new ArgumentNullException(nameof(numbers));
            }
        }

        /// <summary>
        /// Private realization of Euclid's NOD algorithm for
        /// two numbers.
        /// </summary>
        /// <param name="firstNumber">First number.</param>
        /// <param name="secondNumber">Second number</param>
        /// <returns>Nod of two numbers</returns>
        private static int Gcd(int firstNumber, int secondNumber)
        {
            while (secondNumber != 0)
            {
                secondNumber = firstNumber % (firstNumber = secondNumber);
            }

            return firstNumber;
        }

        /// <summary>
        /// Private realization of Stein's NOD algorithm for
        /// two numbers.
        /// </summary>
        /// <param name="firstNum">First number.</param>
        /// <param name="secondNum">Second number</param>
        /// <returns>Nod of two numbers</returns> 
        private static int SteinsNod(int firstNum, int secondNum)
        {
            int count = 1;
            while ((firstNum != 0) && (secondNum != 0))
            {
                while ((firstNum % 2 == 0) && (secondNum % 2 == 0))
                {
                    firstNum /= 2;
                    secondNum /= 2;
                    count *= 2;
                }

                while (firstNum % 2 == 0)
                {
                    firstNum /= 2;
                }

                while (secondNum % 2 == 0)
                {
                    secondNum /= 2;
                }

                if (firstNum >= secondNum)
                {
                    firstNum -= secondNum;
                }
                else
                {
                    secondNum -= firstNum;
                }
            }

            return secondNum * count;
        }
        #endregion
    }
}
