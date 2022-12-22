using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Manager : Employee
    {
        private const int bonus = 500;

        private const int requiredHours = 160;

        public Manager(string managerName, float managerRate) :
            base(name, hourPay)
        {
            name = managerName;
            Name = managerName;
            hourPay = managerRate;
        }

        public override float CalculatePay()
        {
            if (hWorked > requiredHours)
            {
                monthPay = hWorked * hourPay + bonus;
                WriteLine("Additional money for more hours worked.");

            }
            else if (hWorked == requiredHours)
            {
                monthPay = hWorked * hourPay;
            }
            else
            {
                monthPay = hWorked * hourPay;
                WriteLine("Not enough hours work this month.");
                WriteLine("Consider firing this employee.");
            }
            return monthPay;
        }

        public override string ToString()
        {
            return $"Manager name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }
}
