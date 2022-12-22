using static System.Console;
using static lab6.extensions.ColoredConsole;
namespace lab6
{
    class Transaction : ITransaction
    {
        private float Balance {get; set;}
        private string? Id {get; set;}
        public DateTime Date {get; set; } = DateTime.Today;
        public string? BankName { get; set; }
        public Transaction(){}
        public Transaction(float currentBalance)
        {
            Balance = currentBalance;
        }
        public string ViewBalance(){
            return "Operation made: View Balance";
        }
        public string DepositMoney(int amount)
        {
            return $"Operation made: Deposit Money. Amount: {amount}";
        }
        public string WithdrawMoney(int amount)
        {
            return $"Operation made: Withdraw Money. Amount: {amount}";

        }
        public string TransferMoney(int amount)
        {
            return $"Operation made: Transfer Money. Amount: {amount}";
        }
        public string CancelOperation(){
            return "Operation made: Cancel";
        }
        public string DisplayTransactionInfo(string? transactionId)
        {
            return "Transaction Details";
        }
    }
}