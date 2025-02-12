using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public class Call
    {
        public string From { get; set; }
        public string To { get; set; }
        public string Subject { get; set; }

        public override string ToString()
        {
            return $"Calling from {From} to {To} with subject {Subject}";
        }
    }

    public class CallBuilder
    {
        private Call call = new Call();

        public CallBuilder From(string from)
        {
            call.From = from;

            return this;
        }

        public CallBuilder To(string to)
        {
            call.To = to;

            return this;
        }

        public CallBuilder WithSubject(string subject)
        {
            call.Subject = subject;

            return this;
        }


        public Call Build()
        {
            return call;
        }
    }


    public class Phone
    {
        public void Call(string from, string to, string subject)
        {
            Console.WriteLine($"Calling from {from} to {to} with subject {subject}");
        }

        public void Call(string from, string to)
        {
            Console.WriteLine($"Calling from {from} to {to}");
        }

        public void Call(string from, IEnumerable<string> tos, string subject)
        {
            foreach (var to in tos)
            {
                Call(from, to, subject);
            }
        }
    }

}