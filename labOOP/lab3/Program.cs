﻿using System;
using System.IO;

using static System.Console;

namespace lab3
{
    abstract class Entity
    {
        public Entity()
        {
        }

        public virtual void EditAccount(int newNr)
        {
        }

        public virtual List<Customer> ReadFile()
        {
            List<Customer> customers = new List<Customer>();
            return customers;
        }

        public virtual float CalculatePay()
        {
            return 0;
        }
    }

    class Account : Entity
    {
        protected static int accNumber;

        public Account(int accNr) :
            base()
        {
            accNumber = accNr;
        }

        public override void EditAccount(int newNumber)
        {
            accNumber = newNumber;
            WriteLine("The account was edited.");
        }

        public override string ToString()
        {
            return $"Account number: {accNumber}.";
        }
    }

    class Balance : Account
    {
        protected static float balance;

        public float SetBalance
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

        public Balance() :
            base(accNumber)
        {
        }

        public Balance(int accNr) :
            base(accNumber)
        {
            accNumber = accNr;
        }

        public void ChangeBalance(float newBalance)
        {
            balance = newBalance;
            WriteLine($"Balance was updated. Current balance: {balance}$.");
        }

        public override string ToString()
        {
            return $"Account number: {accNumber}, account balance : {balance}$.";
        }
    }

    abstract class ManagementSystem : Entity
    {
        protected static string? name;

        protected static string? id;

        public ManagementSystem(string? custName, string? custId)
        {
            name = custName;
            id = custId;
        }
    }

    class Customer : ManagementSystem
    {
        private string? email;

        private string? phoneNumber;

        protected string? password;

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

        public Customer(string? customerName, string? customerId) :
            base(name, id)
        {
            name = customerName;
            id = customerId;
        }

        public override string ToString()
        {
            return $"Customer\n\tname: {name};\n\tid: {id};\n\temail: {email};\n\tphone number: {phoneNumber};\n\tpassword: {password};\n\tcard number: {cardNumber}.";
        }
    }

    class Status : ManagementSystem
    {
        private State accStatus;

        private DateTime lastUpdate = new DateTime();

        public State AccStatus
        {
            get
            {
                return accStatus;
            }
            set
            {
                accStatus = value;
            }
        }

        public DateTime LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
            }
        }

        public enum State
        {
            Active,
            Frozen,
            Inactive
        }

        public Status(string? custName, string? custId) :
            base(name, id)
        {
            name = custName;
            id = custId;
        }

        public void UpdateStatus(State newStatus)
        {
            accStatus = newStatus;
            AccStatus = newStatus;
            lastUpdate = DateTime.Today;
            LastUpdate = DateTime.Today;
            WriteLine($"Status updated. Current state: {accStatus}");
        }

        public override string ToString()
        {
            return $"Account status: {accStatus}, last update: {lastUpdate}.";
        }
    }

    class FileReader : Entity
    {
        public override List<Customer> ReadFile()
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
                        result = sr.ReadLine().Split(separator,StringSplitOptions.RemoveEmptyEntries);
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

    class ATM : Balance
    {
        public string? BankName { get; set; }

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

    class Transaction : ATM
    {
        private string? id;

        public DateTime date = DateTime.Today;

        public Transaction(string? transactionId, float currentBalance) :
            base(balance)
        {
            id = transactionId;
            balance = currentBalance;
        }

        public override string ToString()
        {
            return $"Transaction id: {id}, date: {date}; current balance {balance}$.";
        }
    }

    class Login : Customer
    {
        public Login(string? custId) :
            base(name, id)
        {
            id = custId;
        }

        public void LogIntoSystem()
        {
            WriteLine("Logging into system...");
        }
    }

    abstract class Employee : Entity
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

        public override float CalculatePay()
        {
            monthPay = hWorked * hourPay;
            return monthPay;
        }

        public override string ToString()
        {
            return $"Employee name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }

    class Manager : Employee
    {
        private const int bonus = 500;

        private const int hoursForBonus = 160;

        public Manager(string managerName, float managerRate) :
            base(name, hourPay)
        {
            name = managerName;
            Name = managerName;
            hourPay = managerRate;
        }

        public override float CalculatePay()
        {
            if (hWorked > hoursForBonus)
            {
                monthPay = hWorked * hourPay + bonus;
            }
            else
            {
                monthPay = hWorked * hourPay;
            }
            return monthPay;
        }

        public override string ToString()
        {
            return $"Manager name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }

    class Admin : Employee
    {
        private const int bonus = 700;

        private const int hoursForBonus = 150;

        public Admin(string adminName, float adminRate) :
            base(name, hourPay)
        {
            name = adminName;
            Name = adminName;
            hourPay = adminRate;
        }

        public override float CalculatePay()
        {
            if (hWorked > hoursForBonus)
            {
                monthPay = hWorked * hourPay + bonus;
            }
            else
            {
                monthPay = hWorked * hourPay;
            }
            return monthPay;
        }

        public override string ToString()
        {
            return $"Admin name: {name}; hour rate: {hourPay}$; hours worked: {hWorked}; month salary: {CalculatePay()}$.";
        }
    }

    class Paycheck : Employee
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
            WriteLine($"Hours Worked: {em.HoursWorked}");
            WriteLine();
            WriteLine("-------------------------");
            WriteLine($"Total Pay: {em.CalculatePay()}$.");
            WriteLine("-------------------------");
            WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //======================
            Account acc1 = new Account(111);
            WriteLine(acc1.ToString());
            acc1.EditAccount(123);
            WriteLine(acc1.ToString());
            WriteLine();
            //======================
            Balance bl = new Balance(4456);
            bl.SetBalance = 950.0f;
            WriteLine(bl.ToString());
            bl.ChangeBalance(1000.0f);
            WriteLine(bl.ToString());
            WriteLine();
            //======================
            Customer c1 = new Customer("Annie", "111222");
            c1.CustomerEmail = "adssad@gmail.com";
            c1.CustPhoneNumber = "079211888";
            c1.CustomerPassword = "strongPassword";
            c1.CustCardNumber = "5084 8822 1144 5544";
            WriteLine(c1.ToString());
            WriteLine();
            //======================
            Status st = new Status("Annie", "1234567");
            st.AccStatus = 0;
            st.LastUpdate = new DateTime(2000, 12, 31);
            WriteLine(st.ToString());
            st.UpdateStatus(Status.State.Frozen);
            WriteLine(st.ToString());
            WriteLine();
            //======================
            FileReader fr = new FileReader();
            List<Customer> list = new List<Customer>();
            list = fr.ReadFile();
            for (int i = 0; i < list.Count; i++)
            {
                WriteLine(list[i].ToString());
            }
            WriteLine();
            //======================
            ATM operation1 = new ATM(1000.0f);
            operation1.BankName = "Moldincombank";
            WriteLine(operation1.ToString());
            operation1.WithdrawMoney(500);
            operation1.DepositMoney(600);
            operation1.TransferMoney(200, "5555 4444 3333 2222");
            WriteLine();
            //======================
            Transaction t1 = new Transaction("133442", 3000.0f);
            WriteLine(t1.ToString());
            WriteLine();
            // ======================
            Login log1 = new Login("12324546789");
            log1.LogIntoSystem();
            WriteLine();
            // ======================
            Manager m1 = new Manager("Alice", 250);
            m1.HoursWorked = 30;
            m1.CalculatePay();
            WriteLine(m1.ToString());
            WriteLine();
            // ======================
            Admin ad = new Admin("Jonh", 399.0f);
            ad.HoursWorked = 20;
            ad.CalculatePay();
            WriteLine(ad.ToString());
            // ======================
            Paycheck p = new Paycheck(3, 2022);
            p.GeneratePaycheck(ad);
            //======================
        }
    }
}