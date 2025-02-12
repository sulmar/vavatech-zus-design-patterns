using NGeoHash;
using System;

namespace AdapterPattern
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Adapter Pattern!");

            RadioAdapterFactory factory = new RadioAdapterFactory();

            Console.Write("Podaj typ radia: ");
            string radioType = Console.ReadLine();

            IRadioAdapter radio = factory.Create(radioType);           

            radio.Send("Hello World!", 10);

        }

       
    }

    


}
