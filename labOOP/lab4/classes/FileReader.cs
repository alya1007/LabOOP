using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class FileReader : IEntity
    {
        public List<Customer> ReadFile()
        {
            List<Customer> customers = new List<Customer>();
            string[] result = new string[6];
            string path = "customers.txt";
            string[] separator = { ", " };

            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(separator,StringSplitOptions.RemoveEmptyEntries);
                        Customer c = new Customer(result[0], result[1]);
                        c.CustomerEmail = result[2];
                        c.CustPhoneNumber = result[3];
                        c.CustomerPassword = result[4];
                        c.CustCardNumber = result[5];
                        customers.Add (c);
                    }
                    sr.Close();
                }
            }
            else
            {
                WriteLine("File not found.");
            }
            return customers;
        }
    }
}