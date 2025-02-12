using System;
using System.Collections.Generic;

namespace BuilderPattern
{
    public class Call
    {
        public string From { get; set; }
        public List<string> To { get; set; } = new List<string>();
        public string Subject { get; set; }

        public override string ToString()
        {
            return $"Calling from {From} to {string.Join(',', To)} with subject {Subject}";
        }
    }
}