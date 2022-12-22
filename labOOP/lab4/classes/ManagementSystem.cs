using System;
using System.IO;

using static System.Console;

namespace lab4
{
    abstract class ManagementSystem : IEntity
    {
        protected static string? name;

        protected static string? id;

        public ManagementSystem(string? custName, string? custId)
        {
            name = custName;
            id = custId;
        }

        public virtual void LogInSystem(string? pass)
        {
        }
    }
}
