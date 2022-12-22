using static System.Console;
namespace lab6
{
    public class Customer
    {
        internal string? Name {get; set;}
        internal string? Id {get; set;}
        internal string? CustomerEmail {get; set;}
        internal string? CustPhoneNumber {get; set;}
        internal string? CustomerPassword {get; set;}
        internal string? CustCardNumber {get; set;}
        public Customer()
        {
        }
        public void LogInSystem(string? pass)
        {
            if(pass == CustomerPassword)
            {
                WriteLine("Logging into system...");
            }
            else
            {
                WriteLine("Wrong password!");
            }
        }
    }
}