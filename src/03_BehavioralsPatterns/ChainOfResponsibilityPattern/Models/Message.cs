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

    public class MessageContext
    {
        public Message Message { get; set; }
        public string TaxNumber { get; set; }
    }

    // Abstract Handler
    public interface IMessageHandler
    {
        void Handle(MessageContext context);
        void SetNext(IMessageHandler next);
    }

    public abstract class MessageHandler : IMessageHandler
    {
        private IMessageHandler next;
        public void SetNext(IMessageHandler next)
        {
            this.next = next;
        }

        public virtual void Handle(MessageContext context)
        {
           if (next != null) 
                next.Handle(context);
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

        public override void Handle(MessageContext context)
        {
            if (!whiteList.Contains(context.Message.From))
            {
                throw new Exception();
            }

            base.Handle(context);
        }
    }

    // Concrete Handler B
    public class ValidateTitleMessageHandler : MessageHandler, IMessageHandler
    {
        public override void Handle(MessageContext context)
        {
            if (!context.Message.Title.Contains("Order"))
            {
                throw new Exception();
            }

            base.Handle(context);
        }
    }

    public class ValidateTaxNumberMessageHandler : MessageHandler, IMessageHandler
    {
        public override void Handle(MessageContext context)
        {
            string pattern = @"\b(\d{10}|\d{3}-\d{3}-\d{2}-\d{2})\b";
            Regex regex = new Regex(pattern);
            Match match = regex.Match(context.Message.Body);

            if (match.Success)
            {
                string taxNumber = match.Value;

                context.TaxNumber = taxNumber;
            }
            else
            {
                throw new FormatException();
            }


            base.Handle(context);
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
            MessageContext context = new MessageContext { Message = message };

            firstHandler.Handle(context);

            return context.TaxNumber;
        }
    }
}
