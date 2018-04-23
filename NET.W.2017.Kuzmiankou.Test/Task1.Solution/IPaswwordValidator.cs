using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    interface IPasswordValidator
    {
        Tuple<bool, string> ValidatePassword(string password);
        string GetErrorMessage();
        
    }
}
