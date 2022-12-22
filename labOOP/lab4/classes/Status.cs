using System;
using System.IO;

using static System.Console;

namespace lab4
{
    class Status : ManagementSystem
    {
        private State accStatus;

        private DateTime lastUpdate = new DateTime();

        public State AccStatus
        {
            get
            {
                return accStatus;
            }
            set
            {
                accStatus = value;
            }
        }

        public DateTime LastUpdate
        {
            get
            {
                return lastUpdate;
            }
            set
            {
                lastUpdate = value;
            }
        }

        public enum State
        {
            Active,
            Frozen,
            Inactive
        }

        public Status(string? custName, string? custId) :
            base(name, id)
        {
            name = custName;
            id = custId;
        }

        public void UpdateStatus(State newStatus)
        {
            accStatus = newStatus;
            AccStatus = newStatus;
            lastUpdate = DateTime.Today;
            LastUpdate = DateTime.Today;
            WriteLine($"Status updated. Current state: {accStatus}");
        }

        public override string ToString()
        {
            return $"Account status: {accStatus}, last update: {lastUpdate}.";
        }
    }
}
