using System;

namespace Polynomial
{   
    /// <summary>
    /// This class represents polynom of single variable.
    /// </summary>
    public sealed class Polynom 
    {
        /// <summary>
        /// Epsilon for equality check.
        /// </summary>
        private static double epsilon;

        /// <summary>
        /// Coefficients.
        /// </summary>
        private readonly double[] coeff;
        
        /// <summary>
        /// Constructor to init coefficients.
        /// </summary>
        /// <param name="coeff">Amount of double numbers or double array.</param>
        public Polynom(params double[] coeff)
        {
            this.coeff = new double[coeff.Length];

            for (int i = 0; i < coeff.Length; i++)
            {
                this.coeff[i] = coeff[i];
            }
        }

        /// <summary>
        /// Static constructor for epsilon initialization.
        /// </summary>
        static Polynom()
        {
            epsilon = double.Parse(System.Configuration.ConfigurationManager.AppSettings["epsilon"]);
        }

        #region Properties
        
        /// <summary>
        /// Gets degree of polynom.
        /// </summary>
        public int Degree
        {
            get
            {
                if (this.coeff == null)
                {
                    throw new ArgumentNullException($"{nameof(coeff)} is null");
                }

                return this.coeff.Length - 1;
            }
        }
        #endregion

        /// <summary>
        /// Returns coefficient by index.
        /// </summary>
        /// <param name="number">Index of coefficient.</param>
        /// <returns>Returns coefficient by index.</returns>
        public double this[int number]
        {
            get
            {
                if (number < 0 || number > this.coeff.Length - 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(number)} index number is out of range");
                }

                return this.coeff[number];
            }
        }

        #region Operators
        /// <summary>
        /// Sum operator of two polynoms.
        /// </summary>
        /// <param name="lhs">Left operand.</param>
        /// <param name="rhs">Right operand.</param>
        /// <returns>Returns new Polynom object.</returns>
        public static Polynom operator +(Polynom lhs, Polynom rhs)
        {
            double[] array = new double[Math.Max(lhs.Degree, rhs.Degree) + 1];

            for (int i = 0; i <= Math.Min(lhs.Degree, rhs.Degree); i++)
            {
                array[i] = lhs[i] + rhs[i];
            }

            if (lhs.Degree > rhs.Degree)
            {
               for (int i = rhs.Degree + 1; i <= lhs.Degree; i++)
                {
                    array[i] = lhs[i];
                }
            }

            if (rhs.Degree > lhs.Degree)
            {
                for (int i = lhs.Degree + 1; i <= rhs.Degree; i++)
                {
                    array[i] = rhs[i];
                }
            }

            return new Polynom(array);
        }
        /// <summary>
        /// Subtraction operator of two polynoms.
        /// </summary>
        /// <param name="lhs">Left operand.</param>
        /// <param name="rhs">Right operand.</param>
        /// <returns>New Polynom object.</returns>
        public static Polynom operator -(Polynom lhs, Polynom rhs)
        {
            return lhs + (-rhs);
        }

        /// <summary>
        /// Multiplication operator for two polynoms.
        /// </summary>
        /// <param name="lhs">Left operand.</param>
        /// <param name="rhs">Right operand.</param>
        /// <returns>New Polunom object.</returns>
        public static Polynom operator *(Polynom lhs,Polynom rhs)
        {
            double[] array = new double[lhs.Degree + rhs.Degree + 1];

            for (int i = 0; i <= lhs.Degree; i++)
            {
                for (int j = 0; j <= rhs.Degree; j++)
                { 
                    array[i + j] += lhs[i] * rhs[j]; 
                }
            }

            return new Polynom(array);
        }

        /// <summary>
        /// Inversion operator of one polynom.
        /// </summary>
        /// <param name="polynom">Operand.</param>
        /// <returns>Inversed new version of operand.</returns>
        public static Polynom operator-(Polynom polynom)
        {
            double[] array = new double[polynom.Degree + 1];

            for (int i = 0; i <= polynom.Degree; i++)
            {
                array[i] = (-1) * polynom[i];
            }

            return new Polynom(array);
        }

        /// <summary>
        /// Equality operator.
        /// </summary>
        /// <param name="lhs">Left operand.</param>
        /// <param name="rhs">Right operand.</param>
        /// <returns>Bool value that represents coefficient equality of two polynoms.</returns>
        public static bool operator ==(Polynom lhs, Polynom rhs)
        {
            if (lhs.Degree != rhs.Degree)
            {
                return false;
            }

            for (int i = 0; i <= lhs.Degree; i++)
            {
                if (lhs[i] != rhs[i])
                {
                    return false;
                }
            }

            return true;
        }
        /// <summary>
        /// Reverse operation to equality.
        /// </summary>
        /// <param name="lhs">Left operand.</param>
        /// <param name="rhs">Right operand.</param>
        /// <returns>Reversed value of == operator.</returns>
        public static bool operator !=(Polynom lhs, Polynom rhs)
        {
            return !(lhs == rhs);
        }
        #endregion

        #region Object methods
        public override string ToString()
        {
            return base.ToString();
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion
    }
}
