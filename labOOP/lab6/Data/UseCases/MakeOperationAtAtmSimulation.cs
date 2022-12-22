using static System.Console;
using static lab6.extensions.ColoredConsole;
namespace lab6.Data.UseCases{
    class MakeOperationAtAtmSimulation{
        public void MakeOperationAtATM(
            Customer cust
        )
        {
            List<int> values = new List<int>() { 50, 100, 200, 500, 1000 };
            Random rd = new Random();
            Account ac = new Account();
            ac.Balance = rd.Next(2000, 3000);
            List<Action> operations = new List<Action>();
            Transaction atm = new Transaction(ac.Balance);
            int randForWithdraw = values[rd.Next(0, values.Count)];
            int randForTransfer = values[rd.Next(0, values.Count)];
            int randForDeposit = values[rd.Next(0, values.Count)];
            Action op1 = () => atm.WithdrawMoney(randForWithdraw);
            Action op2 = () => atm.DepositMoney(randForDeposit);
            // Action op3 =
            //     () => atm.TransferMoney(randForTransfer, cust.CustCardNumber);
            Action op4 = () => atm.ViewBalance();
            operations.Add (op1);
            operations.Add (op2);
            // operations.Add (op3);
            operations.Add (op4);
            int rand1 = rd.Next(0, 50);
            Status st =
                new Status(cust.Name, cust.Id);
            WriteLine("Insert your card.");
            WriteLine("Client inserts card...");
            WriteLine();
            if (st.AccStatus == Status.State.Active)
            {
                repeat:
                Write("Enter PIN: ");
                if (rd.NextDouble() > 0.35)
                {
                    WriteBlueLine("****\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Write("      -----------\n");
                    Write("      | Balance |\n");
                    Write("      -----------\n");

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Write("      -----------\n");
                    Write("      | Deposit |\n");
                    Write("      -----------\n");

                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Write("      ------------\n");
                    Write("      | Withdraw |\n");
                    Write("      ------------\n");

                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Write("      ------------\n");
                    Write("      | Transfer |\n");
                    Write("      ------------\n");
                    WriteLine();

                    Console.ForegroundColor = ConsoleColor.White;
                    Write("Choose an operation: ");

                    if(rd.NextDouble() > 0.8)
                    {
                        WriteBlueLine("Cancel.\n");
                        atm.CancelOperation();
                    }
                    else{
                        int randForOperation1 = rd.Next(0, operations.Count);
                        operations[randForOperation1]();
                        operations.RemoveAt (randForOperation1);
    
                        Write("Print paycheck? ");
    
                        if (rd.NextDouble() >= 0.7)
                        {
                            WriteBlueLine("Yes.\n");
                            atm
                                .DisplayTransactionInfo(rd
                                    .Next(100000, 1000000)
                                    .ToString());
        
                        }
                        else
                        {
                            WriteGreenLine("No.\n");
                        }
                        WriteLine();
                        Write("Do you want to make another operation? ");
    
                        while ((rd.NextDouble() < 0.5) && (operations.Count != 0))
                        {
                            WriteBlueLine("Yes.\n");
                            int randForOperation2 = rd.Next(0, operations.Count);
                            operations[randForOperation2]();
                            operations.RemoveAt (randForOperation2);
                            Write("Print paycheck? ");
        
                            if (rd.NextDouble() >= 0.7)
                            {
                                WriteBlueLine("Yes.\n");
                                atm
                                    .DisplayTransactionInfo(rd
                                        .Next(100000, 1000000)
                                        .ToString());
            
                            }
                            else
                            {
                                WriteGreenLine("No.\n");
                            }
                            Write("\nDo you want to make another operation? ");
                            WriteLine();
                        }
                        WriteBlueLine("No.\n");
                        atm.CancelOperation();
                    }
                }
                else
                {
                    WriteRedLine("****\n");
                    WriteRedLine("Incorrect PIN!\n");
                    WriteLine();
                    atm.CancelOperation();
                    WriteLine();
                    if(rd.NextDouble() < 0.8){
                        WriteLine("Client inserts card...");
                        goto repeat;
                    }
                }
            }
            else
            {
                WriteRedLine("Account invalid!");
            }
        }


    }

}