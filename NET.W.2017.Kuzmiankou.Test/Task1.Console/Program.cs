using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Solution;

namespace Task1.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<IPasswordValidator>
            {
                new PassValidImpl()
            };
            var checker = new PasswordCheckerService(new SqlRepository());
            checker.VerifyPassword("12345678", list);
        }
    }
}
