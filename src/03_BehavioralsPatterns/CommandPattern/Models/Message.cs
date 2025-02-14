using System;
using System.Collections.Generic;

namespace CommandPattern
{
    // Abstract Command
    public interface ICommand
    {
        void Execute();
        bool CanExecute();
    }


    public class CompositeCommand : ICommand
    {
        Queue<ICommand> commands = new Queue<ICommand>();

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                    command.Execute();
            }
        }

        public void Register(ICommand command)
        {
            commands.Enqueue(command);
        }
    }


    public class LoginAndPrintCommand : ICommand
    {
        private readonly Context context;

        public LoginAndPrintCommand(Context context)
        {
            this.context = context;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            ICommand loginCommand = new LoginCommand(context);
            ICommand printCommand = new PrintCommand(context.Message);

            loginCommand.Execute();
            printCommand.Execute();
        }
    }

    public class LoginCommand : ICommand
    {
        private readonly Context context;

        public LoginCommand(Context context)
        {
            this.context = context;
        }

        public bool CanExecute()
        {
            return true;
        }

        public void Execute()
        {
            Console.WriteLine("Login");
            context.User = "john";
        }
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
        private readonly string user;
        private readonly byte copies;

        public PrintCommand(Message message, byte copies = 1)
        {
            this.message = message;
            this.user = user;
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
                Console.WriteLine($"Print message from <{message.From}> to <{message.To}> {message.Content} by {user}");
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

    public class Context
    {
        public Message Message { get; set; }
        public string User { get; set; }
    }

}
