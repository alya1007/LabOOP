using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class ATM : ITransaction
    {
        private float balance;
        private string? id;
        public DateTime date = DateTime.Today;
        public string? BankName { get; set; }
        public string? Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public float Balance
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

        public ATM(float currentBalance)
        {
            balance = currentBalance;
        }

        public void DepositMoney(int amount)
        {
            balance += amount;
            WriteLine($"Current balance: {balance}$.");
        }

        public void WithdrawMoney(int amount)
        {
            balance -= amount;
            WriteLine($"Current balance: {balance}$.");
        }

        public void TransferMoney(int amount, string? cardNumber)
        {
            balance -= amount;
            WriteLine($"Transfered {amount}$ on {cardNumber} card number.");
            WriteLine($"Current balance: {balance}$.");
        }

        public void DisplayTransactionInfo()
        {
            WriteLine($"Transaction id: {id}, transaction date: {date}.");
        }

        public override string ToString()
        {
            return $"ATM of {BankName} bank; current balance: {balance}$.";
        }
    }
}