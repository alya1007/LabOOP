using static System.Console;
namespace lab6
{
    class Paycheck
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
            Console.ForegroundColor = ConsoleColor.Blue;
            WriteLine($"Paycheck for {(Months)month} {year}");
            Console.ResetColor();
            WriteLine("-------------------------");
            WriteLine();
            Write("Employee Name: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Write(Employee.Name + "\n");
            Console.ResetColor();
            if (em.GetType() == typeof (Manager))
            {
                Write("Employee Position: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Write("Manager\n");
                Console.ResetColor();

            } else if (em.GetType() == typeof (Admin))
            {
                Write("Employee Position: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                Write("Admin\n");
                Console.ResetColor();
            }
            Write("Hours Worked: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Write(Employee.HoursWorked + "\n");
            Console.ResetColor();
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Total Pay: {em.CalculatePay()}$.");
            WriteLine("-------------------------");
            WriteLine();
        }
    }
}
