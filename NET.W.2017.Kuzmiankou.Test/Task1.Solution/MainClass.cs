using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Solution
{
    class MainClass
    {
        public static void Main(string[] args) {
            Action<string> createRepo = new SqlRepository().Create;
            IPasswordValidator obj = new IPassLengthValidator();

            var checker = new PasswordCheckerService(obj, createRepo);
            checker.VerifyPassword("1f2345678");
        }
        
    }
}
