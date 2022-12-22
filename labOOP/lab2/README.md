# Lab2
I chose to simulate a bank management system in C#. The following project contains not only objects that represent some of the basic parts of a bank (like bank accounts, ATMs, customers), but also objects that represent and are related to the employees of a bank. I created 10 classes for this simulation, and further there will be presented a description of each of them and of their functionalities.

# Bank
An object of this type represents a bank, with such fields like: code of the bank and name of the bank (which are setted through constructor). The bank object has one property: its address, and one method: ToString(), which returns all the information about the bank.

# Account
This represents a client's account with elemets like: number of account, current balance (set via property "Balance"). The account can be modified through the method "EditAccount()" which has two parameters: the new account number and new balance. The only method is ToString, which returns the information about the account.

# Customer
This class is used to get data about the clients of the bank. It has the following private fields: name of the client, their id and private fields, whose values are setted via properties: email, phone number, password and curd number. There is only one method: ToString(), that returns the information about the customer.

# FileReader
The next class is meant to read information about customers from a txt file. The only method, ReadFile(), creates a list of customer objects, and reads from each line of file the customer's name, id, email, phone number, password and card number. The returned value is the list of all customers from the file.

# ATM
This is the simulation of a real ATM machine, that has the field balance and a public property BankName. The methods of this class are: DepositMoney - takes as parameret the amount of money the client wants to deposit, and adds it to the balance of the account; WithdrawMoney - takes as parameret the amount of money the client wants to withdraw, and subtrackts it from the balance of the account; TransferMoney - takes as paramerets the amount of money the client wants to transfer and the number of card on which the money should be transfered, and subtrackts the the amount from the balance of the account. Also, there is a ToString method, which returns the bank name of the ATM and the balance of the customer account.

# Transaction
Transaction class has two private fields: id (of the transaction) and the balance of the bank account and one public field - date - which represents the date when transaction was made. The only method is ToString, that returns the information about the made transaction.

# Login
This class has the private fields: id of the customer and their account password (needed to log into the system). The method LogIntoSystem performs the signing in into the system.

# Employee
The next class represents an employee of the bank. The fields of this class are: hourPay - the hourly rate of the employee, hWorked - number of hours worked by employee in one month , monthPay - the month salary of the employee. The properties are: Name (name of the employee) and HoursWorked (sets the value of the field "hWorked"). The methods are CalculatePay() - calculates the salary; ToString - gets the information about the employee.

# Manager
This class is pretty much same to the Employee, except it has also some private constant fields: bonus and hoursForBonus - the value of bonus is added to the salary if manager worked more than the hoursForBonus. The method CalculateManagerPay calculates the salary of the manager.

# Paycheck
Paycheck method gets the month and year for the paycheck. It also has an enum of months (to convert the number of month in its name). The two methods generate the paycheck for an employee and for a manager.