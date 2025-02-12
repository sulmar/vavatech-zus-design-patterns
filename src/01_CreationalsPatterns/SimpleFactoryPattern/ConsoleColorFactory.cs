using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFactoryPattern
{
    internal class ConsoleColorFactory
    {
        public ConsoleColor Create(decimal totalAmount) => totalAmount switch
        {
            0 => ConsoleColor.Green,
            >= 200 => ConsoleColor.Red,
            _ => ConsoleColor.White,
        };
    }
}
