using static System.Console;
using static lab6.extensions.ColoredConsole;
namespace lab6.Data.UseCases
{
    public class MakeAccountSimulation{
        public void MakeBankAccount(Customer customer){
        WriteWhiteLine("Starting the system...");
        WriteWhiteLine("System started!");
        WriteLine();
        WriteWhiteLine("Do you have an account?\n");
        Thread.Sleep(Program.DELAY_TIME);
        Console.ForegroundColor = ConsoleColor.Green;
        WriteWhiteLine("      -----------\n");
        WriteWhiteLine("      |  Login  |\n");
        WriteWhiteLine("      -----------\n");
        Console.ForegroundColor = ConsoleColor.Yellow;
        WriteWhiteLine("      -----------\n");
        WriteWhiteLine("      | Sign Up |\n");
        WriteWhiteLine("      -----------\n");
        Console.ForegroundColor = ConsoleColor.White;
        Write("Option: ");
        Random rd = new Random();
        double rand = rd.NextDouble();
        int rand1 = rd.Next(0, 50);
        if (rand < 0.5)
        {
            WriteBlueLine("Login.");
            WriteLine("\nCreate a new bank account.");
            WriteWhiteLine("Introduce your name: ");

            WriteBlueLine(customer.Name + "\n");
            WriteWhiteLine("Introduce your ID: ");

            WriteBlueLine(customer.Id + "\n");
            WriteWhiteLine("Introduce your email: ");

            WriteBlueLine(customer.CustomerEmail + "\n");
            WriteWhiteLine("Introduce your phone: ");

            double randForPhone = rd.NextDouble();
            while (rd.NextDouble() > 0.6)
            {
                WriteRedLine("06" + rd.Next(11111, 99999));
                WriteRedLine("\nIncorect format! 8 digits required!\n");
            }
            WriteBlueLine(customer.CustPhoneNumber + "\n");
            WriteLine("Create a password (at least 6 characters): ");

            WriteBlueLine(customer.CustomerPassword + "\n");
            Account acc1 = new Account();
            acc1.CreateAccount(customer);
            acc1.AccNumber = customer.Id;
            WriteLine("Creating a new account...");

            WriteGreenLine("Account created!\n");

            Status st1 =
                new Status(customer.Name,
                    customer.Id);
            st1.UpdateStatus(Status.State.Active);
            Thread.Sleep(Program.DELAY_TIME);
            Write("Do you want to log in? ");

            if (rd.NextDouble() < 5)
            {
                WriteBlueLine("Yes\n");
                Write("Account Number: ");

                int k = 0;
                while (rd.NextDouble() > 0.5 && k < 3)
                {
                    WriteRedLine(acc1.AccNumber + rd.Next(0, 100));
                    WriteRedLine("\nIncorrect account number!\n");
                    k++;
                }
                if (k >= 3)
                {
                    WriteRedLine("Logging failed.\n");
                    st1.UpdateStatus(Status.State.Frozen);
                    Thread.Sleep(Program.DELAY_TIME);
                }
                else
                {
                    WriteBlueLine(acc1.AccNumber!);
                    k = 0;
                    Write("\nPassword: ");

                    while (rd.NextDouble() > 0.6 && k < 3)
                    {
                        WriteRedLine(customer.CustomerPassword + rd.Next(0, 100));
                        WriteRedLine("\nIncorrect password!\n");
                        k++;
                    }
                    if (k >= 3)
                    {
                        WriteRedLine("Logging failed.\n");
                        st1.UpdateStatus(Status.State.Frozen);
                        Thread.Sleep(Program.DELAY_TIME);
                    }
                    else{
                        WriteBlueLine(customer.CustomerPassword!);
                        WriteGreenLine("\nLogging succeed!\n");
                    }
                }
            }
            else
            {
                WriteBlueLine("No. \n");
            }
        }
        else
        {

            WriteBlueLine("Sign Up.\n");
            Account acc2 = new Account();
            acc2.CreateAccount(customer);
            acc2.AccNumber = customer.Id;
            Status st2 =
                new Status(customer.Name,
                    customer.Id);
            Write("Account Number: ");

                int k = 0;
                while (rd.NextDouble() > 0.5 && k < 3)
                {
                    WriteRedLine(acc2.AccNumber + rd.Next(0, 100));
                    WriteRedLine("\nIncorrect account number!\n");
                    k++;
                }
                if (k >= 3)
                {
                    WriteRedLine("Logging failed.\n");
                    st2.UpdateStatus(Status.State.Frozen);
                    Thread.Sleep(Program.DELAY_TIME);
                }
                else
                {
                    WriteBlueLine(acc2.AccNumber!);
                    k = 0;
                    Write("\nPassword: ");

                    while (rd.NextDouble() > 0.6 && k < 3)
                    {
                        WriteRedLine(customer.CustomerPassword + rd.Next(0, 100));
                        WriteRedLine("\nIncorrect password!\n");
                        k++;
                    }
                    if (k >= 3)
                    {
                        WriteRedLine("Logging failed.\n");
                        st2.UpdateStatus(Status.State.Frozen);
                        Thread.Sleep(Program.DELAY_TIME);
                    }
                    else{
                        WriteBlueLine(customer.CustomerPassword!);
                        WriteGreenLine("\nLogging succeed!\n");
                    }
                }
        }
        }

    }
}