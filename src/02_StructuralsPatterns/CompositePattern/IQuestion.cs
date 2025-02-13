using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern;

public interface IQuestion
{
    void Ask();
}

// Node
public class Question : IQuestion
{
    public string Prompt { get; set; }

    private IQuestion positive;
    private IQuestion negative;

    public Question(string prompt, IQuestion positive, IQuestion negative)
    {
        Prompt = prompt;
        this.positive = positive;
        this.negative = negative;
    }

    public void Ask()
    {
        Console.WriteLine(Prompt);

        if (Response)
        {
            positive.Ask();
        }
        else
        {
            negative.Ask();
        }
    }

    public static bool Response => Console.ReadKey().Key == ConsoleKey.Y;
}

// Leaf
public class Decision : IQuestion
{
    public string Message { get; set; }

    public Decision(string message)
    {
        Message = message;
    }

    public void Ask()
    {
        Console.WriteLine(Message);
    }
}

