using System;
using System.IO;

using static System.Console;

namespace lab4
{
    interface ITransaction : IEntity
    {
        void DepositMoney(int amount){}

        void WithdrawMoney(int amount){}
        void TransferMoney(int amount, string? cardNumber){}
        void DisplayTransactionInfo(){}
    }
}