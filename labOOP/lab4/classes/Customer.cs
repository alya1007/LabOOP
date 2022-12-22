using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Customer : ManagementSystem
    {
        private string? email;

        private string? phoneNumber;

        protected string? password;

        private string? cardNumber;

        public string? CustomerEmail
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public string? CustPhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
            }
        }

        public string? CustomerPassword
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string? CustCardNumber
        {
            get
            {
                return cardNumber;
            }
            set
            {
                cardNumber = value;
            }
        }

        public Customer(string? customerName, string? customerId) :
            base(name, id)
        {
            name = customerName;
            id = customerId;
        }

        public override void LogInSystem(string? pass)
        {
            if(pass == password)
            {
                WriteLine("Logging into system...");
            }
            else
            {
                WriteLine("Wrong password!");
            }
        }

        public override string ToString()
        {
            return $"Customer\n\tname: {name};\n\tid: {id};\n\temail: {email};\n\tphone number: {phoneNumber};\n\tpassword: {password};\n\tcard number: {cardNumber}.";
        }
    }
}