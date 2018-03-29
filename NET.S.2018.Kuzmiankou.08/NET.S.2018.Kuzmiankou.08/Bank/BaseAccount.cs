using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Kuzmiankou._08.Bank
{
    
    public class BaseAccount: BankAccount
    {   
        /// <summary>
        /// Coefficient for bonus points
        /// </summary>
        private const int baseBonusDeposit = 1500;
        /// <summary>
        /// Coefficient for bonus points.
        /// </summary>
        private const int baseBonusWithdraw = 1600;
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountNumber">Number of account</param>
        /// <param name="name">Name of client.</param>
        /// <param name="surname">Surname of client.</param>
        /// <param name="amountOfMoney">Amount of money.</param>
        /// <param name="bonusPoints">Amount of bonus points.</param>
        public BaseAccount(ulong accountNumber, string name, string surname, double amountOfMoney = 0, int bonusPoints = 0) : base(accountNumber, name, surname, amountOfMoney, bonusPoints)
        {
        }
        /// <summary>
        /// Deposits money and add bonus points.
        /// </summary>
        /// <param name="money">Amount of money</param>
        public override void DepositMoney(double money)
        {
            AddBonusPoints(money / baseBonusDeposit);
            base.DepositMoney(money);
        }
        /// <summary>
        /// Withdraws money and adds bonus points
        /// </summary>
        /// <param name="money">Amount of money</param>
        /// <returns>Amount of withdrawed money.</returns>
        public override double WithdrawMoney(double money)
        {
            AddBonusPoints(money / baseBonusWithdraw);
            return base.WithdrawMoney(money);
        }
    }
}
