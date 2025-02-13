namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        Manager ceo = new Manager("John Smith", "CEO");
        Manager headOfIT = new Manager("Bob Smith", "IT Director");
        headOfIT.Add(new Employee("Kate Smith", "developer"));
        headOfIT.Add(new Employee("Ann Smith", "tester"));
        headOfIT.Add(new Employee("Piter Smith", "developer"));

        ceo.Add(headOfIT);


        // QuestionTest();

    }

    private static void QuestionTest()
    {
        Console.Write("Are you developer?");

        if (Response)
        {

            Console.Write("Do you know C#?");

            if (Response)
            {
                Console.WriteLine("Welcome on Design Pattern in C# Course!");
            }
            else
            {
                Console.WriteLine("The Course is not for you.");
            }

        }
        else
        {
            Console.WriteLine("Have a nice day.");
        }
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;

}
