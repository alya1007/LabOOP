using System.Runtime.Serialization.Json;
using static System.Console;
namespace lab6
{
   public class Status : ManagementSystem
    {
        public State AccStatus {get; set;}
        protected DateTime LastUpdate {get; set; } = new DateTime();
        public enum State
        {
            Active,
            Frozen,
            Inactive
        }
        public Status(){}
        public Status(string? custName, string? custId) :
            base(name, id)
        {
            name = custName;
            id = custId;
        }
        public void UpdateStatus(State newStatus)
        {
            AccStatus = newStatus;
            LastUpdate = DateTime.Today;
            WriteLine($"Status updated. Current state: {AccStatus}");
        }
    }
}
