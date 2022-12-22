using System.ComponentModel;
using lab6.Data.Controllers;
using static lab6.extensions.ColoredConsole;
namespace lab6.Data.Views{
    class MainBankView{
        BankController bankController = new BankController();
        public void RealizeView(){
            bankController.SetInfo();
            WriteWhiteLine("\nStarting the system...\n\n");
            WriteWhiteLine("System started!\n\n");
            WriteWhiteLine("Do you have an account?\n\n");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("      -----------");
            Console.WriteLine("      |  Login  |");
            Console.WriteLine("      -----------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("      -----------");
            Console.WriteLine("      | Sign Up |");
            Console.WriteLine("      -----------\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Option: ");
            WriteBlueLine("Sign up\n");

            Console.WriteLine("\nUser signing up...\n");
            WriteWhiteLine("User's name: ");
            WriteBlueLine(bankController.PassName() + "\n");

            WriteWhiteLine("User's ID: ");
            WriteBlueLine(bankController.PassId() + "\n");

            WriteWhiteLine("User's email: ");
            WriteBlueLine(bankController.PassEmail() + "\n");

            WriteWhiteLine("User's phone: ");
            WriteBlueLine(bankController.PassPhone() + "\n");

            WriteWhiteLine("User's card number: ");
            WriteBlueLine(bankController.PassCard() + "\n");

            WriteWhiteLine("\nSign up status: ");
            WriteYellowLine(bankController.PassLogginStatus() + "\n");

            WriteGreenLine("\nUser performed operations: \n");
            foreach(string operation in bankController.PassTransactionsInfo()){
                Console.WriteLine(operation);
            }
        }
    }
}