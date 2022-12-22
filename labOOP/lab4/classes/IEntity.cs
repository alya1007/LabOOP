using System;
using System.IO;

using static System.Console;

namespace lab4
{
    interface IEntity
    {
        void EditAccount(int newNr)
        {
        }

        List<Customer> ReadFile()
        {
            List<Customer> customers = new List<Customer>();
            return customers;
        }

        float CalculatePay()
        {
            return 0;
        }

        void ChangeBalance(float newBalance)
        {
        }
    }
}