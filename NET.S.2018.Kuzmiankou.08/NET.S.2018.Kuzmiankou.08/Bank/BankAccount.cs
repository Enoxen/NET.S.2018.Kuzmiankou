using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NET.S._2018.Kuzmiankou._08
{
    public abstract class BankAccount
    {
        #region Private part
        /// <summary>
        /// Id of a bank account.
        /// </summary>
        private ulong accountNumber;
        /// <summary>
        /// Amount of client's money.
        /// </summary>
        private double amountOfMoney;
        /// <summary>
        /// Amount of bonus points.
        /// </summary>
        private double bonusPoints;
        #endregion

        #region Constructors
        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="accountNumber">Number of account</param>
        /// <param name="name">Name of client.</param>
        /// <param name="surname">Surname of client.</param>
        /// <param name="amountOfMoney">Amount of money.</param>
        /// <param name="bonusPoints">Amount of bonus points.</param>
        public BankAccount(ulong accountNumber, string name, string surname, double amountOfMoney = 0.0, int bonusPoints = 0)
        {
            this.accountNumber = accountNumber;
            Name = name;
            Surname = surname;
            this.amountOfMoney = amountOfMoney;
            this.bonusPoints = bonusPoints;
        }
        #endregion

        #region Public nonvirual methods
        /// <summary>
        /// Returns account number.
        /// </summary>
        public ulong AccountNumber => accountNumber;
        /// <summary>
        /// Returns amount of money.
        /// </summary>
        public double AmountOfMoney => amountOfMoney;
        /// <summary>
        /// Returns bonus points
        /// </summary>
        public double BonusPoints => bonusPoints;
        /// <summary>
        /// Name property
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Surname property.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Adds bonus points to client.
        /// </summary>
        /// <param name="amount">Amount of bonus points.</param>
        public void AddBonusPoints(double amount)
        {
            bonusPoints += amount;
        }
        /// <summary>
        /// Withdraws bonus points.
        /// </summary>
        /// <param name="amount">Amount of bonus points.</param>
        /// <returns></returns>
        public double WithdrawBonusPoints(double amount)
        {
            if (amount <= bonusPoints)
            {
                bonusPoints -= amount;
                return amount;
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(amount) + "на счёте меньше очков, чем вы пытаетесь снять");
            }
        }

        #endregion

        #region Virtual Methods
        /// <summary>
        /// Withdraws money.
        /// </summary>
        /// <param name="money">Amount of money</param>
        /// <returns></returns>
        public virtual double WithdrawMoney(double money)
        {
            if(money > amountOfMoney)
            {
                throw new ArgumentOutOfRangeException(nameof(money));
            }
            else
            {
                amountOfMoney -= money;
                return money;
            }
        }
        /// <summary>
        /// Deposits money.
        /// </summary>
        /// <param name="money">Amount of money.</param>
        public virtual void DepositMoney(double money) => amountOfMoney += money;

        #endregion



    }
}
