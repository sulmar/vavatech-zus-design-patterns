namespace CompositePattern
{
    public interface IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }
    }

    // Leaf
    public class Employee : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }

        public Employee(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }

    // Node
    public class Manager : IEmployee
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public List<IEmployee> Employees { get; set; } = new List<IEmployee>();

        public Manager(string name, string position)
        {
            Name = name;
            Position = position;
        }

        public void Add(IEmployee employee)
        {
            Employees.Add(employee);
        }
    }
}
