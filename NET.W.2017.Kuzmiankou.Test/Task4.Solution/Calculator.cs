using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public static class Calculator
    {
        public static double CalculateAverage(List<double> values, IAveragingMethod method)
        {
            IsNullValues(values);
            return method.CountAverage(values);
        }

        public static double CalculateAverage(List<double> values, Func<IEnumerable<double>, double> method)
        {
            IsNullValues(values);
            return method.Invoke(values);
        }

        private static void IsNullValues(List<double> values)
        {
            if (values is null)
            {
                throw new ArgumentNullException(nameof(values));
            }
        }
    }
}
