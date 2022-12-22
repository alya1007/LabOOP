using lab6.Data.Models;
namespace lab6.Data.Controllers{
    class BankController{
        protected Bank bankModel = new Bank();
        protected string? CustomerName;
        protected string? CustomerId;
        protected string? CustomerEmail;
        protected string? CustomerPhone;
        protected string? CustomerPassword;
        protected string? CustomerCardNumber;
        protected string? LogginStatus;
        protected List<string> TransactionsInfo = new List<string>();
        protected int TransactionsCount;
        
        public void SetInfo(){
            bankModel.ExecuteAccountModel();
            bankModel.ExecuteTransactionModel();
            CustomerName = bankModel.SetCustomerName();
            CustomerId = bankModel.SetCustomerId();
            CustomerEmail = bankModel.SetCustomerEmail();
            CustomerPhone = bankModel.SetCustomerPhone();
            CustomerCardNumber = bankModel.SetCustomerCard();
            LogginStatus = bankModel.LogginStatus;
            TransactionsInfo = bankModel.SetTransactionsInfo();
            TransactionsCount = bankModel.SetTransactionsCount();
        }

        public string? PassName(){
            return CustomerName;
        }

        public string? PassId(){
            return CustomerId;
        }

        public string? PassEmail(){
            return CustomerEmail;
        }

        public string? PassPhone(){
            return CustomerPhone;
        }

        public string? PassCard(){
            return CustomerCardNumber;
        }

        public string? PassLogginStatus(){
            return LogginStatus;
        }

        public List<string> PassTransactionsInfo(){
            return TransactionsInfo;
        }

        public int PassTransactionsCount(){
            return TransactionsCount;
        }

    }
}