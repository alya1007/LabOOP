using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Account : IEntity
    {
        public int AccNumber {get; set;}

        public Account(int accNr) :
            base()
        {
            AccNumber = accNr;
        }

        public void EditAccount(int newNumber)
        {
            AccNumber = newNumber;
            WriteLine("The account was edited.");
        }

        public override string ToString()
        {
            return $"Account number: {AccNumber}.";
        }
    }
}