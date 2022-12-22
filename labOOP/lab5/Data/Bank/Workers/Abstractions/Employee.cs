namespace lab6
{
    abstract class Employee
    {
        protected static float HoursPaid {get; set;}
        protected static float monthPay;
        public static int HoursWorked {get; set;}
        public static string? Name { get; set; }
        public Employee()
        {
        }
        public Employee(string? emplName, float hRate)
        {
            Name = emplName;
            HoursPaid = hRate;
        }
        public virtual float CalculatePay()
        {
            monthPay = HoursWorked * HoursPaid;
            return monthPay;
        }
    }
}