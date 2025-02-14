namespace MediatorPattern
{
    // Abstract Mediator
    public interface IMediator
    {
        void SendMessage(EventType eventType, string message, Collegue sender);
    }

    public enum EventType
    {
        CoffeeBreak,
        Lunch,
        Finished
    }

    // Abstract Collegue (uczestnik)
    public abstract class Collegue
    {
        public abstract void ReceiveMessage(EventType eventType, string message);
    }

    // Concrete Mediator
    public class ConcreteMediator : IMediator
    {
        private List<Collegue> collegues = new List<Collegue>();

        public void SendMessage(EventType eventType, string message, Collegue sender)
        {
            foreach (var collegue in collegues)
            {
                if (collegue != sender)
                {
                    collegue.ReceiveMessage(eventType, message);
                }
            }
        }

        public void Register(Collegue collegue)
        {
            collegues.Add(collegue);
        }
    }

    // Concrete Collegue
    public class User : Collegue
    {
        private readonly IMediator mediator;

        public string Name { get; set; }

        public User(IMediator mediator, string name)
        {
            this.mediator = mediator;
            this.Name = name;
        }

        public override void ReceiveMessage(EventType eventType, string message)
        {
            if (eventType == EventType.Lunch)
                Console.WriteLine($"{Name} received Lunch {message}");
            else
                if (eventType == EventType.Finished)
                    Console.WriteLine($"{Name} received Finished {message}");

        }

        public void Send( EventType eventType, string message)
        {
            mediator.SendMessage(eventType, message, this);
        }
    }


}
