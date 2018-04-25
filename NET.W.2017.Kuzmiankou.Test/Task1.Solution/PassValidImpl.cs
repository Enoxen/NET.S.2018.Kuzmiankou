using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    public class PassValidImpl : IPasswordValidator
    {
        public Tuple<bool, string> ValidatePassword(string password)
        {
            if (password.Length > 7 && password. Length < 16)
            {
                return Tuple.Create(true, "pass is ok");
            }
            else
            {
                return Tuple.Create(false, "pass is not ok");
            }
        }
    }
}
