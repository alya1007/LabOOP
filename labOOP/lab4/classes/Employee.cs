using System;
using System.IO;

using static System.Console;

namespace lab4
{
    abstract class Employee : IEntity
    {
        protected static float hourPay;

        protected static float monthPay;

        protected static int hWorked;

        protected static string? name;

        public int HoursWorked
        {
            get
            {
                return hWorked;
            }
            set
            {
                hWorked = value;
            }
        }

        public string? Name { get; set; }

        public Employee()
        {
        }

        public Employee(string? emplName, float hRate)
        {
            name = emplName;
            Name = emplName;
            hourPay = hRate;
        }

        public virtual float CalculatePay()
        {
            monthPay = hWorked * hourPay;
            return monthPay;
        }

        public override string ToString()
        {
            return $"Employee name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }
}