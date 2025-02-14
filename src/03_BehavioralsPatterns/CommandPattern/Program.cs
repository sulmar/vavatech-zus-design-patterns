using System;
using System.Collections.Generic;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Command Pattern!");

            Message message = new Message("555000123", "555888000", "Hello World!");
            Context context = new Context { Message = message };

            ICommand loginCommand = new LoginCommand(context);
            ICommand printCommand = new PrintCommand(context.Message);
            ICommand sendCommand = new SendCommand(message);
            ICommand loginAndPrintCommand = new LoginAndPrintCommand(context);

            //CompositeCommand loginAndPrintCommand = new CompositeCommand();
            //loginAndPrintCommand.Register(loginCommand);
            //loginAndPrintCommand.Register(printCommand);

            Queue<ICommand> commands = new Queue<ICommand>();
            commands.Enqueue(loginAndPrintCommand);

            while (commands.Count > 0)
            {
                ICommand command = commands.Dequeue();

                if (command.CanExecute())
                    command.Execute();
            }
        }
    }

}
