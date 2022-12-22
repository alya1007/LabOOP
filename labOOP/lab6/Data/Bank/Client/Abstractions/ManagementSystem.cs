namespace lab6{
    public abstract class ManagementSystem
    {
        protected static string? name;
        protected static string? id;
        public ManagementSystem(){}
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
