using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace NET.S._2018.Kuzmiankou._08
{
    public class SilverAccount : BankAccount
    {
        /// <summary>
        /// Coefficient for bonus points
        /// </summary>
        private const int silverBonusDeposit = 1000;
        /// <summary>
        /// Coefficient for bonus points
        /// </summary>
        private const int silverBonusWithdraw = 1500;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountNumber">Number of account</param>
        /// <param name="name">Name of client.</param>
        /// <param name="surname">Surname of client.</param>
        /// <param name="amountOfMoney">Amount of money.</param>
        /// <param name="bonusPoints">Amount of bonus points.</param>
        public SilverAccount(ulong accountNumber, string name, string surname, double amountOfMoney = 0.0, int bonusPoints = 0) 
            : base(accountNumber, name, surname, amountOfMoney, bonusPoints)
        {
        }
        /// <summary>
        /// Deposits money and add bonus points.
        /// </summary>
        /// <param name="money">Amount of money</param>
        public override void DepositMoney(double money)
        {
            base.DepositMoney(money);
            AddBonusPoints(money / silverBonusDeposit);
        }
        /// <summary>
        /// Withdraws money and add bonus points.
        /// </summary>
        /// <param name="money">Amount of money</param>
        /// <returns>Withdrawed money</returns>
        public override double WithdrawMoney(double money)
        {
            AddBonusPoints(money / silverBonusWithdraw);
            return base.WithdrawMoney(money);
        }
    }
}
