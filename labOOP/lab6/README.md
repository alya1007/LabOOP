The simulation of this bank system consists of the following parts:
  - Making a bank account. Here are possible choices like making a new account or logging into an existing one;
  - Making a transaction. Client can choose which operation to perform and whether to make multiple transactions or not;

Also, the MVC architectural deesign pattern is implemented here. For this I created classes:
  - Bank - represent the bank model. It sets the data about the bank clients and has several methods to pass the data in the controller.
  - BankController - gets the data from the model, and passes it through its methods
  - MainBankView - outputs the information of the simulation
