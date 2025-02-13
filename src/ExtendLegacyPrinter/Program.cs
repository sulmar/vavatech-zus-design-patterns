// See https://aka.ms/new-console-template for more information
using ExtendLegacyPrinter;

Console.WriteLine("Hello, World!");

IPrinter printer = new PrinterWithCounterDecorator(
                    new PrinterWithCostDecorator(
                        new LegacyPrinterAdapter()));

printer.PrintDocument("Hello World!", 3);
