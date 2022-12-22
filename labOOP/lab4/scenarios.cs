using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Scenarios
    {
        public void Scenario1()
        {
            //================CreateAcc=================
            //scenarios for:
            //setting wrong phone nr. card nr, password,
            //logging with incorrect acc nr or password
            WriteLine("Create a new bank account;");
            Random rnd = new Random();
            Account acc1 = new Account(rnd.Next(1, 1000)); //new acc with rand number
            WriteLine("Introduce your name: ");
            string? name = ReadLine();
            WriteLine("Introduce your passport id: ");
            string? id = ReadLine();
            Status st = new Status(name, id);  //set status of acc
            st.AccStatus = Status.State.Active;
            Customer cus1 = new Customer(name, id);
            WriteLine("Introduce your phone number (with 0 at start): ");
            cus1.CustPhoneNumber = ReadLine();
            while(cus1.CustPhoneNumber?.Length != 9){
                WriteLine("Invalid phone number, please insert correct one.");
                cus1.CustPhoneNumber = ReadLine();
            }
            WriteLine("Introduce your card number: ");
            cus1.CustCardNumber = ReadLine();
            while(cus1.CustCardNumber?.Length != 16){
                WriteLine("Invalid card number, please insert correct one.");
                cus1.CustCardNumber = ReadLine();
            }
            WriteLine("Introduce your email (optional): ");
            cus1.CustomerPassword = ReadLine();

            WriteLine("Create a password for your account (at least 8 characters): ");
            cus1.CustomerPassword = ReadLine();
            while(cus1.CustomerPassword?.Length < 8)
            {
                WriteLine("Not enough characters! Please, enter another password.");
                cus1.CustomerPassword = ReadLine();
            }
            WriteLine("Account successfully created!");
            WriteLine(acc1.ToString());
            WriteLine("To log into system, introduce your account number and password.");
            WriteLine("Account number: ");
            while(Convert.ToInt32(ReadLine()) != acc1.AccNumber)
            {
                WriteLine("Inexistent Account number. Introduce correct one.");
            }
            WriteLine("Password: ");
            int attempts = 2;
            while((ReadLine() != cus1.CustomerPassword) && attempts > 0)
            {
                WriteLine($"Incorrect password. Reamined attempts: {attempts}");
                attempts--;
            }
            if(attempts == 0)
            {
                st.AccStatus = Status.State.Frozen;
                WriteLine($"Account status: {st.AccStatus}");
            }
            else
            {
                cus1.LogInSystem(cus1.CustomerPassword);
                WriteLine("Logging in completed!");
            }
        }

        public void Scenario2()
        {
            //================CheckingBalance=================
            // scenarios for checking the balance
            // outputing balance of account
            // scenarios for active, frozen and blocked account
            
            // outputin balance of account for active account
            Account acc = new Account(1111);
            Status st = new Status("Angela", "123123");
            st.AccStatus = Status.State.Active;
            WriteLine("Introduce number of account to check current balance: ");
            int nr = Convert.ToInt32(ReadLine());
            while(acc.AccNumber != nr)
            {
                WriteLine("Account with this number doesn't exist. Introduce valid number: ");
                nr = Convert.ToInt32(ReadLine());
            }
            Balance bl = new Balance(nr);
            bl.SetBalance = 10000.0f;
            WriteLine($"Account status: {st.AccStatus}");
            WriteLine(bl.ToString());
            WriteLine();

            // outputin balance of account for frozen account
            Account acc2 = new Account(2222);
            Status st2 = new Status("Mark", "321321");
            st2.AccStatus = Status.State.Frozen;
            WriteLine("Introduce number of account to check current balance: ");
            int nr2 = Convert.ToInt32(ReadLine());
            while(acc2.AccNumber != nr2)
            {
                WriteLine("Account with this number doesn't exist. Introduce valid number: ");
                nr2 = Convert.ToInt32(ReadLine());
            }
            Balance bl2 = new Balance(nr2);
            bl2.SetBalance = 0f;
            WriteLine($"Account status: {st2.AccStatus}");
            WriteLine(bl2.ToString());
        }

        public void Scenario3()
        {
            //================Transactions=================
            //scenarios for performing different types of transactions
            //transactions fail when introducing incorrect amount of money
            //or invalid card number (for transfering)
            Random anotherRnd = new Random();
            Balance bl = new Balance(anotherRnd.Next(1, 1000));
            bl.SetBalance = 10000.0f;
            WriteLine(bl.ToString());
            ATM atm1 = new ATM(bl.SetBalance);
            WriteLine("Operations to perform:");
            WriteLine("\t1 - deposit money;");
            WriteLine("\t2 - withdraw money;");
            WriteLine("\t3 - transfer money;");
            string? option;
            int am;
            string? cardNr;
            string? op;
            while(true)
            {
                Write("Choose operation: ");
                option = ReadLine();
                switch (option)
                {
                    case "1" :
                        WriteLine("Amount to deposit: ");
                        am = Convert.ToInt32(ReadLine());
                        atm1.DepositMoney(am);
                        break;
                    case "2" :
                        WriteLine("Amount to withdraw: ");
                        am = Convert.ToInt32(ReadLine());
                        while(am > atm1.Balance){
                            WriteLine("Error, to much money to withdraw. Introduce valid value.");
                            am = Convert.ToInt32(ReadLine());
                        }
                        atm1.WithdrawMoney(am);
                        break;
                    case "3" :
                        WriteLine("Amount to transfer: ");
                        am = Convert.ToInt32(ReadLine());
                        while(am > atm1.Balance){
                            WriteLine("Error, to much money to withdraw. Introduce valid value.");
                            am = Convert.ToInt32(ReadLine());
                        }
                        WriteLine("Card to transfer: ");
                        cardNr = ReadLine();
                        while(cardNr?.Length != 16){
                            WriteLine("Error, incorrect number of card. Introduce the correct one.");
                            cardNr = ReadLine();
                        }
                        atm1.TransferMoney(am, cardNr);
                        break;
                    default:
                        break;
                }
                WriteLine("Want to perform another operation? (y/n)");
                op = ReadLine();
                if(op == "n")
                {
                    break;
                } else if(op != "y")
                {
                    WriteLine("Type y or n");
                }
            }
        }

        public void Scenario4()
        {
            //================GeneratingSalary=================
            //Scenario for generating paychecks, in case the employee
            //worked needed amount of time, more than this needed value
            //or less than required amount of time
            Manager manager1 = new Manager("Alice Cooper", 30);
            Admin admin1 = new Admin("John Doe", 25);
            Admin admin2 = new Admin("Walter White", 30);
            // Manager1 worked required amount of time for a month
            // without additional time
            manager1.HoursWorked = 160;
            Paycheck payManager1 = new Paycheck(12, 2022);
            payManager1.GeneratePaycheck(manager1);
            // Admin1 worked more than required time for a month
            admin1.HoursWorked = 170;
            Paycheck payAdmin1 = new Paycheck(12, 2022);
            payAdmin1.GeneratePaycheck(admin1);
            // Admin2 worked less than required time for a month
            admin2.HoursWorked = 100;
            Paycheck payAdmin2 = new Paycheck(12, 2022);
            payAdmin2.GeneratePaycheck(admin2);

        }
    }
}