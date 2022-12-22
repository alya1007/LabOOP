using System;
using System.IO;

using static System.Console;

namespace lab2
{
    class Bank
    {
        private int code;

        private string? name;

        public string? Address { get; set; }

        public Bank(string bankName, int bankCade)
        {
            name = bankName;
            code = bankCade;
        }

        public override string ToString()
        {
            return $"Bank name: {name}, code: {code}, address: {Address}.";
        }
    }

    class Account
    {
        private int accNumber;

        private float balance;

        public float Balance
        {
            get
            {
                return balance;
            }
            set
            {
                balance = value;
            }
        }

        public Account(int number)
        {
            accNumber = number;
        }

        public void EditAccount(int newNumber, float newBalance)
        {
            accNumber = newNumber;
            balance = newBalance;
            WriteLine("The account was edited.");
        }

        public override string ToString()
        {
            return $"Account number: {accNumber}, balance: {balance}$.";
        }
    }

    class Customer
    {
        private string? name;

        private string? id;

        private string? email;

        private string? phoneNumber;

        private string? password;

        private string? cardNumber;

        public string? CustomerEmail
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string? CustPhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public string? CustomerPassword
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string? CustCardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                cardNumber = value;
            }
        }

        public Customer(string customerName, string customerId)
        {
            name = customerName;
            id = customerId;
        }

        public override string ToString()
        {
            return $"Customer\n\tname: {name};\n\tid: {id};\n\temail: {email};\n\tphone number: {phoneNumber};\n\tpassword: {password};\n\tcard number: {cardNumber}.";
        }
    }

    class FileReader
    {
        public List<Customer> ReadFile()
        {
            List<Customer> customers = new List<Customer>();
            string[] result = new string[6];
            string path = "customers.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator, StringSplitOptions.RemoveEmptyEntries);
                        Customer c = new Customer(result[0], result[1]);
                        c.CustomerEmail = result[2];
                        c.CustPhoneNumber = result[3];
                        c.CustomerPassword = result[4];
                        c.CustCardNumber = result[5];
                        customers.Add (c);
                    }
                    sr.Close();
                }
            }
            else
            {
                WriteLine("File not found.");
            }
            return customers;
        }
    }

    class ATM
    {
        private float balance;

        public string? BankName{ get; set; }

        public ATM(float currentBalance)
        {
            balance = currentBalance;
        }

        public void DepositMoney(int amount)
        {
            balance += amount;
            WriteLine($"Current balance: {balance}$.");
        }

        public void WithdrawMoney(int amount)
        {
            balance -= amount;
            WriteLine($"Current balance: {balance}$.");
        }

        public void TransferMoney(int amount, string? cardNumber)
        {
            balance -= amount;
            WriteLine($"Transfered {amount}$ on {cardNumber} card number.");
            WriteLine($"Current balance: {balance}$.");
        }

        public override string ToString()
        {
            return $"ATM of {BankName} bank; current balance: {balance}$.";
        }
    }

    class Transaction
    {
        private string? id;

        private float balance;

        public DateTime date = DateTime.Today;

        public Transaction(string? transactionId, float currentBalance)
        {
            id = transactionId;
            balance = currentBalance;
        }

        public override string ToString()
        {
            return $"Transaction id: {id}, date: {date}; current balance {balance}.";
        }
    }

    class Login
    {
        private string? id;

        private string? password;

        public Login(string custId, string custPassword)
        {
            id = custId;
            password = custPassword;
        }

        public void LogIntoSystem()
        {
            WriteLine("Logging into system...");
        }
    }

    class Employee
    {
        private float hourPay;

        private float monthPay;

        private int hWorked;

        public string? Name { get; set; }

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

        public Employee(string emplName, float hRate)
        {
            Name = emplName;
            hourPay = hRate;
        }

        public float CalculatePay()
        {
            monthPay = hWorked * hourPay;
            return monthPay;
        }

        public override string ToString()
        {
            return $"Employee name: {Name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }

    class Manager
    {
        private const int bonus = 500;

        private const int hoursForBonus = 160;

        private float managerHourlyRate;

        private float monthPay;

        private int hWorked;

        public string? Name { get; set; }

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

        public Manager(string managerName, float managerRate)
        {
            Name = managerName;
            managerHourlyRate = managerRate;
        }

        public float CalculateManagerPay()
        {
            if (hWorked > hoursForBonus)
            {
                monthPay = hWorked * managerHourlyRate + bonus;
            }
            else
            {
                monthPay = hWorked * managerHourlyRate;
            }
            return monthPay;
        }

        public override string ToString()
        {
            return $"Manager name: {Name}; hour rate: {managerHourlyRate}$; hours worked: {hWorked}; month salary: {CalculateManagerPay()}$.";
        }
    }

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

        public void GeneratePaycheckEmployee(Employee em)
        {
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Paycheck for {(Months)month} {year}");
            WriteLine("-------------------------");
            WriteLine();
            WriteLine($"Employee name: {em.Name}");
            WriteLine($"Hours Worked: {em.HoursWorked}");
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Total pay: {em.CalculatePay()}");
            WriteLine("-------------------------");
            WriteLine();
        }

        public void GeneratePaycheckManager(Manager manager)
        {
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Paycheck for {(Months)month} {year}");
            WriteLine("-------------------------");
            WriteLine();
            WriteLine($"Employee name: {manager.Name}");
            WriteLine($"Hours Worked: {manager.HoursWorked}");
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Total pay: {manager.CalculateManagerPay()}");
            WriteLine("-------------------------");
            WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //======================
            Bank b1 = new Bank("Moldincombank", 123);
            b1.Address = "Decebal 1";
            WriteLine(b1.ToString());
            //======================
            Account acc1 = new Account(111);
            acc1.Balance = 300;
            WriteLine(acc1.ToString());
            acc1.EditAccount(112, 400);
            WriteLine(acc1.ToString());
            //======================
            Customer c1 = new Customer("Annie", "111222");
            c1.CustomerEmail = "adssad@gmail.com";
            c1.CustPhoneNumber = "079211888";
            c1.CustomerPassword = "strongPassword";
            c1.CustCardNumber = "5084 8822 1144 5544";
            WriteLine(c1.ToString());
            //======================
            FileReader fr = new FileReader();
            List<Customer> list = new List<Customer>();
            list = fr.ReadFile();
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine(list[i].ToString());
            }
            //======================
            ATM operation1 = new ATM(1000.0f);
            operation1.BankName = "Moldincombank";
            WriteLine(operation1.ToString());
            operation1.WithdrawMoney(500);
            operation1.DepositMoney(600);
            operation1.TransferMoney(200, "5555 4444 3333 2222");
            //======================
            Transaction t1 = new Transaction("133442", 3000.0f);
            WriteLine(t1.ToString());
            //======================
            Login log1 = new Login("12324546789", "AlyaAlya");
            log1.LogIntoSystem();
            //======================
            Employee em1 = new Employee("Jane", 200);
            em1.HoursWorked = 150;
            em1.CalculatePay();
            WriteLine(em1.ToString());
            //======================
            Manager m1 = new Manager("Alice", 250);
            m1.HoursWorked = 200;
            m1.CalculateManagerPay();
            WriteLine(m1.ToString());
            //======================
            Paycheck p1 = new Paycheck(12, 2021);
            p1.GeneratePaycheckEmployee(em1);
            Paycheck p2 = new Paycheck(5, 2022);
            p2.GeneratePaycheckManager(m1);
            //======================
        }
    }
}
