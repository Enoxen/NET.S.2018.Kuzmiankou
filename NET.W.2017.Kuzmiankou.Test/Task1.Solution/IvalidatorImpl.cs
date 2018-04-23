using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    class IPassLengthValidator :
    {
        public bool ValidatePassword(string password)
        {
            if (password == string.Empty)
                return false;

            // check if length more than 7 chars 
            if (password.Length <= 7)
                return false;

            // check if length more than 10 chars for admins
            if (password.Length >= 15)
                return false;
            return true; ;
        }
    }
}
