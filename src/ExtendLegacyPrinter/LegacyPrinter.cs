namespace ExtendLegacyPrinter;

public class LegacyPrinter
{
    public void PrintDocument(string document)
    {
        Console.WriteLine($"Legacy Printer is printing: {document}");
    }
}

public interface IPrinter
{
    void PrintDocument(string document, byte copies);
}


public class PrinterWithCounterDecorator : IPrinter
{
    private readonly IPrinter printer;    

    public PrinterWithCounterDecorator(IPrinter printer)
    {
        this.printer = printer;
    }

    public void PrintDocument(string document, byte copies)
    {
        printer.PrintDocument(document, copies);

        Console.WriteLine($"Counter: {copies}");
    }
}

// Decorator
public class PrinterWithCostDecorator : IPrinter
{
    // Decorated
    private readonly IPrinter printer;
    
    private decimal pricePerChar = 0.11m;

    public PrinterWithCostDecorator(IPrinter printer)
    {
        this.printer = printer;
    }

    public void PrintDocument(string document, byte copies)
    {
        printer.PrintDocument(document, copies);

        var cost = document.Length * copies * pricePerChar;

        Console.WriteLine($"Total cost: {cost}");
    }
}

// Adapter
public class LegacyPrinterAdapter : IPrinter
{
    // Adaptee
    private LegacyPrinter legacyPrinter = new LegacyPrinter();

    public void PrintDocument(string document, byte copies)
    {
        for (int i = 0; i < copies; i++)
        {
            legacyPrinter.PrintDocument(document);
        }
     
    }
}