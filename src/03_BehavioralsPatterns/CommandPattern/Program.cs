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

            ICommand printCommand  = new PrintCommand(message);
            ICommand sendCommand = new SendCommand(message); 

            Queue<ICommand> commands = new Queue<ICommand>();
            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);
            commands.Enqueue(printCommand);
            commands.Enqueue(sendCommand);

            while(commands.Count > 0)
            {
                ICommand command = commands.Dequeue();
                
                if (command.CanExecute())
                    command.Execute();
            }
        }
    }

}
