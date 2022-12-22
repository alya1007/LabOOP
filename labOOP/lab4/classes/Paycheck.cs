using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Paycheck : IEntity
    {
        private int month;

        private int year;

        enum Months
        {
            JAN = 1,
            FEB = 2,
            MAR,
            APR,
            MAY,
            JUN,
            JUL,
            AUG,
            SEP,
            OCT,
            NOV,
            DEC
        }

        public Paycheck(int monthPay, int yearPay)
        {
            month = monthPay;
            year = yearPay;
        }

        public void GeneratePaycheck(Employee em)
        {
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Paycheck for {(Months)month} {year}");
            WriteLine("-------------------------");
            WriteLine();
            WriteLine($"Employee Name: {em.Name}");
            if (em.GetType() == typeof (Manager))
            {
                WriteLine("Employee Position: Manager");
            } else if (em.GetType() == typeof (Admin))
            {
                WriteLine("Employee Position: Admin");
            }
            WriteLine($"Hours Worked: {em.HoursWorked}");
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Total Pay: {em.CalculatePay()}$.");
            WriteLine("-------------------------");
            WriteLine();
        }
    }
}
