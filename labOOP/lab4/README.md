# Polymorphism
To use polymorphism principle in this laboratory work, I have created an interface IEntity, from which inherit classes: Account, FileReader, ManagementSystem, Employee and inherits anothe interface - ITransaction.
Also, there are a lot of overridden methods: CalculatePay() in Manager and Admin, LogInSystem() in Customer; ToString() in almost each class created.
Abstract classes are also present: Employee and ManagementSystem.

# Scenarios
I created an addition class, where are 4 methods for 4 different scenarios.

# Scenario 1 - User creates bank account
This is the scenario in which a client creates a new bank account. They are asked to introduce personal data, like phone number, id, card number, and for some of this fields (phone nr and card nr), there are several scenarios: in which client introduces wrong format of this fields. Also, when creating a password, it must have at least 8 characters.
The next step is logging into system, where also several scenarios can take place: introducing wrong account number or wrong password. In case of writing wrong password for 3 times in raw, the accont status becomes temporarily frozen.

# Scenario 2 - User checks balance
In this simulation two accounts are created, each with a status, and two balance objects are instantiated. User can access balance only if the account status is active.

# Scenario 3 - User makes transaction
Client is given 3 options: to deposit, withdraw and transfer money. Each choice represents a different scenario. Also, if the amount of money that user wants to withdraw/transfer is an invalid value (bigger than the actual value of balance), it's given an error.

# Scenario 4 - Bank generates paychecks for employees
The following scenarios are presented: an employee worked the required amount of hours - they get the normal salary; an employee worked more than required hours - they are payed more than average salary; an employee worked more than required hours - it's displayed a message about considering to fire this employee.