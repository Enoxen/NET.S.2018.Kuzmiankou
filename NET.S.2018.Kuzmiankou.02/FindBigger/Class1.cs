using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindBigger
{
    public class Class1
    {
        #region Public methods
        public static int FindNextBiggerNumber(int number)
        {
            if(number <= 0 || number == int.MaxValue)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            


            return 0;
        }
        #endregion
    }
}
