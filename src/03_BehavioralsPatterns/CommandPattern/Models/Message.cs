using System;

namespace CommandPattern
{
    // Abstract Command
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }


    // Concrete Command A
    public class SendCommand : ICommand
    {
        private readonly Message message;

        public SendCommand(Message message)
        {
            this.message = message;
        }

        public bool CanExecute()
        {
            return !(string.IsNullOrEmpty(message.From) || string.IsNullOrEmpty(message.To) || string.IsNullOrEmpty(message.Content));
        }

        public void Execute()
        {
            Console.WriteLine($"Send message from <{message.From}> to <{message.To}> {message.Content}");
        }
    }

    // Concrete Command B
    public class PrintCommand : ICommand
    {
        private readonly Message message;
        private readonly byte copies;

        public PrintCommand(Message message, byte copies = 1)
        {
            this.message = message;
            this.copies = copies;
        }

        public bool CanExecute()
        {
            return !string.IsNullOrEmpty(message.Content);
        }

        public void Execute()
        {
            for (int i = 0; i < copies; i++)
            {
                Console.WriteLine($"Print message from <{message.From}> to <{message.To}> {message.Content}");
            }
        }
    }

    public class Message
    {
        public Message(string from, string to, string content)
        {
            From = from;
            To = to;
            Content = content;
        }

        public string From { get; set; }
        public string To { get; set; }
        public string Content { get; set; }
     
    }

}
