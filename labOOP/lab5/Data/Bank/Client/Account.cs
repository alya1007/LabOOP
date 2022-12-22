using static System.Console;
namespace lab6
{
    public class Account
    {
        public string? AccNumber {get; set;}
        public float Balance {get; set;}
        public Account(){}
        public void CreateAccount(Customer cust){
            AccNumber = cust.Id; 
        }
        public void EditAccount(string? newNumber)
        {
            AccNumber = newNumber;
            WriteLine("The account was edited.");
        }
    }
}