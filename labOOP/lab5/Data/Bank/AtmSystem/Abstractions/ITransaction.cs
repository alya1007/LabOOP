namespace lab6
{
    interface ITransaction
    {
        string ViewBalance(){return "";}
        string DepositMoney(int amount){return "";}
        string WithdrawMoney(int amount){return "";}
        string TransferMoney(int amount){return "";}
        string DisplayTransactionInfo(){return "";}
    }
}