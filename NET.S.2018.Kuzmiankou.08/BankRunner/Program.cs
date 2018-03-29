using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NET.S._2018.Kuzmiankou._08;
namespace BankRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new SilverAccount(1234L,"Егор", "Кузьменков");

            account.DepositMoney(15);
            Console.WriteLine(account.AmountOfMoney);
            Console.WriteLine(account.BonusPoints);
            account.WithdrawMoney(10);
            Console.WriteLine(account.AmountOfMoney);
            Console.WriteLine(account.BonusPoints);
        }
    }
}
