using static System.Console;
namespace lab6
{
    class Admin : Employee
    {
        private const int bonus = 700;
        private const int requiredHours = 150;
        public Admin(string adminName, float adminRate) :
            base(Name, HoursPaid)
        {
            Name = adminName;
            HoursPaid = adminRate;
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
