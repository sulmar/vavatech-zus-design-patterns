using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChainOfResponsibilityPattern.Models
{
    public class Message
    {
        public string From { get; set; }
        public string Title { get; set; }   
        public string Body { get; set; }
    }

    // Abstract Handler
    public interface IMessageHandler
    {
        void Handle(Message message);
        void SetNext(IMessageHandler next);
    }

    public abstract class MessageHandler : IMessageHandler
    {
        private IMessageHandler next;
        public void SetNext(IMessageHandler next)
        {
            this.next = next;
        }

        public virtual void Handle(Message message)
        {
           if (next != null) 
                next.Handle(message);
        }

      
    }

    // Concrete Handler A
    public class ValidateFromWhiteListMessageHandler : MessageHandler, IMessageHandler
    {
        private string[] whiteList;

        public ValidateFromWhiteListMessageHandler(string[] whiteList)
        {
            this.whiteList = whiteList;
        }

        public override void Handle(Message message)
        {
            if (!whiteList.Contains(message.From))
            {
                throw new Exception();
            }

            base.Handle(message);
        }
    }

    // Concrete Handler B
    public class ValidateTitleMessageHandler : MessageHandler, IMessageHandler
    {
        public override void Handle(Message message)
        {
            if (!message.Title.Contains("Order"))
            {
                throw new Exception();
            }

            base.Handle(message);
        }
    }

    public class ValidateTaxNumberMessageHandler : MessageHandler, IMessageHandler
    {
        public override void Handle(Message message)
        {
            string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;

                // TODO: zwróć wartość
                // return taxNumber;
            }
            else
            {
                throw new FormatException();
            }


            base.Handle(message);
        }

    }


    public class MessageHandlerFactory
    {
        string[] whiteList;

        public MessageHandlerFactory(string[] whiteList)
        {
            this.whiteList = whiteList;
        }

        public IMessageHandler Create()
        {
            IMessageHandler whitelistHandler = new ValidateFromWhiteListMessageHandler(whiteList);
            IMessageHandler titleHandler = new ValidateTitleMessageHandler();
            IMessageHandler taxNumberHandler = new ValidateTaxNumberMessageHandler();

            whitelistHandler.SetNext(titleHandler);
            titleHandler.SetNext(taxNumberHandler);

            IMessageHandler firstHandler = whitelistHandler;

            return firstHandler;
        }
    }

    public class MessageProcessor
    {      
        private readonly IMessageHandler firstHandler;

        public MessageProcessor(IMessageHandler handler)
        {
            this.firstHandler = handler;
        }

        public string Process(Message message)
        {
            firstHandler.Handle(message);

            throw new NotImplementedException();
        }
    }
}
