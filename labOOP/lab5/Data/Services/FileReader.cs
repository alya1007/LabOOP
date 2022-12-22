using static System.Console;
namespace lab6
{
    class FileReader
    {
        public List<Customer> ReadFile(int num, string path)
        {
            List<Customer> customers = new List<Customer>();
            string[] result = new string[6];
            string[] separator = { "," };
            int i = 0;
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (i < num)
                    {
                        result =
                            (sr.ReadLine() ?? "")
                                .Split(separator,
                                StringSplitOptions.RemoveEmptyEntries);
                        Customer c = new Customer();
                        c.Name = result[0];
                        c.Id = result[1];
                        c.CustomerEmail = result[2];
                        c.CustPhoneNumber = result[3];
                        c.CustomerPassword = result[4];
                        c.CustCardNumber = result[5];
                        customers.Add (c);
                        i++;
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
