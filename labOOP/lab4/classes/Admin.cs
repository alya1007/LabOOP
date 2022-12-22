using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Admin : Employee
    {
        private const int bonus = 700;

        private const int requiredHours = 150;

        public Admin(string adminName, float adminRate) :
            base(name, hourPay)
        {
            name = adminName;
            Name = adminName;
            hourPay = adminRate;
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
            return $"Admin name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }
}
