using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Balance : IEntity
    {
        protected static int accNumber;
        protected static float balance;

        public float SetBalance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public int SetAccNumber
        {
            get
            {
                return accNumber;
            }
            set
            {
                accNumber = value;
            }
        }

        public Balance()
        {
        }

        public Balance(int accNr)
        {
            accNumber = accNr;
        }

        public void ChangeBalance(float newBalance)
        {
            balance = newBalance;
            WriteLine($"Balance was updated. Current balance: {balance}$.");
        }

        public override string ToString()
        {
            return $"Account number: {accNumber}, account balance : {balance}$.";
        }
    }
}