namespace CompositePattern;

class Program
{
    static void Main(string[] args)
    {
        // Test();


        QuestionTest();

    }

    private static void Test()
    {
        Manager ceo = new Manager("John Smith", "CEO");
        Manager headOfIT = new Manager("Bob Smith", "IT Director");
        headOfIT.Add(new Employee("Kate Smith", "developer"));
        headOfIT.Add(new Employee("Ann Smith", "tester"));
        headOfIT.Add(new Employee("Piter Smith", "developer"));

        ceo.Add(headOfIT);
    }

    private static void QuestionTest()
    {
        IQuestion knowCSharpDecision = new Decision("Welcome on Design Pattern in C# Course!");
        IQuestion uknownCSharpDesision = new Decision("The Course is not for you.");
        IQuestion questionCsharp = new Question("Do you know C#?", knowCSharpDecision, uknownCSharpDesision);
        IQuestion decisionHaveANiceday = new Decision("Have a nice day.");
        IQuestion questionDeveloper = new Question("Are you developer?", positive: questionCsharp, decisionHaveANiceday);

        questionDeveloper.Ask();

    }



}
