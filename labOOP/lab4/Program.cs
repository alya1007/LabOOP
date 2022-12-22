using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Program
    {
        static void Main(string[] args)
        {
            Scenarios s = new Scenarios();
            s.Scenario1();
            ReadLine();
            s.Scenario2();
            ReadLine();
            s.Scenario3();
            ReadLine();
            s.Scenario4();
        }
    }
}