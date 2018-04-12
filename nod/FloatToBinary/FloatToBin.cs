using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace FloatToBinary
{
    public static class FloatToBin
    {
        private const int SIZE = 64;

        #region Public methods
        public static string DoubleToBinaryString(this double number)
        {
            var convert = new DoubleToLongStruct
            {
                double64bits = number
            };

            StringBuilder builder = new StringBuilder();
            long one = 1;
       
            for (int i=0; i < SIZE; i++)
            {
                builder.Append((convert.long64bits & (one << SIZE - 1 - i)) != 0 ? '1' : '0');
            }

            return builder.ToString();
        }
        #endregion
        #region Private section
        [StructLayout(LayoutKind.Explicit)]
        private struct DoubleToLongStruct
        {
            [FieldOffset(0)]
            public readonly long long64bits;

            [FieldOffset(0)]
            public double double64bits;
        }
        #endregion
    }
}
