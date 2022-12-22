using static System.Console;
namespace lab6
{
    class Manager : Employee
    {
        private const int bonus = 500;
        private const int requiredHours = 160;
        public Manager(string managerName, float managerRate) :
            base(Name, HoursPaid)
        {
            Name = managerName;
            HoursPaid = managerRate;
        }
        public override float CalculatePay()
        {
            if (HoursWorked > requiredHours)
            {
                monthPay = HoursWorked * HoursPaid + bonus;
                Console.ForegroundColor = ConsoleColor.Green;
                WriteLine("Additional money for more hours worked.");
                Console.ResetColor();
            }
            else if (HoursWorked == requiredHours)
            {
                monthPay = HoursWorked * HoursPaid;
            }
            else
            {
                monthPay = HoursWorked * HoursPaid;
                Console.ForegroundColor = ConsoleColor.Red;
                WriteLine("Not enough hours work this month.");
                WriteLine("Consider firing this employee.");
                Console.ResetColor();
            }
            return monthPay;
        }
    }
}
