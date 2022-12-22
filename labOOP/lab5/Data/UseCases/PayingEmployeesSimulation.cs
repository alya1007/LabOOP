namespace lab6.Data.UseCases
{
    class PayEmployeesSimulation
    {
        public void PayEmployees()
        {
            int i = 0;
            Random rd = new Random();
            string path = "Models/employees.txt";
            List<Employee> employees = new List<Employee>();
            if (File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string? line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (rd.NextDouble() < 0.5)
                        {
                            Manager mng = new Manager(line, 40);
                            employees.Add (mng);
                        }
                        else
                        {
                            Admin adm = new Admin(line, 50);
                            employees.Add (adm);
                        }
                        i++;
                    }
                    sr.Close();
                }
            }
            int rand1 = rd.Next(100, 200);
            int randEmployee = rd.Next(0, employees.Count());
            // employees[randEmployee].HoursWorked = rand1;
            Paycheck p = new Paycheck(rd.Next(1, 13), rd.Next(2021, 2023));
            p.GeneratePaycheck(employees[randEmployee]);
        }
    }
}
