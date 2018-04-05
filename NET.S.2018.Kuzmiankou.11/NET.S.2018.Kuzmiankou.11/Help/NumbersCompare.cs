using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Kuzmiankou._11.Help
{
    class NumbersCompare
    {
        public static int CompareNumbers<T>(T first, T second) where T: IComparable<T>
        {
            return first.CompareTo(second);
        }
    }
}
