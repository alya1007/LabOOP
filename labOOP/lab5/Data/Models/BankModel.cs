namespace lab6.Data.Models
{
    class Bank
    {
        private Account userAccount = new Account();
        private FileReader fileReader = new FileReader();
        private List<Customer> customerList = new List<Customer>();
        private Customer customer = new Customer();
        private Status status = new Status();
        private Random random = new Random();
        private Transaction transaction = new Transaction();
        public string? CustomerName;
        public string? CustomerId;
        public string? CustomerEmail;
        public string? CustomerPhone;
        public string? CustomerPassword;
        public string? CustomerCardNumber;
        public string? LogginStatus;
        public List<string> TransactionsInfo = new List<string>();
        public int TransactionsCount;

        public void ExecuteAccountModel()
        {
            customerList = fileReader.ReadFile(50, "Data/Models/customers.txt");
            customer = customerList[random.Next(0, 40)];
            CustomerPassword = customer.CustomerPassword;
            double rand = random.NextDouble();
            if (rand <= 0.33)
            {
                status.AccStatus = Status.State.Inactive;
            }
            else if (rand < 0.33 && rand >= 0.66)
            {
                status.AccStatus = Status.State.Frozen;
            }
            else
            {
                status.AccStatus = Status.State.Active;
            }
            if (status.AccStatus == Status.State.Active)
            {
                LogginStatus = "Loggin succeed";
            }
            else
            {
                LogginStatus = "Loggin failed";
            }
        }

        public void ExecuteTransactionModel()
        {
            List<int> values = new List<int>() { 50, 100, 200, 500, 1000 };
            TransactionsCount = random.Next(1, 4);
            for (int i = 0; i < TransactionsCount; i++)
            {
                int rand = random.Next(0, 4);
                switch (rand)
                {
                    case 0:
                        {
                            TransactionsInfo
                                .Add(transaction
                                    .WithdrawMoney(values[random
                                        .Next(0, values.Count)]));
                            break;
                        }
                    case 1:
                        {
                            TransactionsInfo
                                .Add(transaction
                                    .ViewBalance());
                            break;
                        }
                    case 2:
                        {
                            TransactionsInfo
                                .Add(transaction
                                    .TransferMoney(values[random
                                        .Next(0, values.Count)]));
                            break;
                        }
                    case 3:
                        {
                            TransactionsInfo
                                .Add(transaction
                                    .DepositMoney(values[random
                                        .Next(0, values.Count)]));
                            break;
                        }
                    default: break;
                }
            }
        }


        public string? SetCustomerName(){
            CustomerName = customer.Name;
            return CustomerName;
        }

        public string? SetCustomerId(){
            CustomerId = customer.Id;
            return CustomerId;
        }

        public string? SetCustomerEmail(){
            CustomerEmail = customer.CustomerEmail;
            return CustomerEmail;
        }

        public string? SetCustomerPhone(){
            CustomerPhone = customer.CustPhoneNumber;
            return CustomerPhone;
        }

        public string? SetCustomerCard(){
            CustomerCardNumber = customer.CustCardNumber;
            return CustomerCardNumber;
        }

        public List<string> SetTransactionsInfo(){
            return TransactionsInfo;
        }

        public int SetTransactionsCount(){
            return TransactionsCount;
        }

    }
}
